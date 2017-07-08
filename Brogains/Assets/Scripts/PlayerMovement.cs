using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	bool moveUp, moveDown, moveLeft, moveRight;
	Rigidbody2D rigid;
	float speed = 2.0f;

	// Use this for initialization
	void Start() {
		moveUp = false;
		moveDown = false;
		moveLeft = false;
		moveRight = false;
		rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() {
		// Up
		if (Input.GetKeyDown(KeyCode.W)) {
			moveUp = true;
		}
		else if (Input.GetKeyUp(KeyCode.W)) {
			moveUp = false;
		}

		// Down
		if (Input.GetKeyDown(KeyCode.S)) {
			moveDown = true;
		}
		else if (Input.GetKeyUp(KeyCode.S)) {
			moveDown = false;
		}

		// Left
		if (Input.GetKeyDown(KeyCode.A)) {
			moveLeft = true;
		}
		else if (Input.GetKeyUp(KeyCode.A)) {
			moveLeft = false;
		}

		// Right
		if (Input.GetKeyDown(KeyCode.D)) {
			moveRight = true;
		}
		else if (Input.GetKeyUp(KeyCode.D)) {
			moveRight = false;
		}
	}

	void FixedUpdate() {
		// vertical movement
		Vector2 vel = Vector2.zero;

		if (moveUp && !moveDown) { // move up
			vel.y = speed;
		}
		else if (!moveUp && moveDown) { // move down
			vel.y = -speed;
		}

		// horizontal movement

		if (moveLeft && !moveRight) { // move left
			vel.x = -speed;
		}
		else if (!moveLeft && moveRight) { // move right
			vel.x = speed;
		}

		rigid.velocity = vel;
	}
}
