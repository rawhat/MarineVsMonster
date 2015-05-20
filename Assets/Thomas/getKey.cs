using UnityEngine;
using System.Collections;

public class getKey : MonoBehaviour {

	public static int numOfKeys = 0;
	public GameObject key;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		}

		void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.tag == "key")
			{
			numOfKeys = numOfKeys + 1;
			Destroy (key);
			Debug.Log("number of keys = " + numOfKeys);
			}
		}
	
	}

