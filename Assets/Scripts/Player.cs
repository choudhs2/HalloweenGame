using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;

	public float speed;
	public float offset;
	public Rigidbody rb;
	public GameObject fridge;


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
		fridge = GameObject.FindGameObjectWithTag ("Fridge");
		rb = fridge.GetComponent<Rigidbody> ();
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
	}
}
