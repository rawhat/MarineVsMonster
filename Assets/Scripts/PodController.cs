using UnityEngine.UI;
using System.Collections;
using UnityEngine;
public class PodController : MonoBehaviour {

	public Light activationStatus;
	private Text accomplishedText;
	public Camera podCam;
	public Animation podAnimation;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		podCam.enabled = false;
		//anim = GetComponent<Animation> ();
		gameController = GameObject.FindObjectOfType<GameController> ();
		activationStatus.color = Color.red;
		//accomplishedText = GameObject.Find ("MissionAccomplishedText").GetComponent<Text> ();
		//accomplishedText.enabled = false;
		podAnimation = GameObject.Find ("pod").GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(TerminalController terminalController in GameObject.FindObjectsOfType<TerminalController>()){
			if(!terminalController.getActivationStatus())
				return;
		}
		activationStatus.color=Color.green;
	}
	void OnTriggerEnter(Collider obj){
		if (activationStatus.color == Color.green) {
			podCam.enabled=true;	
			podAnimation.Play();
			gameController.SendMessage("GameOver", true);
		}
	}

}