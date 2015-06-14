using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public bool solid = false;
	public Sprite[] ground;
	public Sprite[] water;
	public Sprite[] stone;

	// Use this for initialization
	void Start () {
		if (Random.value < 0.1) { // 10% Chance to be water
			transform.GetComponent<SpriteRenderer>().sprite = stone [Random.Range (0, water.Length)];
			transform.Rotate(Vector3.forward*(Random.Range(0,4)*90));
			solid = true;
		}
		else {
			transform.GetComponent<SpriteRenderer>().sprite = ground [Random.Range (0, ground.Length)];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
