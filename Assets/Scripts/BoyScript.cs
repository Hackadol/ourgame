using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour
{
    public float speed = 50;
    public float jump = 50;

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ljump = 0;
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space") == true)
        {
            ljump = jump;
        }
        // 4 - Movement per direction
        movement = new Vector2(
          speed * inputX,
          ljump);
    }

    void FixedUpdate()
    {
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;
    }
}
