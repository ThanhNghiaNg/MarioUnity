using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YasuoMovement : MonoBehaviour
{
    public Vector2 velocity;
    private float inputAxis;
    public float moveSpeed = 8f;
    public float scale = 100f;
    private new Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        JumpMovement();
    }


    void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);
    }

    void JumpMovement()
    {
        inputAxis = Input.GetAxis("Jump");
        Debug.Log("inputAxis: " + inputAxis.ToString());
        velocity.y = Mathf.MoveTowards(velocity.y, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidBody.position;
        position += velocity * Time.fixedDeltaTime;
        rigidBody.MovePosition(position);
    }
}
