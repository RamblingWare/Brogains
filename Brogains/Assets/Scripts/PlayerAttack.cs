using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    bool firing;
    float bulletSpeed = 8.0f;
    float fireRate = 0.5f;
    float shotTime;
    public GameObject bullet;

	// Use this for initialization
	void Start() {
        firing = false;
	}
	
	// Update is called once per frame
	void Update() {
        if (Input.GetMouseButtonDown(0)) {
            firing = true;
        }
        else if (Input.GetMouseButtonUp(0)) {
            firing = false;
        }
	}

    void FixedUpdate() {
        if (firing) {
            if (Time.time - shotTime > fireRate) {
                Fire();
                shotTime = Time.time;
            }
        }
    }

    void Fire() {
        Vector3 spawnPos = transform.position + transform.up.normalized;

        GameObject bulletSpawn = Instantiate(bullet, spawnPos, Quaternion.identity);
        bulletSpawn.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
