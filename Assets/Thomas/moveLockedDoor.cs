using UnityEngine;
using System.Collections;

public class moveLockedDoor : MonoBehaviour
{
	public GameObject lockedDoor;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "lockedDoor" && getKey.numOfKeys > 0) {
						getKey.numOfKeys = getKey.numOfKeys - 1;
						Destroy (lockedDoor);
						Debug.Log ("number of keys = " + getKey.numOfKeys);

						transform.Translate (0, 3, 0);
		
						Debug.Log ("Open Sezame!");
				}
	}	
	
	void OnTriggerExit (Collider other)
	{
		
		transform.Translate (0, -3, 0);
		Debug.Log ("Close Sezame!");
	}	
}

