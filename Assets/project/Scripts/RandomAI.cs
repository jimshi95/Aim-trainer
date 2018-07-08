using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : MonoBehaviour {
	public GameObject target;
	public GameObject player;


	void Update(){
		if(GameObject.Find("Target(Clone)")==null){
			Vector3 randomposition = new Vector3 (Random.Range (0, 900), 0, Random.Range (0, 900));
			GameObject targetAI=Instantiate (target,randomposition,Quaternion.LookRotation(player.transform.position-randomposition));
			targetAI.transform.Rotate (-90, 180, 0);
		}
	}


}
