using UnityEngine;
using System.Collections.Generic;

public class ParkingCellVisual : MonoBehaviour {
	[SerializeField]
	private LineRenderer line = null;
	[SerializeField]
	private GameObject textP = null;
	[SerializeField]
	private GameObject textEnter = null;

	[SerializeField]
	private GameObject[] borderSprites = null;

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

		textEnter.gameObject.SetActive(cell.FieldX == 9 && cell.FieldY == 2);

		allCells[this.cell] = this;

		FieldCell.FieldSide side = cell.SideInField;
		if ((side & FieldCell.FieldSide.Left) != 0) {
			borderSprites[0].SetActive(true);
        }
		if ((side & FieldCell.FieldSide.Right) != 0) {
			borderSprites[1].SetActive(true);
		}
		if ((side & FieldCell.FieldSide.Bottom) != 0) {
			borderSprites[2].SetActive(true);
		}
		if ((side & FieldCell.FieldSide.Top) != 0) {
			borderSprites[3].SetActive(true);
		}
		
		bool isParkingEnter = (side & FieldCell.FieldSide.Top) != 0 && (side & FieldCell.FieldSide.Bottom) != 0;

		if (!isParkingEnter) {
			for (int i = 0; i < 4; i++) {
				line = Instantiate(line);
				line.transform.SetParent(transform, false);
				line.transform.localPosition = new Vector3(0f, 0f, -0.00001f);
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
	}

	private void Awake() {
		Renderer renderer = GetComponentInChildren<Renderer>();

		Width = renderer.bounds.size.x;
		Height = renderer.bounds.size.y;

		foreach (var i in borderSprites) {
			i.SetActive(false);
		}
	}

	private void OnDestroy() {
		if (cell != null) {
			allCells.Remove(cell);
		}
	}
}
