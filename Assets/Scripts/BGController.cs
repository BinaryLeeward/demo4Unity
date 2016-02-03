using UnityEngine;
using System.Collections;

public class BGController : MonoBehaviour {
	public float scrollSpeed;
	public float tiltz;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time*scrollSpeed,tiltz);
//		Debug.Log(Time.time*scrollSpeed);
//		Debug.Log(newPosition);
		transform.position = startPosition+Vector3.forward*(-newPosition);
	}
}
