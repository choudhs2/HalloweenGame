using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject item;
	public string stuff;
	//public int candy;
	//public Player fridge;

	void Spawn(){
		GameObject obj = Instantiate (item);
		obj.tag = stuff;
		obj.transform.position = transform.position;
	}

	void Start(){
		//fridge = (Player)GameObject.FindGameObjectWithTag ("Fridge");
		//if (fridge.Unlockpoints >= candy) {
			Spawn ();
		//}
	}

	void Update(){
		//if (fridge.Unlockpoints >= candy) {
			if (GameObject.FindGameObjectsWithTag (stuff).Length == 0) {
				Spawn ();
			}
		//}
	}
}
