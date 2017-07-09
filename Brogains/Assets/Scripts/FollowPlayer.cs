using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
    void Update () {
        transform.position = player.position + Vector3.back;
	}

    void FixedUpdate() {
    }
}
