using UnityEngine;
using System.Collections;

public class CameraOribit : MonoBehaviour {

	public Transform target;
	public float distance = 10.0f;
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	public float zoomSpeed = 120.0f;
	private float x = 0.0f;
	private float y = .0f;
	public bool zoom;



	
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;



	}

	void Update(){
		if (!zoom) 
		{
			if (Input.GetButtonDown("Zoom"))
			{
				zoom = true;
			}
		}
		else if (zoom)
		{
			if (Input.GetButtonDown("Zoom")) {
				zoom = false;
			}
		}


	}
	
	void LateUpdate () {

		if (target) {
			x += (float)(Input.GetAxis("RightStickHorizontal") * xSpeed * 0.02);
			
			if (zoom) {
				distance -= (float)(Input.GetAxis("RightStickVertical"));
				if (distance <= 0) {
					distance = 0;
				}
				if (distance >= 15) {
					distance = 15;
				}
			}
			else {
				y += (float)(Input.GetAxis("RightStickVertical") * zoomSpeed * 0.02);
			}
			
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
			
			transform.rotation = rotation;
			transform.position = position;

		}
	}
	
	private int ClampAngle (float angle, float min, float max) {
		if (angle < 10) {
			angle = 10;
				}
		return Mathf.Clamp ((int)(angle), (int)(min), (int)(max));
	}



}
