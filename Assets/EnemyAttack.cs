using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	private NavMeshAgent nav;
	private CapsuleCollider col;
	private GameObject player;
	private PlayerHealth playerHealth;
	// Use this for initialization
	void Awake () {
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<CapsuleCollider> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerStay(Collider obj){
		if (obj.gameObject == player && !playerHealth.isDead) {
			nav.Stop ();
			playerHealth.MonsterHit();
		}
	}
}
