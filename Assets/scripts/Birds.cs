using UnityEngine;
using System.Collections;

public class Birds : MonoBehaviour {
	[SerializeField]
	private Transform birdPrefab = null;

	private void Awake() {
		for (int i = 0; i < 4; i++) {
			Transform bird = Instantiate(birdPrefab);
			bird.SetParent(transform, false);
			bird.localRotation = Quaternion.Euler(90f, -90f, 90f);
			bird.localPosition = new Vector3(-50f, 0f);

			StartCoroutine(FlyBird(bird, Random.Range(i, i * 2f)));
		}
	}

	private Vector3 RandomPosition() {
		float screenRadius = 20f;
		Vector3 rotation = Quaternion2DHelper.DirectionFromRotation(Quaternion2DHelper.RotationWithDegrees(Random.Range(0f, 360f)));
		return rotation * screenRadius;
	}

	private IEnumerator FlyBird(Transform bird, float delay) {

		yield return new WaitForSeconds(delay);

		Vector3 randomPosition = RandomPosition();
		Vector3 randomPositionTarget = RandomPosition();

		Vector3 start = new Vector3(randomPosition.x, randomPosition.y, 0f);
		Vector3 target = new Vector3(randomPositionTarget.x, randomPositionTarget.y, 0f);

		Quaternion q = Quaternion2DHelper.RotationWithDirection(target - start);

		bird.rotation = Quaternion.Euler(q.eulerAngles.z + 180f, -90f, 90f);

		float time = 8f;
		float current = 0f;
		while (current <= time) {
			float t = current / time;
			current += Time.deltaTime;

			bird.position = Vector3.Lerp(start, target, t);

			yield return null;
		}

		StartCoroutine(FlyBird(bird, Random.Range(delay, delay + 0.5f)));
	}
}
