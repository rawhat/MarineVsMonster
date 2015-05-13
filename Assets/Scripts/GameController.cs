using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	TerminalController[] terminals;

	private UIController uiController;
	private bool isOver;

	void Start () {
		uiController = GameObject.FindObjectOfType<UIController> ();
		terminals = (TerminalController[]) GameObject.FindObjectsOfType (typeof(TerminalController));
	}

	void Update () {
		if (uiController.getSecondsRemaining () == 0) {
			GameOver();
			return;
		}
		foreach(TerminalController term in terminals){
			if(!term.getActivationStatus()){
				return;
			}
		}
		GameOver ();
	}

	void GameOver(){
		isOver = true;
		uiController.ShowGameOverText ();
	}

	public bool isGameOver(){
		return isOver;
	}
}
