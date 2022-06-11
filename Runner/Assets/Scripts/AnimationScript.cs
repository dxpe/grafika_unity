using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator m_Animator;

    void Start() {
        m_Animator = gameObject.GetComponent<Animator>();
        Debug.Log(m_Animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            m_Animator.SetBool("jumped", true);
        }

        if (PlayerMove.collided) {
            m_Animator.SetBool("collided", true);
        }

        if (PlayerMove.start) {
            m_Animator.SetBool("start", true);
        }
    }

    public void setJumpedFalse() {
        Debug.Log("set false");
        m_Animator.SetBool("jumped", false);
    }
}
