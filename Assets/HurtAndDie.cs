using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HurtAndDie : MonoBehaviour {
	public GameObject zombie; 
	public GameObject Player;
	public Collider2D coll;
	public Text DieText;
	public Text dietext2;
	public MovePlayer script;
	public GameObject blood;
	private ParticleSystem part;

	// Use this for initialization
	void Start () {
		blood = GameObject.Find ("Green Blood");
		part = blood.GetComponent<ParticleSystem> ();
	}

	IEnumerator wait2Seconds() {
		yield return new WaitForSeconds (4);
		DieText.gameObject.SetActive (false);
		Application.LoadLevel("Game Run"); //name of your death scene
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "zombie") {
			blood.transform.position = Player.transform.position;
			blood.transform.rotation = transform.rotation;
			part.Emit (20);
			DieText.gameObject.SetActive (true);
			dietext2.gameObject.SetActive (true);
			dietext2.text = "You've killed  " + script.kills + ". They've killed 1" +"\n"+ "Who's the monster now?";
			script.dead = true;
			StartCoroutine("wait2Seconds");

		}
	}



}
