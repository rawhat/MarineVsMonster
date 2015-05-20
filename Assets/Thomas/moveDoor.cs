	using UnityEngine;
using System.Collections;

public class moveDoor : MonoBehaviour
{
	
		void OnTriggerEnter (Collider other)
		{
				transform.Translate (0, 2, 0);

				Debug.Log ("Open Sezame!");
		}	

		void OnTriggerExit (Collider other)
		{
		
				transform.Translate (0, -2, 0);
				Debug.Log ("Close Sezame!");
		}	
}
	

