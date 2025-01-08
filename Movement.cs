using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject girl;
    public bool trans;
    private Animator animator;
    public bool isRunning = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = girl.transform.position;
        if (isRunning)
        {
            move.z += .075f;
            GetComponent<Rigidbody>().MovePosition(move);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("T"))
        {
            trans = true;
        }

        if(other.CompareTag("BossT"))
        {
            isRunning = false;
        }
    }
}
