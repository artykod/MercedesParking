
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

	public FieldCell(int index, int x, int y, bool target, bool blocked) {
		Index = index;
		FieldX = x;
		FieldY = y;
		IsTarget = target;
		IsBlocked = blocked;
    }
}
