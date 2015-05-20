using UnityEngine;
using System.Collections;

public class changecoloronmouse : MonoBehaviour
{

		public Renderer rend;

		void Start ()
		{
				rend = GetComponent<Renderer> ();
		}

		void OnMouseDown ()
		{
				rend.material.color = Color.blue;
		}
		void OnMouseExit ()
		{
				rend.material.color = Color.green;
		}
}
	


