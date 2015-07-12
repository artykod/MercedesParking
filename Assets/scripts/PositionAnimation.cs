using UnityEngine;

public class PositionAnimation : MonoBehaviour {
	[SerializeField]
	private Vector3 offset = Vector3.zero;

	private Vector3 position = Vector3.zero;
	private float angle = 0f;

	private void Awake() {
		position = transform.localPosition;
	}

	private void Update () {
		Vector3 rotated = (Quaternion.Euler(0f, 0f, angle) * offset);
		Vector3 pos = position;
		pos.x += rotated.x;
		pos.z += rotated.y;
        transform.localPosition = pos;

		angle += Time.deltaTime * 20f;
    }
}
