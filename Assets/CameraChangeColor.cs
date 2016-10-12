using UnityEngine;

public class CameraChangeColor : MonoBehaviour
{
	public Gradient myGradient;
	public float strobeDuration = 2f;

	public void Update() {
		float t = Mathf.PingPong(Time.time / strobeDuration, 1f);
		Camera.main.backgroundColor = myGradient.Evaluate(t);
	}
}