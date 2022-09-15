using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool movingClockwise;

    [SerializeField] float moveSpeed;
    [SerializeField] float rightAngle;
    [SerializeField] float leftAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    void Update()
    {
        Move();
    }

    public void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }

    }
    public void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            rb.angularVelocity = -1 * moveSpeed;
        }
    }
}
