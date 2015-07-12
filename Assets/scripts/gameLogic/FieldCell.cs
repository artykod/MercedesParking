
public class FieldCell {
	public Car Car {
		get;
		set;
	}

	public bool IsTarget {
		get;
		private set;
	}

	public bool IsBlocked {
		get;
		private set;
	}

	public int Index {
		get;
		private set;
	}

	public int FieldX {
		get;
		private set;
	}

	public int FieldY {
		get;
		private set;
	}

	public bool IsFree {
		get {
			return Car == null && !IsBlocked;
		}
	}

	[System.Flags]
	public enum FieldSide {
		Left = 1,
		Right = 2,
		Top = 4,
		Bottom = 8,
	}

	public FieldSide SideInField {
		get;
		private set;
	}
	
	public void SetClosestCells(FieldCell leftCell, FieldCell rightCell, FieldCell topCell, FieldCell bottomCell) {
		if (leftCell != null && leftCell.IsBlocked) {
			SideInField |= FieldSide.Left;
		}
		if (rightCell != null && rightCell.IsBlocked) {
			SideInField |= FieldSide.Right;
		}
		if (topCell != null && topCell.IsBlocked) {
			SideInField |= FieldSide.Top;
		}
		if (bottomCell != null && bottomCell.IsBlocked) {
			SideInField |= FieldSide.Bottom;
		}
	}

	public FieldCell(Field field, int index, int x, int y, bool target, bool blocked) {
		Index = index;
		FieldX = x;
		FieldY = y;
		IsTarget = target;
		IsBlocked = blocked;

		if (x == 0) {
			SideInField |= FieldSide.Left;
		}
		if (x == field.FieldCellsCountX - 1) {
			SideInField |= FieldSide.Right;
		}
		if (y == 0) {
			SideInField |= FieldSide.Bottom;
		}
		if (y == field.FieldCellsCountY - 1) {
			SideInField |= FieldSide.Top;
		}
	}
}
