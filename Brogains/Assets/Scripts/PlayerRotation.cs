using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    Rigidbody2D rigid;

	// Use this for initialization
	void Start() {
        rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

    void FixedUpdate() {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.up = mousePos - transform.position;
    }
}
