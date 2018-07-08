using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {
	public Animator animator;
	public GameObject scopeOverlay;
	public GameObject weaponCam;
	public Camera maincam;

	private bool isScoped=false;
	public float scopedFOV = 15f;
	private float normalFOV = 60f;

	void Update(){
		if (Input.GetButtonDown ("Fire2")) {
			isScoped = !isScoped;
			animator.SetBool ("Scoped", isScoped);
			if (isScoped) {
				StartCoroutine (OnScoped());
			} else {
				OnUnScoped ();
			}
		}
			
	}

	void OnUnScoped(){
		scopeOverlay.SetActive (false);
		weaponCam.SetActive (true);
		maincam.fieldOfView = normalFOV;

	}

	IEnumerator OnScoped(){
		yield return new WaitForSeconds (0.11f);
		weaponCam.SetActive (false);
		scopeOverlay.SetActive (true);
		maincam.fieldOfView = scopedFOV;

	}

}
