﻿using UnityEngine;

public class ParkingCarVisual : MonoBehaviour {

	public Bounds VisualBounds {
		get {
			return GetComponent<SpriteRenderer>().bounds;
		}
	}

	public Car Car {
		get;
		private set;
	}

	private void Awake() {
		//
	}

	public void Setup(Car car) {
		ParkingCellVisual cell = ParkingCellVisual.GetCellVisual(car.CellRoot);

		Car = car;

		if (cell != null) {
			transform.localPosition = cell.transform.localPosition + new Vector3(0f, 0f, -1f);

			float angle = 0f;
			switch (car.MoveDirection) {
			case Car.Direction.Right:
				angle = -90f;
				break;
			case Car.Direction.Left:
				angle = 90f;
				break;
			case Car.Direction.Up:
				angle = 0f;
				break;
			case Car.Direction.Down:
				angle = 180f;
				break;
			}

			transform.localRotation = Quaternion.Euler(0f, 0f, angle);
		}
	}

	private void Update() {
		if (Car != null) {
			ParkingCellVisual cell = ParkingCellVisual.GetCellVisual(Car.CellRoot);
			if (cell != null) {
				transform.localPosition = cell.transform.localPosition + new Vector3(0f, 0f, -2f);
			}
		}
	}

	private void OnDrawGizmos() {
		Vector2 min = VisualBounds.min;
		Vector2 max = VisualBounds.max;
		Gizmos.DrawLine(min, max);
	}
}