using UnityEngine;

public class SpawnZombie : MonoBehaviour {

	public GameObject zombie;                // The prefab to be spawned. 
	public GameObject bullet; 
	public GameObject spawnZombie;


	void Start () 
	{

	}

	void Update () {

	}

	void  OnTriggerEnter(Collider bullet)
	{
		if (bullet.gameObject.tag == "bullet") 
		{
			DestroyObject(zombie.gameObject);
			DestroyObject (bullet.gameObject);
		}
	}




}

