using UnityEngine;
using System.Collections;

public class DestoryContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerExit(Collider other) {
		if(other.tag == "Boundry"){
			return;
		}
		Instantiate (explosion,transform.position,transform.rotation);
		if(other.tag == "Player"){
			Instantiate(playerExplosion,transform.position,transform.rotation);
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
