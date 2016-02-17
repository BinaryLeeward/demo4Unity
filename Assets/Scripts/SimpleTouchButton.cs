using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SimpleTouchButton : MonoBehaviour, IPointerDownHandler,IPointerUpHandler {

	private int pointerID;
	private bool canFire;
	private bool touched;
	void Awake(){
		canFire = false;
		touched = false;
	}

	public	void OnPointerDown (PointerEventData eventData){
		if(!touched){
			pointerID = eventData.pointerId;
			touched = true;
			canFire = true;
		}
	}

	public	void OnPointerUp (PointerEventData eventData){
		if(pointerID == eventData.pointerId){
			canFire = false;
			touched = false;
		}
	}

	public bool CanFire(){
		return canFire;
	}
}
