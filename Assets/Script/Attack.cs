using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : MonoBehaviour {
	public int myRange = 0;
	bool selectedAttack = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.W)){
			List<GameObject> targets = GetTargets(myRange);
			foreach (GameObject target in targets) {
				Debug.Log (target.name);
				target.GetComponent<Stats>().dealtDamage(1,transform.GetComponent<Stats>().username);
			}
		}
	}

	// Send in range and get all GameObject in a list back thats are in that range.
	public List<GameObject> GetTargets(int range){
		GameObject[] objs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		List<GameObject> targets = new List<GameObject>();
		foreach(GameObject obj in objs){
			if((obj.transform.position - transform.position).magnitude <= range){ // Only those in range
				if(obj.tag == "Unit"){ // Only Object with tag Unit
					if(obj.transform != transform){ // Exlude your self.
						targets.Add(obj);
					}
				}
			}
		}
		return targets;
	}

	void OnGUI(){
		List<GameObject> targets = GetTargets(myRange);
		for (int i = 0; i < targets.Count; i++) {
			GUI.Button(new Rect(0,40*i,200,40),targets[i].GetComponent<Stats>().username);
		}
	}
}
