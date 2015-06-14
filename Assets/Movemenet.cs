using UnityEngine;
using System.Collections;

public class Movemenet : MonoBehaviour {

	int MovementSpeed = 10;
	private Gyroscope gyro;
	public bool canMove = false;
	public float time = 0f;
	public bool cooldown = false;
	float currentTimer = 0;
	// Use this for initialization
	void Start () { 
		if (SystemInfo.supportsGyroscope) {
			gyro = Input.gyro;
			gyro.enabled = true;
		}
	}

	void startTimer(){
		currentTimer = time;
	}

	public bool countDown(){
		if (currentTimer > 0) {
			currentTimer -= Time.deltaTime;
			return false;
		} else {
			return true;
		}
	}

	public bool CheckSolid(int x, int y){
		if (x >= 0 && y >= 0 && x <= 10 && y <= 10 ) { 
			Debug.Log (Generator.map [x] [y].GetComponent<Tile> ().solid);
			return Generator.map [x] [y].GetComponent<Tile> ().solid;
		} else
			return true;
	}

	void Move (int x, int y) {
		
		if (!CheckSolid (Mathf.RoundToInt (transform.position.x + x), Mathf.RoundToInt (transform.position.y + y)) || transform.GetComponent<AttackTrajectory>().isAtackMode) {
			Debug.Log(Mathf.RoundToInt (transform.position.x + x));
			if (canMove) {
				Vector3 Movement = transform.position;
				Movement.x += x;
				Movement.y += y;
				transform.position = Movement;
				canMove = false;
				Debug.Log ("Moved");
			} 
		} else 
			Debug.Log ("Unable to move");
	}

	// Update is called once per frame
	void Update () { 
		// Movement
		//Vector3 Movement = transform.position;
		if (countDown ()) {
			canMove = true;
			cooldown = false;
		}
		if (canMove) {
			if(!cooldown) {
				startTimer();
				cooldown = true;
			}
		}
		if (gyro.gravity.x >= 0.5) {
			//Movement.x += 1;
			Move (1,0);
		}
		else if (gyro.gravity.x <= -0.5) {
			//Movement.x -= 1;
			Move (-1,0);
		}
		else if (gyro.gravity.y >= 0.5) {
			//Movement.y += 1;
			Move (0,1);
		}
		else if (gyro.gravity.y <= -0.5) {
			//Movement.y -= 1;
			Move (0,-1);
		}
		//transform.position = Movement;

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
