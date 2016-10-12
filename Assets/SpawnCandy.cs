using UnityEngine;
using System.Collections;

public class SpawnCandy : MonoBehaviour {

public GameObject Candy;
//	public float firerate;
//	private float nextFireTime;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
//		if (Input.GetKey(KeyCode.C)) {
//			Instantiate (Candy, transform.position, transform.rotation);
//	}
		if (Input.GetKey(KeyCode.Space)) {
			GameObject temp = Instantiate (Candy, transform.position, transform.rotation) as GameObject;
			temp.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * 100);
			}


}
}