using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoyScript : MonoBehaviour
{
    public float speed = 50;
    public float jump = 50;
    public float angle = 45f;
    public float force = 450f;
    public float forceLimit = 100000f;
    public float reverseDelay = 10f; //Задержка при повороте
    public float forceChange = 1f; //Скорость изменения силы 
    public float angleChange = 0.2f; //Скорость изменения угла 
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    bool reverse = false;
    float reverseTime = 0;


    void Start()
    {
        
    }

    void fire()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float ljump = 0;
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") == true)
        {
            ljump = jump;
        }

        if (Input.GetButtonDown("Fire1") == true)
        {
            WeaponScript wep = this.transform.GetComponent<WeaponScript>();
            wep.Attack(angle, force,reverse);
        }
        if (Input.GetButton("Angle-") == true)
        {
            if (angle > 0)
            {
                angle = (angle - angleChange);
            }
        }
        if (Input.GetButton("Angle+") == true)
        {
            if (angle < 90)
            {
                angle = (angle + angleChange);
            }
        }

        if (Input.GetButton("Force+") == true)
        {
            if (force < forceLimit)
            {

                force = force + forceChange;
            }
        }

        if (Input.GetButton("Reverse") == true)
        {
            Debug.Log(reverseTime);
            if (reverseTime <= 0)
            {

                this.transform.Rotate(new Vector3(0, 180, 0));
                reverse = !reverse;
                reverseTime = reverseDelay;
            } 
            if (reverseTime > 0)
            {
                reverseTime = reverseTime - 1;
            }
        }

        if (Input.GetButton("Force-") == true)
        {
            if (force > 0)
            {
                force = force - forceChange;
            }
        }
        // 4 - Movement per direction
        movement = new Vector2(speed * inputX, ljump);
    }

    void FixedUpdate()
    {
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Mine") //Смерть от мины
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.name == "Death") //Смерть от падения
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
