using UnityEngine;

public class FieldCar : Car {

	protected FieldCell cellForward = null;

	public override CarType Type {
		get {
			return CarType.FieldCar;
		}
	}

	public FieldCell CellForward {
		get {
			return cellForward;
		}
		protected set {
			if (cellForward != null && cellForward != cellRoot) {
				cellForward.Car = null;
			}

			cellForward = value;

			if (cellForward != null) {
				cellForward.Car = this;
			}
		}
	}

	public override Car SetPosition(int x, int y, Direction direction) {
		base.SetPosition(x, y, direction);

		CellForward = Field.Instance.GetCell(x + directionX, y + directionY);

		return this;
	}

	public override bool Move(int dirX, int dirY) {
		if (!VerifyDirection(ref dirX, ref dirY)) {
			return false;
		}

		bool result = false;

		int newX = x + dirX;
		int newY = y + dirY;

		FieldCell newCellRoot = Field.Instance.GetCell(newX, newY);
		FieldCell newCellForward = Field.Instance.GetCell(newX + directionX, newY + directionY);

		if (newCellRoot != null && (newCellRoot.IsFree || newCellRoot.Car == this) && newCellForward != null && (newCellForward.IsFree || newCellForward.Car == this)) {
			result = true;

			CellRoot = newCellRoot;
			CellForward = newCellForward;

			x = newX;
			y = newY;
		}

		return result;
	}
}
