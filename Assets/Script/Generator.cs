using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public GameObject Tiles;
	// Use this for initialization
	void Start () {
		for (int x = 0; x < 10; x++) {
			for (int y = 0; y < 10; y++) {
				Instantiate(Tiles,Vector3(x,y,0),Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
