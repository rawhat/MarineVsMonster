using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class accomplished_Text : MonoBehaviour {

void ShowText(){
		GameObject.Find ("MissionAccomplishedText").GetComponent<Text> ().enabled = true;
	}
}
