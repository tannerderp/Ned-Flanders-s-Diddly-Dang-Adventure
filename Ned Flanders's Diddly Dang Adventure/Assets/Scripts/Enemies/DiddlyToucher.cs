﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiddlyToucher : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private int health = 2;

    [SerializeField] private int direction = 1; //1 or -1
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector2(transform.localScale.x * direction, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(speed * direction, rigidBody.velocity.y);
    }
}
