using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

	public GameObject zombie;                // The prefab to be spawned. 
	public GameObject bullet; 
	public GameObject spawnZombie;
	private Vector2 spawnPosition;
	public float maxTime = 6;
	public float minTime = 2;
	private float time;
	private float spawnTime;


	void Start () 
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		//	InvokeRepeating ("Spawn", spawnTime, spawnTime);

		SetRandomTime();
		time = minTime;
	}

	void Update () {

		//Counts up
		time += Time.deltaTime;

		//Check if its the right time to spawn the object
		if (time >= spawnTime) {
			Spawn();
			SetRandomTime ();

		}
	}


	void Spawn ()
	{
		spawnPosition.x = Random.Range (-10, 10);
		spawnPosition.y = Random.Range (-10, 10);

		Vector2 position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
		Instantiate(zombie, position, Quaternion.identity);
	}

	void SetRandomTime(){
		time = minTime;
		spawnTime = Random.Range(minTime, maxTime);
	}

}
