using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desotry : MonoBehaviour {
	private float totalTimeofDestory;
	// Use this for initialization
	void Start () {
		var sound = this.GetComponent<AudioSource> ();
		totalTimeofDestory = sound.clip.length;

	}

	// Update is called once per frame
	void Update () {
		totalTimeofDestory -= Time.deltaTime;

		if (totalTimeofDestory <= 0f) {
			Destroy (this.gameObject);
		}
	}
}
