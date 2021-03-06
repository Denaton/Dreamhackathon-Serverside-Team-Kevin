﻿using UnityEngine;
using System.Collections;

public class AttackTrajectory : MonoBehaviour {

	private Gyroscope gyro;
	public bool isAtackMode = false;
	// Use this for initialization
	void Start () {
		Screen.autorotateToPortrait = true;
		if (SystemInfo.supportsGyroscope) {
			gyro = Input.gyro;
			gyro.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Movemenet>().enabled = !isAtackMode;
		if (isAtackMode)
		{	
			if (gyro.enabled) {

				Vector2 AtackVector = new Vector2(gyro.gravity.x, gyro.gravity.y)*gyro.rotationRate.x/2;
				Debug.Log (AtackVector);
				DrawTraject(this.transform.position, AtackVector); 
			}
		}

	}

	void DrawTraject(Vector2 startPosition, Vector2 startVelocity){
		
		int verts = 50;
		LineRenderer line = this.gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount(verts);
		
		Vector3 pos = startPosition;
		Vector3 vel = startVelocity;
		
		for(var i = 0; i < verts; i++)
		{
			float x = pos.x + vel.x * Time.fixedDeltaTime;
			float y = pos.y + vel.y * Time.fixedDeltaTime;
			
			line.SetPosition(i, new Vector2(x,y));
			//vel=new Vector3(x,y,0.0f);
			pos = pos + vel * Time.fixedDeltaTime;
		}

		GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");
		for (int i = 0; i < boss.Length; i++) {
			if((boss[i].transform.position - pos).magnitude < 3){
				boss[i].GetComponent<Stats>().dealtDamage(5,this.transform.GetComponent<"Stats">().username);
			}
		}
		
	}
}
