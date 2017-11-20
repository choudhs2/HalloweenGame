using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;

	public float speed;
	public float offset;
	public Rigidbody rb;
	public GameObject fridge;
	public int Hitpoints;
	public int Unlockpoints;


	public void SetLocation (MazeCell cell) {
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;

	}

	private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
	}
	
	private void FixedUpdate () {
		if(Input.GetKey(KeyCode.R)){
			fridge = GameObject.FindGameObjectWithTag ("Fridge");
			rb = fridge.GetComponent<Rigidbody> ();
		}
		if (Input.GetKey(KeyCode.W)) {
			//transform.Translate (Vector3.forward * speed * Time.deltaTime);
			//Move(MazeDirection.North);
			rb.AddForce(transform.forward * speed);
		}
		else if (Input.GetKey(KeyCode.D)) {
			//transform.Translate (Vector3.right * speed * Time.deltaTime);
			//Move(MazeDirection.East);
			rb.AddForce(transform.right * speed);
		}
		else if (Input.GetKey(KeyCode.S)) {
			//transform.Translate (Vector3.back * speed * Time.deltaTime);
			//Move(MazeDirection.South);
			rb.AddForce(transform.forward * speed *-1f);
		}
		else if (Input.GetKey(KeyCode.A)) {
			//transform.Translate (Vector3.left * speed * Time.deltaTime);
			//Move(MazeDirection.West);
			rb.AddForce(transform.right * -1f * speed);
		}

		if (Hitpoints <= 0) {
			Destroy(GameObject.FindGameObjectWithTag("Fridge"));
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Enemy1")) {
			Hitpoints -= 10;
		}
		if (other.gameObject.CompareTag ("Enemy2")) {
			Hitpoints -= 20;
		}
		if (other.gameObject.CompareTag ("Enemy3")) {
			Hitpoints -= 30;
		}
		if (other.gameObject.CompareTag ("Health")) {
			Hitpoints += 10;
			Destroy (other);
		}
		if (other.gameObject.CompareTag ("Boss1") || other.gameObject.CompareTag ("Boss2") || other.gameObject.CompareTag ("Boss3")) {
			Hitpoints -= 50;
		}
		if (other.gameObject.CompareTag ("Unlock")) {
			Unlockpoints++;
		}
		if (other.gameObject.CompareTag ("Wall")) {
			rb.velocity = Vector3.zero;
		}
	}
}
