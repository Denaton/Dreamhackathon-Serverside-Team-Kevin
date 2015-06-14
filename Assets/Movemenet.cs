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
		Screen.autorotateToPortrait = true;
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
		return Generator.map[x][y].transform.GetComponent<Tile>().solid;
	}

	void Move (int x, int y) {
		if (canMove) {
			if(!CheckSolid(Mathf.FloorToInt(transform.position.x+x),Mathf.FloorToInt(transform.position.y+y))){
				Vector3 Movement = transform.position;
				Movement.x += x;
				Movement.y += y;
				transform.position = Movement;
				canMove = false;
			}
		} else if (countDown()) {
			canMove = true;
		}
	}

	// Update is called once per frame
	void Update () {
		Screen.orientation = ScreenOrientation.Portrait;
		// Movement
		//Vector3 Movement = transform.position;
		Debug.Log (gyro.gravity);
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
		if (gyro.gravity.x >= 0.7) {
			//Movement.x += 1;
			Move (1,0);
		}
		else if (gyro.gravity.x <= -0.7) {
			//Movement.x -= 1;
			Move (-1,0);
		}
		else if (gyro.gravity.y >= 0.7) {
			//Movement.y += 1;
			Move (0,1);
		}
		else if (gyro.gravity.y <= -0.7) {
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
