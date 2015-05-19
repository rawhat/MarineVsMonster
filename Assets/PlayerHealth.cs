using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health = 2f;
	public bool isDead = false;

	void MonsterHit(){
		if (!isDead) {
			health -= 1f;
			if (health == 0)
				isDead = true;
		}
	}
}
