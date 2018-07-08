using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	public GameObject target;
	public float health = 3f;
	public void takedamage(float amount){
		health -= amount;
		if (health <= 0) {
			die ();
		}
	
	}
	void die(){
		Destroy (target);
	}


	

}
