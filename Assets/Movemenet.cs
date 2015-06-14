using UnityEngine;
using System.Collections;

public class Movemenet : MonoBehaviour {

	int MovementSpeed = 10;
	private Gyroscope gyro;
	// Use this for initialization
	void Start () {
		if (SystemInfo.supportsGyroscope) {
			gyro = Input.gyro;
			gyro.enabled = true;
		}
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

	void FixedUpdate()
	{
		if (gyro!=null&&gyro.enabled) 
		{	
			Vector3 movement=new Vector3(gyro.gravity.x, 0.0f, gyro.gravity.y);

			//spin (for later use)
			float spin = gyro.rotationRateUnbiased.x;
		}
	}
}
