﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushKeyThrowBall : MonoBehaviour {

    public int minSpeed;
    public KeyCode keyCode;
    public int maxSpeed;

    GameObject ball;
    private int speed;
    private float intensity;
    private bool isCollision;
    Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        isCollision = false;
        intensity = 0;
    }

    private void OnCollisionEnter (Collision collision) {
        isCollision = true;
        speed = Random.Range (minSpeed, maxSpeed);

        rigidBody = collision.gameObject.GetComponent<Rigidbody> ();
        ball = collision.gameObject;
    }

    private void OnCollisionExit (Collision collision) {
        isCollision = false;
    }
    private void Update () {
        if (isCollision) {
            if (Input.GetKeyUp (keyCode)) {
                rigidBody.AddForce (new Vector3 (ball.transform.position.x, ball.transform.position.y, -ball.transform.position.z * speed * intensity), ForceMode.Force);
            }
        }

        if (Input.GetKey (keyCode)) {
            intensity += Time.deltaTime;
        } else {
            intensity = 0;
        }

    }

}