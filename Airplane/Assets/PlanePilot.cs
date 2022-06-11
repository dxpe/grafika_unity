using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour
{
    public float speed = 0.0f;
    public float cameraDistance = 5.0f;
    Animator m_Animator;
    public GameObject propeller;
    public GameObject mainCamera;
    public float propeller_speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraDistanceUpdate();
        Vector3 moveCamTo = transform.position - transform.forward * cameraDistance + Vector3.up * 3.0f;
        float bias = 0.96f;
        mainCamera.transform.position = mainCamera.transform.position * bias + moveCamTo * (1.0f - bias);
        mainCamera.transform.LookAt(transform.position + transform.forward * 30.0f);
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        // propeller.transform.Rotate(propeller.transform.position.x + speed / 10, -90.0f, 90.0f);

        // if (propeller.transform.position.x > 90) {
        //     propeller.transform.position.x = 0;
        // }

        if (Input.GetKey("up")) {
            m_Animator.SetBool("open", true);
        }

        if (Input.GetKey("down")) {
            m_Animator.SetBool("open", false);
        }

        calculateSpeed();
        controller();
    }

    void calculateSpeed() {
        if (transform.forward.y > 0.4f) {
            if (propeller_speed > 1) {
                speed -= transform.forward.y * Time.deltaTime * 1 / (propeller_speed + 0.1f) * speed;
            } else {
                speed -= transform.forward.y * Time.deltaTime * 1 / (1 + 0.1f) * speed;
            }
        } else {
            if (propeller_speed > 0.25) {
                if (transform.forward.y == 0) {
                    speed += Time.deltaTime * propeller_speed * 8.75f;
                }
                speed += calcForward(transform.forward.y) * Time.deltaTime * propeller_speed * 8.75f;
                Debug.Log(transform.forward.y);
            }
            if (propeller_speed < 0.25) {
                if (transform.forward.y > -0.4f) {
                    speed -= 1f * Time.deltaTime;
                } else {
                    speed -= transform.forward.y * Time.deltaTime * speed;
                }
            }
        }
        if (speed > 50.0f) {
            speed = 50.0f;
        }
        if (speed < 0.0f) {
            speed = 0.0f;
        }

        if (propeller_speed > 4) {
            propeller_speed = 4.0f;
        }

        if (propeller_speed < 0) {
            propeller_speed = 0.0f;
        }

        propeller.transform.Rotate(0.0f, propeller_speed * Time.deltaTime * 500.0f, 0.0f);
    }

    float calcForward(float x) {
        if (x < 0) {
            return -x;
        }
        if (x > 0.2f) {
            return 0.2f;
        }
        return x;
    }

    void controller() {
        if (Input.GetKey(KeyCode.Space)) {
            propeller_speed += 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            propeller_speed -= 0.1f;
        }
    }

    void cameraDistanceUpdate() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && cameraDistance > 5) {
            cameraDistance -= 5;
            m_Animator.SetBool("open", true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && cameraDistance < 50) {
            cameraDistance += 5;
        }
    }
}
