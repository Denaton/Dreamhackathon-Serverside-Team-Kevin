using UnityEngine;
using System.Collections;

public class Movemenet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Movement
		Vector3 Movement = transform.position;
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			Movement.x += 1;
		}
		else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			Movement.x -= 1;
		}
		else if (Input.GetKeyUp(KeyCode.UpArrow)) {
			Movement.y += 1;
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow)) {
			Movement.y -= 1;
		}
		transform.position = Movement;

	}
}
