using UnityEngine;
using UnityEngine.EventSystems;

public class UIResetButton : MonoBehaviour, IPointerClickHandler {
	void IPointerClickHandler.OnPointerClick(PointerEventData eventData) {
		Application.LoadLevel("main");
	}
}
