using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour {


	public GameObject player;
	public Vector3 offset;
	public float cameraSpeed = 5f;


	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPosition = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPosition,cameraSpeed * Time.deltaTime);
	}
}
