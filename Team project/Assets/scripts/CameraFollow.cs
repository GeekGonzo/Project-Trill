using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dstBehind;
	public float dstUp;

	public float smooth;

	public Transform follow;
	private Vector3 targetPosition;


	// Use this for initialization
	void Start () {
		follow = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate(){
		targetPosition = follow.position + follow.up * dstUp - follow.forward * dstBehind;


		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

		transform.LookAt(follow);

	}
}
