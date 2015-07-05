using UnityEngine;

public class PlayerCar : Car {
	public override CarType Type {
		get {
			return CarType.Player;
		}
	}

	public override bool Move(int dirX, int dirY) {
		bool result = base.Move(dirX, dirY);

		if (CellRoot.IsTarget) {
			Debug.Log("Game done");
			GameCore.WinGame();
		}

		return result;
	}
}
