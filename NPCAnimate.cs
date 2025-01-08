using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimate : MonoBehaviour
{

    private Animator animator;
    public bool isHappy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHappy)
        {
            animator.SetBool("isHappy", true);
        }
        else
        {
            animator.SetBool("isHappy", false);
        }
    }
}
