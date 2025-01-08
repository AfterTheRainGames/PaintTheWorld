using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{

    private Rigidbody bullet;
    private ScoreCounter scoreScript;

    void Start()
    {
        bullet = GetComponent<Rigidbody>();
        scoreScript = FindObjectOfType<ScoreCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NPCAnimate npcScript = other.GetComponent<NPCAnimate>();
            Destroy(gameObject);

            if (!npcScript.isHappy)
            {
                scoreScript.IncreaseScore();
                npcScript.isHappy = true;
            }
        }
    }
}
