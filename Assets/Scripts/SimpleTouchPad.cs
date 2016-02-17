using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler {
	public float smooth;

	private Vector2 origin;
	private int pointerID;
	private Vector2 direction;
	private bool touched;
	private Vector2 smoothDirection;

	void Awake(){
		origin = Vector2.zero;
		direction = Vector2.zero;
		smoothDirection = Vector2.zero;
		touched = false;
	}


	public void OnDrag (PointerEventData eventData){
		if(pointerID == eventData.pointerId){
			direction = (eventData.position - origin).normalized;
		}
	}

	public void OnPointerDown(PointerEventData eventData){
		if(!touched){
			touched = true;
			pointerID = eventData.pointerId;
			origin = eventData.position;
		}
	}

	public void OnPointerUp(PointerEventData eventData){
		if(pointerID == eventData.pointerId){
			touched = false;
			direction = Vector2.zero;
			smoothDirection = Vector2.zero;
		}
	}

	public Vector2 GetDirection(){
		smoothDirection = Vector2.MoveTowards(smoothDirection,direction,smooth);
		return smoothDirection;
	}
}
