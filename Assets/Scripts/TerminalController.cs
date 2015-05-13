using UnityEngine;
using System.Collections;

public class TerminalController : MonoBehaviour {

	private UIController uiController;
	private float activationLevel = 0f;
	private bool activated = false;
	public Light activationStatus;
	private bool attemptingActivation = false;

	void Start(){
		uiController = GameObject.FindObjectOfType<UIController> ();
		activationStatus.color = Color.red;
	}

	void Update(){
		if (activated) {
			activationStatus.color = Color.green;
		} else if (!attemptingActivation && activationLevel >= 0f){
			activationLevel -= 0.0025f;
		}
	}

	void OnTriggerEnter(Collider obj){
		if (obj.attachedRigidbody == GameObject.FindWithTag ("Player").GetComponent<Rigidbody> () && !activated) {
			uiController.ShowActivationText ();
			uiController.ShowActivationBar();
			uiController.activationBar.value = activationLevel;
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.attachedRigidbody == GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ()) {
			uiController.HideActivationText ();
			uiController.HideActivationBar();
		}
	}

	void OnTriggerStay(Collider obj){
		if (obj.attachedRigidbody == GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ()) {
			uiController.activationBar.value = activationLevel;
			if(Input.GetButton("Activate") && activated == false){
				attemptingActivation = true;
				activationLevel += 0.0025f;
				if(activationLevel >= 1f){
					activated = true;
					uiController.activationSliderImage.color = Color.green;
				}
			}
			else{
				attemptingActivation = false;
			}
		}
	}

	public bool getActivationStatus(){
		return activated;
	}
}
