using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;

	public GameObject bulletSpawn;
	public GameObject muzzleSpawn;
	public GameObject bullet;
	public float bulletlife;
	public float bulletspeed;
	public float fireRate;
	public float kills;

	public ParticleSystem muzzle;

	Vector3 origLocation;
	Quaternion origRotation;

	public float numSecondsToShake = 0.2f;
	public float intensity = 0.1f;
	public GameObject mainC;

	public AudioClip zombieDeath;
	public AudioClip fire;
	private float nextFiretime;
	public bool dead;

	// Use this for initialization
	void Start () {

		origLocation = mainC.transform.position;
		origRotation = mainC.transform.rotation;

		dead = false;
	}

	void Update () {
		if (!dead) {
			
			movex = Input.GetAxis ("Horizontal");
			movey = Input.GetAxis ("Vertical");
		
		Rigidbody2D rigi = GetComponent<Rigidbody2D>();
		rigi.velocity = new Vector2 (movex * Speed, movey * Speed);
		}
		if (!dead) {
			Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			diff.Normalize ();

			float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;


			transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (Time.time > fireRate + nextFiretime) {
				StartCoroutine("shakeCam");
				muzzle.transform.position = muzzleSpawn.transform.position;
				muzzle.transform.rotation = transform.rotation;
				muzzle.Emit (5);
				GetComponent<AudioSource> ().PlayOneShot (fire,.1f);
				GameObject temp = Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
				temp.transform.Rotate(temp.transform.localRotation.x,temp.transform.localRotation.y, temp.transform.localRotation.z+Random.Range(-0,0));
				temp.GetComponent<Rigidbody2D> ().AddForce (temp.transform.up* bulletspeed);
				nextFiretime = Time.time;
				Destroy (temp, bulletlife);

			}
		}

		if (dead) {
			 Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
			rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation |  RigidbodyConstraints2D.FreezePositionY;
		}
	}

	IEnumerator shakeCam() {
		// shake for a number of seconds
		float timeLeft = numSecondsToShake;
		while (timeLeft > 0) {
			mainC.transform.position = origLocation + Random.insideUnitSphere * intensity;
			timeLeft -= Time.deltaTime;
			yield return null; // stops the loop from contining this time
		}
		// return the camera to the orig position
		mainC.transform.position = origLocation;
		mainC.transform.rotation = origRotation;
	}
}
