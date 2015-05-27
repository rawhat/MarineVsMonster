using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	
	private PlayerController playerScript;
	private TerminalController[] terminalScript;
	private GameController gameController;
	private PlayerHealth playerHealth;
	private MyMouseLook playerLook;

	private GameObject activationBarObj;
	public Slider activationBar;
	public Image activationSliderImage;
	private Slider endBar;
	private Text activationText;
	private Text gameOverText;
	public Text gameClock;
	private RawImage playerHurt;
	private GameObject restartLevel;
	private GameObject quitToMenu;
	private Text numOfTerminals;
	private int numTerms;
	private int activeTerminals = 0;

	public float gameDurationMinutes = 5f;

	public float playerEndurance;
	private float timeLeftInSeconds;

	private bool menuShowing = false;
	
	void Start(){
		playerScript = FindObjectOfType<PlayerController>();
		gameController = FindObjectOfType<GameController> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		playerLook = Camera.main.GetComponent<MyMouseLook> ();

		endBar = GameObject.Find("EnduranceSlider").GetComponent<Slider> ();
		activationBarObj = GameObject.Find ("ActivationSlider").gameObject;
		activationBar = activationBarObj.GetComponent<Slider> ();

		activationText = GameObject.Find ("ActivateText").GetComponent<Text> ();
		gameOverText = GameObject.Find ("GameOverText").GetComponent<Text> ();

		GameObject[] buttonGroup = GameObject.FindGameObjectsWithTag ("UIButton");
		restartLevel = buttonGroup [0];
		quitToMenu = buttonGroup [1];

		restartLevel.SetActive (false);
		quitToMenu.SetActive (false);

		playerHurt = this.GetComponent<RawImage> ();

		activationBarObj.SetActive (false);
		activationText.enabled = false;
		gameOverText.enabled = false;
		playerHurt.enabled = false;

		numOfTerminals = GameObject.Find ("NumTerminals").GetComponent<Text> ();

		timeLeftInSeconds = gameDurationMinutes * 60;
	}

	void Update () {
		if (!menuShowing && Input.GetButtonDown("Menu")) {
			ShowMenuButtons ();
			menuShowing = true;
		} else if (menuShowing && Input.GetButtonDown ("Menu")) {
			HideMenuButtons ();
			menuShowing = false;
		}

		if (playerHealth.isHurt)
			playerHurt.enabled = true;
		else
			playerHurt.enabled = false;

		if (!gameController.isGameOver ()) {
			if(activeTerminals == numTerms)
				numOfTerminals.color = Color.green;
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

	public void ShowMenuButtons(){
		playerLook.enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		restartLevel.SetActive(true);
		quitToMenu.SetActive(true);
	}

	public void HideMenuButtons(){
		playerLook.enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		restartLevel.SetActive(false);
		quitToMenu.SetActive(false);
	}

	public int getSecondsRemaining(){
		return (int)timeLeftInSeconds;
	}

	void SetTerminals(int totalTerminals){
		numTerms = totalTerminals;
	}

	void ActivateTerminal(){
		activeTerminals += 1;
		numOfTerminals.text = activeTerminals.ToString() + " of " + numTerms.ToString ();
	}
}
