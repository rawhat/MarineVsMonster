using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public MovieTexture backgroundMovie;

	void Start () {
		GetComponent<Renderer> ().material.mainTexture = backgroundMovie;
		backgroundMovie.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
