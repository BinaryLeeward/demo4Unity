using UnityEngine;
using System.Collections;

public class DestroyBoundry : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
