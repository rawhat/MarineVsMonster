using UnityEngine;
using System.Collections;

public class MyMouseLook : MonoBehaviour {
	public Vector2 sensitivity = new Vector2(15f, 15f);
	public Vector2 clamping = new Vector2(360f, 60f);

	float rotX = 0f;
	float rotY = 0f;

	Quaternion originalRotation;

	public GameObject playerBody;

	void Start(){
		Cursor.visible = false;
		playerBody.GetComponent<Rigidbody> ().freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	void Update () {
		Cursor.lockState = CursorLockMode.Locked;
		rotY += Input.GetAxisRaw ("Mouse Y") * sensitivity.y;
		rotX += Input.GetAxisRaw ("Mouse X") * sensitivity.x;

		rotX = ClampAngle (rotX, -clamping.x, clamping.x);
		rotY = ClampAngle (rotY, -clamping.y, clamping.y);

		Quaternion xQuat = Quaternion.AngleAxis (rotX, Vector3.up);
		Quaternion yQuat = Quaternion.AngleAxis (rotY, Vector3.left);

		transform.localRotation = originalRotation * xQuat * yQuat;
		playerBody.transform.localRotation = xQuat;
	}

	public static float ClampAngle (float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F)) {
			if (angle < -360F) {
				angle += 360F;
			}
			if (angle > 360F) {
				angle -= 360F;
			}			
		}
		return Mathf.Clamp (angle, min, max);
	}
}
