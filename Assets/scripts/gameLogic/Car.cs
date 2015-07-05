using UnityEngine;

public abstract class Car {
	public enum Direction {
		Up,
		Right,
		Down,
		Left,
		Any,
	}

	public enum CarType {
		Unknown,
		Player,
		FieldCar,
	}

	protected Direction direction = Direction.Any;
	protected int x = 0;
	protected int y = 0;
	protected int directionX = 0;
	protected int directionY = 0;

	protected FieldCell cellRoot = null;

	public abstract CarType Type {
		get;
	}

	public Direction MoveDirection {
		get {
			return direction;
		}
	}

	public FieldCell CellRoot {
		get {
			return cellRoot;
		}
		protected set {
			if (cellRoot != null) {
				cellRoot.Car = null;
			}

			cellRoot = value;

			if (cellRoot != null) {
				cellRoot.Car = this;
			}
		}
	}

	public void DirectionVector(Direction direction, out int x, out int y) {
		switch (direction) {
		case Direction.Up:
			x = 0;
			y = 1;
			break;
		case Direction.Right:
			x = 1;
			y = 0;
			break;
		case Direction.Down:
			x = 0;
			y = -1;
			break;
		case Direction.Left:
			x = -1;
			y = 0;
			break;
		default:
			x = y = 0;
			break;
		}
	}

	public virtual Car SetPosition(int x, int y, Direction direction) {
		this.x = x;
		this.y = y;
		this.direction = direction;
		DirectionVector(direction, out directionX, out directionY);

		CellRoot = Field.Instance.GetCell(x, y);

		return this;
    }

	protected bool VerifyDirection(ref int dirX, ref int dirY) {
		if (dirX < -1) {
			dirX = -1;
		}
		if (dirX > 1) {
			dirX = 1;
		}
		if (dirY < -1) {
			dirY = -1;
		}
		if (dirY > 1) {
			dirY = 1;
		}

		if (direction == Direction.Any) {
			return true;
		}

		if (Mathf.Abs(directionX) != Mathf.Abs(dirX) || Mathf.Abs(directionY) != Mathf.Abs(dirY)) {
			return false;
		}

		return true;
    }

	public virtual bool Move(int dirX, int dirY) {
		if (!VerifyDirection(ref dirX, ref dirY)) {
			return false;
		}

		bool result = false;

		int newX = x + dirX;
		int newY = y + dirY;

		FieldCell newCellRoot = Field.Instance.GetCell(newX, newY);

		if (newCellRoot != null && (newCellRoot.IsFree || newCellRoot.Car == this)) {
			result = true;
			CellRoot = newCellRoot;

			x = newX;
			y = newY;
		}

		return result;
	}
}
