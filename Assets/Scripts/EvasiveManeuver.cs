using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {
	
	public Vector2 maneuverTime;
	public float dodge;
	public Boundary boundary;

	private float targetManeuver;

	void Start(){
		StartCoroutine(Evade());
	}

	IEnumerator Evade(){
		yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));
		while(true){
			targetManeuver = Random.Range(1,dodge)* -Mathf.Sign(transform.position.x);
			yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));
		}
	}
	
	void FixedUpdate () {
		rigidbody.velocity = new Vector3(targetManeuver,0.0f,rigidbody.velocity.z);
		rigidbody.position = new Vector3(
			Mathf.Clamp(transform.position.x,boundary.xMin,boundary.xMax),
			0.0f,			
			Mathf.Clamp(transform.position.z,boundary.zMin,boundary.zMax)
		);
	}
}
