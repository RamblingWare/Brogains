using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float spawnTime;
    float duration = 2.0f;

	// Use this for initialization
	void Start() {
        spawnTime = Time.time;
	}

    void FixedUpdate() {
        if (Time.time - spawnTime > duration) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        Destroy(this.gameObject);
    }
}
