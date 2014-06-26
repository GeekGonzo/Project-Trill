using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 9.8f;
	public float rotationSpeed = 1000 ;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	private Quaternion targetRotation;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded) {
			// We are grounded, so recalculate
			// move direction directly from axes
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
			                        Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
			}

		}
		
		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;
		
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);



	}
}
