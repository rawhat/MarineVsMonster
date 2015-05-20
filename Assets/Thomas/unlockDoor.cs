using UnityEngine;
using System.Collections;

public class unlockDoor : MonoBehaviour {
	public GameObject lockedDoor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "lockedDoor" && getKey.numOfKeys > 0)
		{
			getKey.numOfKeys = getKey.numOfKeys - 1;
			Destroy (lockedDoor);
			Debug.Log("number of keys = " + getKey.numOfKeys);
		}
	}
}
