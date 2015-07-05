using UnityEngine;
using System.Collections.Generic;

public class ParkingCellVisual : MonoBehaviour {
	[SerializeField]
	private LineRenderer line = null;
	[SerializeField]
	private GameObject textP = null;

	private FieldCell cell = null;

	private static Dictionary<FieldCell, ParkingCellVisual> allCells = new Dictionary<FieldCell, ParkingCellVisual>();

	public FieldCell Cell {
		get {
			return cell;
		}
	}

	public float Width {
		get;
		private set;
	}
	public float Height {
		get;
		private set;
	}
	
	public static ParkingCellVisual GetCellVisual(FieldCell cell) {
		ParkingCellVisual visual = null;
		if (cell != null) {
			allCells.TryGetValue(cell, out visual);
		}
		return visual;
    }

	public void Setup(FieldCell cell) {
		if (this.cell != null) {
			allCells.Remove(this.cell);
        }

		this.cell = cell;

		textP.gameObject.SetActive(cell.IsTarget);

		allCells[this.cell] = this;
	}

	private void Awake() {
		Width = GetComponent<SpriteRenderer>().bounds.size.x;
		Height = GetComponent<SpriteRenderer>().bounds.size.y;

		for (int i = 0; i < 4; i++) {
			line = Instantiate(line);
			line.transform.SetParent(transform, false);
			line.transform.localPosition = new Vector3(0f, 0f, -1f);
			line.SetVertexCount(2);
			switch (i) {
			case 0:
				line.SetPosition(0, new Vector3(-1f, 1f));
				line.SetPosition(1, new Vector3(1f, 1f));
				break;
			case 1:
				line.SetPosition(0, new Vector3(1f, 1f));
				line.SetPosition(1, new Vector3(1f, -1f));
				break;
			case 2:
				line.SetPosition(0, new Vector3(1f, -1f));
				line.SetPosition(1, new Vector3(-1f, -1f));
				break;
			case 3:
				line.SetPosition(0, new Vector3(-1f, -1f));
				line.SetPosition(1, new Vector3(-1f, 1f));
				break;
			}
			Vector3 scale = transform.localScale;
			scale.x = 1f / scale.x * 0.7f;
			scale.y = 1f / scale.y * 0.7f;
			line.transform.localScale = scale;
		}
	}

	private void OnDestroy() {
		if (cell != null) {
			allCells.Remove(cell);
		}
	}
}
