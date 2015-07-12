using UnityEngine;

public class RotationAnimation : MonoBehaviour {
	[SerializeField]
	private float amplitude = 5f;
	[SerializeField]
	private AnimationCurve animCurve = null;
	[SerializeField]
	private float timeOffset = 0f;
	[SerializeField]
	private float speed = 1f;
	[SerializeField]
	private bool animateX = true;
	[SerializeField]
	private bool animateY = true;
	[SerializeField]
	private bool animateZ = true;

	private Vector3 startAngles = Vector3.zero;

	private void Awake() {
		startAngles = transform.localRotation.eulerAngles;
	}

	private void Update () {
		float t = animCurve.Evaluate(Time.time * speed + timeOffset) - 0.5f;
		Vector3 angles = startAngles;
		if (animateX) {
			angles.x += amplitude * t;
		}
		if (animateY) {
			angles.y += amplitude * t;
		}
		if (animateZ) {
			angles.z += amplitude * t;
		}
		transform.localRotation = Quaternion.Euler(angles);
	}
}
