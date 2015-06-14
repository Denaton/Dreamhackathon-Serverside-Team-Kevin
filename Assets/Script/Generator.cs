using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public Transform Tiles;
	public Vector2 size;
	public static GameObject[][] map;
	Camera camera;
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
		for (int x = 0; x < size.x; x++) {
			for (int y = 0; y < size.y; y++) {
				map[x][y] = Instantiate(Tiles, new Vector3(x,y,0), Quaternion.identity) as GameObject;
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
			Vector3 screenPos = camera.WorldToScreenPoint(players[i].transform.position);
			GUI.Box(new Rect(screenPos.x-32, Screen.height - screenPos.y - 64, 64, 64), "","HealthBar");
			GUI.BeginGroup(new Rect(screenPos.x-32, Screen.height - screenPos.y - 64, 64*(players[i].GetComponent<Stats>().currentLife/players[i].GetComponent<Stats>().maxLife), 64));
			GUI.Box(new Rect(0, 0, 64, 64), "","HealthBarBackground");
			GUI.EndGroup();
			GUI.Label (new Rect (screenPos.x-32, Screen.height - screenPos.y - 64, 64, 64), Mathf.Floor((players[i].GetComponent<Stats>().currentLife/players[i].GetComponent<Stats>().maxLife)*100).ToString() + "%","LabelCenter");
		}
	}
}
