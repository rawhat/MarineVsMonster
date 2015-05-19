using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public float patrolSpeed = 2f;
	public float chaseSpeed = 5f;
	public float chaseWaitTime = 5f;
	public float patrolWaitTime = 1f;
	public Transform[] patrolWayPoints;
	public bool gameOver = false;

	private EnemySight enemySight;
	private NavMeshAgent nav;
	private Transform player;
	private LastPlayerSighting lastSighting;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;

	void Awake(){
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		lastSighting = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LastPlayerSighting> ();
	}

	void Update(){
		if (!gameOver) {
			if (enemySight.lastSighting != lastSighting.resetPosition)
				Chasing ();
			else
				Patrolling ();
		} else
			nav.Stop ();
	}

	void Chasing(){
		Vector3 sightingDelta = enemySight.lastSighting - transform.position;
		if (sightingDelta.sqrMagnitude > 4f)
			nav.destination = enemySight.lastSighting;

		nav.speed = chaseSpeed;

		if (nav.remainingDistance < nav.stoppingDistance) {
			chaseTimer += Time.deltaTime;

			if (chaseTimer > chaseWaitTime) {
				lastSighting.position = lastSighting.resetPosition;
				enemySight.lastSighting = lastSighting.resetPosition;
				chaseTimer = 0f;
			}
		} else
			chaseTimer = 0f;
	}

	void Patrolling(){
		nav.speed = patrolSpeed;

		if (nav.destination == lastSighting.resetPosition || nav.remainingDistance < nav.stoppingDistance) {
			patrolTimer += Time.deltaTime;

			if (patrolTimer >= patrolWaitTime) {
				if (wayPointIndex == patrolWayPoints.Length - 1)
					wayPointIndex = 0;
				else
					wayPointIndex++;
				patrolTimer = 0f;
			}
		} else
			patrolTimer = 0f;

		nav.destination = patrolWayPoints [wayPointIndex].position;
	}
}
