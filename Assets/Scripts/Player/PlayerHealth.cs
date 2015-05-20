using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health = 2f;
	public bool isDead = false;
	public bool isHurt = false;

	public void MonsterHit(){
		if (!isDead) {
			health -= 1f;
			isHurt = true;
			if (health <= 0f)
				isDead = true;
		}
	}
}
