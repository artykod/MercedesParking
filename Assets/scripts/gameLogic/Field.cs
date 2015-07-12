using System.Collections.Generic;

public class Field {
	private static Field instance = null;
	public static Field Instance {
		get {
			if (instance == null) {
				instance = new Field();
			}
			return instance;
		}
	}

	private List<FieldCell> cells = new List<FieldCell>(100);
	private List<Car> cars = new List<Car>(10);

	public int FieldCellsCountX {
		get;
		private set;
	}
	public int FieldCellsCountY {
		get;
		private set;
	}
	public List<FieldCell> Cells {
		get {
			return cells;
		}
	}
	public List<Car> Cars {
		get {
			return cars;
		}
	}

	public static void Generate(int x, int y) {
		Instance.Build(x, y);
	}

	public FieldCell GetCell(int x, int y) {
		int index = y * FieldCellsCountX + x;
		if (index >= cells.Count || index < 0) {
			return null;
		}
        return cells[index];
	}

	private void Build(int sizeX, int sizeY) {
		FieldCellsCountX = sizeX;
		FieldCellsCountY = sizeY;

		cells.Clear();
		for (int y = 0; y < sizeY; y++) {
			for (int x = 0; x < sizeX; x++) {
				FieldCell cell = new FieldCell(y * sizeX + x, x, y, x == 0 && y == sizeY / 2, y != sizeY / 2 && x >= sizeX - 4);
				cells.Add(cell);
			}
		}

		cars.Clear();

		cars.Add(new FieldCar().SetPosition(0, 0, Car.Direction.Up));
		cars.Add(new FieldCar().SetPosition(1, 1, Car.Direction.Up));
		cars.Add(new FieldCar().SetPosition(2, 3, Car.Direction.Down));
		cars.Add(new FieldCar().SetPosition(3, 1, Car.Direction.Up));
		cars.Add(new FieldCar().SetPosition(4, 0, Car.Direction.Up));
		cars.Add(new FieldCar().SetPosition(5, 1, Car.Direction.Up));
		cars.Add(new FieldCar().SetPosition(6, 3, Car.Direction.Down));
		cars.Add(new FieldCar().SetPosition(7, 1, Car.Direction.Up));
		cars.Add(new FieldCar().SetPosition(8, 0, Car.Direction.Up));
		cars.Add(new FieldCar().SetPosition(2, 4, Car.Direction.Right));
		cars.Add(new FieldCar().SetPosition(6, 4, Car.Direction.Left));

		// player 
		cars.Add(new PlayerCar().SetPosition(sizeX - 2, sizeY / 2, Car.Direction.Left));
	}
}
