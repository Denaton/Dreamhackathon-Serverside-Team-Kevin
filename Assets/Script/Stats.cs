using UnityEngine;
using System.Collections;


public class Stats : MonoBehaviour {

	public string username = "";
	public Classes Class;
	public float maxLife = 0;
	public float currentLife = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public GUISkin skin;
	void OnGUI(){
		if(Class == Classes.Boss){
			GUI.skin = skin;
			GUI.Box(new Rect((Screen.width-200)/2, 0, 200, 40), "","HealthBar");
			GUI.BeginGroup(new Rect((Screen.width-200)/2,0, 200*(currentLife/maxLife), 40));
				GUI.Box(new Rect(0, 0, 200, 40), "","HealthBarBackground");
			GUI.EndGroup();
			GUI.Label (new Rect ((Screen.width-200)/2, 0, 200, 40), Mathf.Floor((currentLife/maxLife)*100).ToString() + "%","LabelCenter");
		}
	}

	public void dealtDamage(int dmg, string dealer){
		currentLife -= dmg;
		Debug.Log ("Dealt Damage by " + dealer);
	}
}

public enum Classes
{
	Melee,
	Range,
	Boss
}