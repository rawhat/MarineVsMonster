using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	TerminalController[] terminals;

	private GameObject player;
	private PlayerHealth playerHealth;
	private UIController uiController;
	private bool isOver = false;
	private EnemyAI monsterAI;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		monsterAI = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyAI> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		uiController = GameObject.FindObjectOfType<UIController> ();
		terminals = (TerminalController[]) GameObject.FindObjectsOfType (typeof(TerminalController));

	}

	void Update () {
		if (uiController.getSecondsRemaining () == 0 || playerHealth.isDead) {
			GameOver(false);
			return;
		}
		foreach(TerminalController term in terminals){
			if(!term.getActivationStatus()){
				return;
			}
		}
		GameOver (true);
	}

	void GameOver(bool playerWin){
		isOver = true;
		monsterAI.gameOver = true;
		uiController.ShowGameOverText (playerWin);
	}

	public bool isGameOver(){
		return isOver;
	}
}
