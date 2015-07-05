using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIFieldTouchListener : MonoBehaviour, IEndDragHandler, IPointerDownHandler {

	void IEndDragHandler.OnEndDrag(PointerEventData eventData) {
		//Debug.Log(eventData.delta);
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
		//Debug.Log(eventData.position);
	}
}
