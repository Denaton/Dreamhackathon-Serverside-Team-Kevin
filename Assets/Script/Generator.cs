using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public Transform Tiles;
	public Vector2 size;
	// Use this for initialization
	void Start () {
		for (int x = 0; x < size.x; x++) {
			for (int y = 0; y < size.y; y++) {
				Instantiate(Tiles, new Vector3(x,y,0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
