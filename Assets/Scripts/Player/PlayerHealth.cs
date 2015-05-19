using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health = 2f;
	public bool isDead = false;

	public void MonsterHit(){
		Debug.Log ("hit!");
		if (!isDead) {
			health -= 1f;
			if (health <= 0f)
				isDead = true;
		}
	}
}
