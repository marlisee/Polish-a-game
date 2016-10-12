using UnityEngine;
using System.Collections;

public class destroyZombie : MonoBehaviour {
	public GameObject bullet; 
	public GameObject zombie; 
	public MovePlayer playerscript;

	public GameObject blood;

	private ParticleSystem part;

	// Use this for initialization
	void Start () {
		
		blood = GameObject.Find ("Particle System (1)");
		part = blood.GetComponent<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D zombie)
		{
		if (zombie.gameObject.tag == "zombie") 
			{
				Destroy(zombie.gameObject);
			playerscript.GetComponent<AudioSource> ().PlayOneShot (playerscript.zombieDeath,.5f);
			blood.transform.position = zombie.gameObject.transform.position;
			blood.transform.rotation = transform.rotation;
			playerscript.kills++;
			part.Emit(Random.Range(20,30));
			Destroy (gameObject);




			}
		}

	}

