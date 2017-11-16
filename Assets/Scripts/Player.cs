using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;

	public float speed;
	public float offset;

	public void SetLocation (MazeCell cell) {
		//currentCell = cell;
		//transform.localPosition = cell.transform.localPosition;
	}
	
	private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
	}
	
	private void FixedUpdate () {
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
			//Move(MazeDirection.North);
		}
		else if (Input.GetKey(KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			//Move(MazeDirection.East);
		}
		else if (Input.GetKey(KeyCode.S)) {
			transform.Translate (Vector3.back * speed * Time.deltaTime);
			//Move(MazeDirection.South);
		}
		else if (Input.GetKey(KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
			//Move(MazeDirection.West);
		}
	}

	void OnCollisionEnter (Collision other){
		if(other.gameObject.tag == "Wall"){
			transform.position = new Vector3(transform.position.x - offset,transform.position.y, transform.position.z - offset);
		}
	}
}
