using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public static bool isGrounded = true;
    public static bool collided = false;
    public static bool start = false;
    public static bool restart = false;
    public bool goleft = false;
    public bool goright = false;
    public bool isleft, ismiddle, isright;
    public float jumpForce=20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    public float strafeSpeed = 50f;
    float velocity;

    void Update()
    {
        if (start && !collided) {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            controller();
        }

        if(collided)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                CollectableCoin.coinCount = 0;
                DistanceTraveled.disRun = 0;
                start = false;
                collided = false;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collider")) 
            {
                collided = true;
                moveSpeed = 0;
            }
        }

    void controller() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > -2)
            {
                goleft = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < 2)
            {
                goright = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity = jumpForce;
        }

        position();
        jump();
        left();
        right();
    }

    public void position() {
        if (this.gameObject.transform.position.x == -2)
        {
            isleft = true;
            ismiddle = false;
            isright = false;
        }

        if (this.gameObject.transform.position.x == 0)
        {
            isleft = false;
            ismiddle = true;
            isright = false;
        }

        if (this.gameObject.transform.position.x == 2)
        {
            isleft = false;
            ismiddle = false;
            isright = true;;
        }
    }

    public void jump() {
        velocity += gravity * gravityScale * Time.deltaTime;
        groundCheck();
        if (isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    public void left() {
        if (isright && goleft)
        {
            transform.Translate(new Vector3(-strafeSpeed, 0, 0) * Time.deltaTime);
            if (this.gameObject.transform.position.x <= 0)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                goleft = false;
            }
        }

        if (ismiddle && goleft)
        {
            transform.Translate(new Vector3(-strafeSpeed, 0, 0) * Time.deltaTime);
            if (this.gameObject.transform.position.x <= -2)
            {
                transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                goleft = false;
            }
        }
    }

    public void right() {
        if (isleft && goright)
        {
            transform.Translate(new Vector3(strafeSpeed, 0, 0) * Time.deltaTime);
            if (this.gameObject.transform.position.x >= 0)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                goright = false;
            }
        }

        if (ismiddle && goright)
        {
            transform.Translate(new Vector3(strafeSpeed, 0, 0) * Time.deltaTime);
            if (this.gameObject.transform.position.x >= 2)
            {
                transform.position = new Vector3(2, transform.position.y, transform.position.z);
                goright = false;
            }
        }
    }

    public void groundCheck() {
        if (this.gameObject.transform.position.y <= 1.5f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}