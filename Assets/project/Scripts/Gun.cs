using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public float damage = 1f;
	public float range = 1000f;
	public Camera fpsCam;
	public float fireRate=15f;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
	public GameObject GunShot;


	private float nextTimeToFire=0f;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")&& Time.time>=nextTimeToFire) {
			nextTimeToFire = Time.time + 1f / fireRate;
			shoot ();
		}
		
	}

	void shoot(){
		muzzleFlash.Play();
		GameObject gunShot = Instantiate (GunShot, this.transform.position,this.transform.rotation) as GameObject;
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit)) {
			Target target=hit.transform.GetComponent<Target> ();
			if (target != null) {
				target.takedamage (damage);
			}

			GameObject impact=Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impact, 0.5f);
		}
	}


}
