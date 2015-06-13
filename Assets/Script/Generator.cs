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
	
	public GUISkin skin;
	void OnGUI(){
		GUI.skin = skin;
		GameObject[] players = GameObject.FindGameObjectsWithTag("Unit");
		for (int i = 0; i < players.Length; i++) {
			GUI.Box(new Rect((Screen.width-200), 40*i, 200, 40*i), "","HealthBar");
			GUI.BeginGroup(new Rect((Screen.width-200),40*i, 200*(players[i].GetComponent<Stats>().currentLife/players[i].GetComponent<Stats>().maxLife), 40));
			GUI.Box(new Rect(0, 0, 200, 40), "","HealthBarBackground");
			GUI.EndGroup();
			GUI.Label (new Rect ((Screen.width-200), 40*i, 200, 40), Mathf.Floor((players[i].GetComponent<Stats>().currentLife/players[i].GetComponent<Stats>().maxLife)*100).ToString() + "%","LabelCenter");
		}
	}
}
