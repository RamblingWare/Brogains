using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Transform player;
    public AudioClip hitSound;
    public AudioClip explosion;
    public GameObject bullet;
    float hitpoints = 100;
    bool destroyed;
    float deathTime;
    float shotTime;
    float fireRate = 1f;
    float bulletSpeed = 16.0f;

    private AudioSource audioSource;

	// Use this for initialization
	void Start() {
        audioSource = this.GetComponent<AudioSource>();
        destroyed = false;
        player = GameObject.Find("Player").transform;
	}

    void FixedUpdate() {
        if (destroyed) {
            if (Time.time - deathTime >= 2.0f) {
                Destroy(this.gameObject);
            }
            return;
        }

        // aim at player
        transform.up = player.position - transform.position;

        if (Physics2D.Raycast(transform.position + transform.up, transform.up).transform.tag == "Player") {
            Fire();
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        Hit(20);
    }

    void Hit(float damage) {
        hitpoints -= damage;

        if (hitpoints <= 0) {
            destroyed = true;
            audioSource.PlayOneShot(explosion);

            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 0.5f);

            deathTime = Time.time;
        }
        else {
            audioSource.PlayOneShot(hitSound, Random.Range(0.3f, 1f));
        }
    }

    void Fire() {
        if (Time.time - shotTime >= fireRate) {
            shotTime = Time.time;
            GameObject bulletSpawn = Instantiate(bullet, transform.position + transform.up, Quaternion.identity);
            bulletSpawn.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        }
    }
}
