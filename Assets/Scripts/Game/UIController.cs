using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	
	private PlayerController playerScript;
	private TerminalController[] terminalScript;
	private GameController gameController;
	private PlayerHealth playerHealth;

	private GameObject activationBarObj;
	public Slider activationBar;
	public Image activationSliderImage;
	private Slider endBar;
	private Text activationText;
	private Text gameOverText;
	public Text gameClock;
	private RawImage playerHurt;

	public float playerEndurance;
	private float timeLeftInSeconds;
	
	void Start(){
		playerScript = FindObjectOfType<PlayerController>();
		gameController = FindObjectOfType<GameController> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();

		endBar = GameObject.Find("EnduranceSlider").GetComponent<Slider> ();
		activationBarObj = GameObject.Find ("ActivationSlider").gameObject;
		activationBar = activationBarObj.GetComponent<Slider> ();

		activationText = GameObject.Find ("ActivateText").GetComponent<Text> ();
		gameOverText = GameObject.Find ("GameOverText").GetComponent<Text> ();

		playerHurt = this.GetComponent<RawImage> ();

		activationBarObj.SetActive (false);
		activationText.enabled = false;
		gameOverText.enabled = false;
		playerHurt.enabled = false;

		timeLeftInSeconds = 1.1f * 60f;
	}

	void Update () {
		if (playerHealth.isHurt)
			playerHurt.enabled = true;
		else
			playerHurt.enabled = false;

		if (!gameController.isGameOver ()) {
			timeLeftInSeconds -= Time.deltaTime;
			int minutes = ((int)timeLeftInSeconds) / 60;
			int seconds = ((int)timeLeftInSeconds % 60);

			if (timeLeftInSeconds >= 0) {
				if(timeLeftInSeconds <= 60){
					gameClock.color = Color.red;
				}
				gameClock.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
			} else {
				GameObject.Find ("ClockPanel").GetComponent<Image> ().color = Color.red;
			}
		}
		endBar.value = playerScript.endurance;
	}

	public void ShowActivationText(){
		activationText.enabled = true;
	}

	public void HideActivationText(){
		activationText.enabled = false;
	}

	public void ShowActivationBar(){
		activationBarObj.SetActive (true);
	}

	public void HideActivationBar(){
		activationBarObj.SetActive (false);
	}

	public void ShowGameOverText(bool playerWon){
		if (playerWon)
			gameOverText.text = "You win!";
		gameOverText.enabled = true;
	}

	public void HideGameOverText(){
		gameOverText.enabled = false;
	}

	public int getSecondsRemaining(){
		return (int)timeLeftInSeconds;
	}
}
