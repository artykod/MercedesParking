using UnityEngine;

public class Clouds : MonoBehaviour {
	private Transform[] clouds = null;
	private float[] speed = null;

	private void Awake() {
		clouds = GetComponentsInChildren<Transform>();
		speed = new float[clouds.Length];
		for (int i = 0; i < speed.Length; i++) {
			speed[i] = (Random.value + 0.5f) * 0.5f * (Random.value > 0.5f ? 1f : -1f) * 2f;
		}
	}

	private void Update() {
		for (int i = 1; i < clouds.Length; i++) {
			Transform cloud = clouds[i];
			cloud.RotateAround(Vector3.zero, Vector3.forward, speed[i] * Time.deltaTime);
		}
	}
}
