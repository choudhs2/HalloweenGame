using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public float speed;
	public float offset;
	public Rigidbody rb;
	public GameObject enemy;


	private void FixedUpdate () {
		List<GameObject> enemies = new List<GameObject>();
		enemies.Add(GameObject.FindGameObjectWithTag ("Enemy1"));
		enemies.Add(GameObject.FindGameObjectWithTag ("Enemy2"));
		enemies.Add(GameObject.FindGameObjectWithTag ("Enemy3"));
		float minDist = 100.0f;
		foreach (GameObject obj in enemies) {
			if (Vector3.Distance (transform.position, obj.transform.position) < minDist) {
				minDist = Vector3.Distance (transform.position, obj.transform.position);
				enemy = obj;
			}
		}
		rb = enemy.GetComponent<Rigidbody> ();
		//move along walls until they see you
		GameObject player = GameObject.FindGameObjectWithTag("Fridge");
		if (Vector3.Distance (transform.position, player.transform.position) < 3) {
			transform.LookAt (player.transform);
			rb.AddForce(transform.forward * speed);	
		}
		else {
			GameObject nearestWall = GameObject.FindGameObjectWithTag("Wall");
			if (Vector3.Distance (transform.position, nearestWall.transform.position) < 1.25) {
				transform.LookAt (nearestWall.transform);
				transform.Rotate (Vector3.left * Time.deltaTime); 
				rb.AddForce(transform.forward * speed);	
			}
			else {
				transform.LookAt (nearestWall.transform);
				rb.AddForce(transform.forward * speed);	
			}
		}
	}

	void OnCollisionEnter (Collision other){
		if(other.gameObject.tag == "Wall"){
			transform.position = new Vector3(transform.position.x - offset,transform.position.y, transform.position.z - offset);
			transform.Rotate (Vector3.left * Time.deltaTime); 
		}
	}
}
