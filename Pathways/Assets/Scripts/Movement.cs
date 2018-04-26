using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float playerSpeed = 120f;
    public float rotateSpeed = 120f;

    private Rigidbody2D sprite;

    private void Start()
    {
        // Fetch Rigidbody attached to GameObject
        sprite = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotation
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);

        // Forward Movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            sprite.velocity = transform.up * playerSpeed * Time.deltaTime;
        } else
        {
            sprite.velocity = Vector2.zero;
        }

        // Backwards 
        if (Input.GetKey(KeyCode.DownArrow))
        {
            sprite.velocity = -transform.up * playerSpeed * Time.deltaTime;
        }
    }
}
