using UnityEngine;
using System.Collections;

public class RotatePlanets : MonoBehaviour {

	public GameObject leftPlanet;
	public GameObject rightPlanet;

	public float rotSpeed = 1f;

	void Awake(){
		AudioSource menuMusic = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
		if (!menuMusic.isPlaying)
			menuMusic.Play ();
		DontDestroyOnLoad (menuMusic);
	}

	void Update () {
		leftPlanet.transform.Rotate (Vector3.up, Time.deltaTime * rotSpeed * 2, Space.Self);
		rightPlanet.transform.Rotate (Vector3.up, Time.deltaTime * rotSpeed, Space.Self);
	}

}
