using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float acceleration = 2.5f;
	public float movementSpeed = 4f;
	public float jumpingSpeed = 6f;
	public float jumpDuration = 0.35f;
	public float verticalWallJumpingSpeed = 5f;
	public float horizontalWallJumpingSpeed = 3.5f;

	private float speed = 0f;
	private float jumpingTimer = 0f;

	private bool canJump = false;
	private bool jumping = false;
	private bool canWallJump = false;
	private bool wallJumpLeft = false;

	

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		speed += acceleration * Time.deltaTime;

		if(speed > movementSpeed) {
		   speed = movementSpeed;
		}

		GetComponent<Rigidbody>().velocity = new Vector3(
			speed,
			GetComponent<Rigidbody>().velocity.y,
			GetComponent<Rigidbody>().velocity.z
			);

		bool pressingJumpButton = Input.GetMouseButton(0) || Input.GetKey("space");
		if(pressingJumpButton) {
			if(canJump) {
				jumping = true;
			}
		}

		if (jumping) {
			jumpingTimer += Time.deltaTime; // 점프를 누를때만 시간이 더해지는데.. 계속 시간은 누적된다.
			
			if (pressingJumpButton && jumpingTimer < jumpDuration){
				GetComponent<Rigidbody>().velocity = new Vector3(
				GetComponent<Rigidbody>().velocity.x,
				jumpingSpeed,
				GetComponent<Rigidbody>().velocity.z
			);
			}
		}

		if(canWallJump && pressingJumpButton) {
			canWallJump = false;

			speed = wallJumpLeft ? -horizontalWallJumpingSpeed : horizontalWallJumpingSpeed;
			
			GetComponent<Rigidbody>().velocity = new Vector3(
				GetComponent<Rigidbody>().velocity.x,
				verticalWallJumpingSpeed,
				GetComponent<Rigidbody>().velocity.z
			);
		}


		}
		
	void OnTriggerStay(Collider otherCollider) {
		if(otherCollider.tag == "JumpingArea") {
			canJump = true;
			jumping = false; // 점핑값을 초기화 시켜주지 않으면 계속 점프함..
			jumpingTimer = 0f; // 점핑타이머를 초기화 시켜주지 않으면 점프 시간이 계속 증가되서 점프를 안함..위에 조건식 있음.
		}else if(otherCollider.tag == "WallJumpingArea") {
			canWallJump = true;
			wallJumpLeft = transform.position.x < otherCollider.transform.position.x;

		}
	
	}
}

	

