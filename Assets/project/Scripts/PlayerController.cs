using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float lookSensitivity = 3f;
	public Camera cam;
	public float currentCamX=0f;
	public float cameraRotationLimit;
	public float fireRate=11.623f;
	public float recoil;
	public bool addrecoil=false;
	private float nextTimeToFire=0f;


	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time >= nextTimeToFire) {
			nextTimeToFire = Time.time + 1f / fireRate;
			addrecoil = true;
		} else {
			addrecoil = false;
		}






		float yRot = Input.GetAxisRaw ("Mouse X");
		float xRot = Input.GetAxisRaw ("Mouse Y");
		if (addrecoil) {
			currentCamX -= recoil;
		}
		currentCamX -= xRot;
		currentCamX = Mathf.Clamp (currentCamX, -cameraRotationLimit, cameraRotationLimit);
		Vector3 rotation1 = new Vector3 (0, yRot, 0) * lookSensitivity;
		Vector3 rotation2 = new Vector3 (currentCamX, 0, 0) * lookSensitivity;

		gameObject.transform.Rotate (rotation1);
		cam.transform.localEulerAngles=rotation2;
	}
}
