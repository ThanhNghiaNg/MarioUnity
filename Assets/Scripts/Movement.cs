using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private new Rigidbody2D rigidbody;
    public float pointStep = 0.0001f;
    float nextPosX;
    float nextPosY;
    int direction = 1;
    float scale = 100.0f;
    float phi = 0.0f;
    int t = 0;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        nextPosX = rigidbody.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody.position;

        float r = 4.0f;
        // x = A cos⁡(ωt + φ).
        // float b = 4f;
        // float a = 2f;

        // nextPosX = rigidbody.position.x + direction * pointStep;

        if (nextPosX >= r)
        {
            direction = -1;
        }
        else if (nextPosX <= -r)
        {
            direction = 1;
        }

        // nextPosY = direction * (float)Math.Sqrt((r * r - nextPosX * nextPosX));
        // nextPosX = r * (float)Math.Cos(1 / 180 + phi);
        // phi += 1 / 180;
        // t += 1;
        if (phi >= 360.0f) phi = 0.0f;
        float cgv = r * (float)Math.Cos(phi * (Math.PI) / 180);
        Debug.Log("cgv = " + cgv.ToString());
        nextPosX = cgv;
        nextPosY = direction * (float)Math.Sqrt((r * r - nextPosX * nextPosX));
        phi += 0.01f;

        rigidbody.MovePosition(new Vector2(nextPosX, nextPosY));

        transform.Rotate(0.0f, 0.0f, 0.1f);

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x + scale * Time.deltaTime, position.y + scale * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x - scale * Time.deltaTime, position.y + scale * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x - scale * Time.deltaTime, position.y - scale * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x + scale * Time.deltaTime, position.y - scale * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x, position.y + scale * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x, position.y - scale * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x - scale * Time.deltaTime, position.y));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.MovePosition(new Vector2(position.x + scale * Time.deltaTime, position.y));
        }
    }
}
