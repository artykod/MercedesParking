using UnityEngine;

public class DepthAnimation : MonoBehaviour {
	[SerializeField]
	private float startZ = -3.38f;
	[SerializeField]
	private float endZ = -3.38f;
	[SerializeField]
	private AnimationCurve animCurve = null;
	[SerializeField]
	private float timeOffset = 0f;

	private void Update() {
		Vector3 pos = transform.localPosition;
		float t = animCurve.Evaluate(Time.time + timeOffset);
		pos.z = Mathf.Lerp(startZ, endZ, t);
		transform.localPosition = pos;
    }
}
