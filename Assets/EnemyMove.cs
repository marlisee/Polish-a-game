using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	private Transform Player;
	public float MoveSpeed = 4;
	public float MaxDist = 10;
	public float MinDist = 5;

	void Start()
	{
		MoveSpeed = Random.Range (1, 3);

		// set player dynamically
		// find player object, assigne Transform Player to that transform
		Player = GameObject.Find("Player").transform;
	}

	void Update () 
	{
		Vector3 diff = Player.transform.position - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

		if(Vector2.Distance(transform.position,Player.position) >= MinDist){

			transform.position += transform.right*MoveSpeed*Time.deltaTime;



			if(Vector2.Distance(transform.position,Player.position) <= MaxDist)
			{
				//Here Call any function U want Like Shoot at here or something
			} 

		}
	}

	/*void OnCollisionEnter (Collision other) {

		if (other.gameObject.transform.tag == "bullet") {

			Destroy (gameObject);
		}

	}*/
}
			