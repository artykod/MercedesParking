using UnityEngine;
using System.Collections.Generic;

public class ParkingVisual : MonoBehaviour {
	[SerializeField]
	private ParkingCellVisual cellVisual = null;
	[SerializeField]
	private float cellVisualWidth = 1.25f;
	[SerializeField]
	private float cellVisualHeight = 1.25f;

	[SerializeField]
	private ParkingCarVisual carVisual = null;
	[SerializeField]
	private ParkingCarVisual carVisualPlayer = null;

	private List<ParkingCellVisual> cells = new List<ParkingCellVisual>(100);
	private List<ParkingCarVisual> cars = new List<ParkingCarVisual>(10);

	private Vector2 lastTouch = Vector2.zero;

	private void Awake() {
		Field.Generate(8, 6);

		cells.Clear();
		foreach (var i in Field.Instance.Cells) {
			if (!i.IsBlocked) {
				ParkingCellVisual cell = Instantiate(cellVisual);
				cell.transform.SetParent(transform, false);
				cell.transform.localPosition = new Vector3(i.FieldX * cellVisualWidth, i.FieldY * cellVisualHeight);
				cell.Setup(i);
				cells.Add(cell);
			}
        }

		cars.Clear();
        foreach (var i in Field.Instance.Cars) {
			ParkingCarVisual car = Instantiate(i is PlayerCar ? carVisualPlayer : carVisual);
			car.transform.SetParent(transform, false);
			car.Setup(i as Car);
			cars.Add(car);
        }
	}

	private void Start() {
		GameCore.StartGame();
	}

	private bool IsPointInBounds(Vector2 point, Bounds bounds) {
		Vector2 min = bounds.min;
		Vector2 max = bounds.max;
		return point.x > min.x && point.y > min.y && point.x < max.x && point.y < max.y;
	}

	private void Update() {

		if (!GameCore.IsGameStarted) {
			return;
		}

		Vector2 touch = Input.mousePosition;

		if (Input.GetMouseButtonDown(0)) {
			lastTouch = touch;
		}
		if (Input.GetMouseButtonUp(0)) {
			Vector2 delta = touch - lastTouch;
			Vector2 absDelta = new Vector2(Mathf.Abs(delta.x), Mathf.Abs(delta.y));
			if (absDelta.x > absDelta.y) {
				delta.y = 0f;
			} else {
				delta.x = 0f;
			}
			if (absDelta.x < 50f && absDelta.y < 50f) {
				delta.x = 0f;
				delta.y = 0f;
			}

			Vector2 worldTouch = Camera.main.ScreenToWorldPoint(lastTouch);

			ParkingCarVisual car = null;
			foreach (var i in cars) {
				if (IsPointInBounds(worldTouch, i.VisualBounds)) {
					car = i;
					break;
				}
			}
			if (car != null) {
				car.Car.Move((int)delta.x, (int)delta.y);
			}
		}
	}
}
