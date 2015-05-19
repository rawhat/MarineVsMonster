using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public float fovAngle = 110f;
	public bool playerInSight;
	public Vector3 lastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;
	private GameObject player;
	private Vector3 prevSighting;
	private PlayerController playerController;

	private static Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);

	void Awake(){
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponent<PlayerController> ();

		lastSighting = resetPosition;
		prevSighting = resetPosition;
	}

	void OnTriggerStay(Collider obj){
		if (obj.gameObject == player) {
			playerInSight = false;

			Vector3 dir = obj.transform.position - transform.position;
			float angle = Vector3.Angle(dir, transform.forward);

			if(angle < fovAngle * 0.5f){
				RaycastHit hit;

				if(Physics.Raycast(transform.position + (transform.up * 0.5f), dir.normalized, out hit, col.radius)){
					if(hit.collider.gameObject == player){
						playerInSight = true;
						lastSighting = player.transform.position;
					}
				}
			}

			if(playerController.isSprinting){
				if(PathLength(player.transform.position) <= col.radius){
					lastSighting = player.transform.position;
				}
			}
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.gameObject == player)
			playerInSight = false;
	}

	float PathLength(Vector3 targetPos){
		NavMeshPath path = new NavMeshPath ();
		if (nav.enabled)
			nav.CalculatePath (targetPos, path);

		Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

		allWayPoints [0] = transform.position;
		allWayPoints [allWayPoints.Length - 1] = targetPos;

		for(int i = 0; i < path.corners.Length; i++){
			allWayPoints[i+1] = path.corners[i];
		}

		float pathLen = 0.0f;

		for(int i = 0; i < allWayPoints.Length-1; i++){
			pathLen += Vector3.Distance(allWayPoints[i], allWayPoints[i+1]);
		}

		return pathLen;
	}
}
