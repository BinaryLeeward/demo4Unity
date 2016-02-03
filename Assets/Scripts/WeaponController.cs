using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject enemyBolt;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Fire",delay,fireRate);
	}

	void Fire(){
		audio.Play();
		Instantiate(enemyBolt,shotSpawn.position,shotSpawn.rotation);
	}
}
