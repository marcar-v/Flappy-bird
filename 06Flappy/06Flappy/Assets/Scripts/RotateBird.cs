using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour
{
    public float maxDownVelocity = -5f;
    public float maxDownAngle = -90f;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d != null)
        {
            float currentVelocity = Mathf.Clamp(rb2d.velocity.y, maxDownVelocity, 0);
            float angle = (currentVelocity / maxDownVelocity) * maxDownAngle;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
        }
    }
}
