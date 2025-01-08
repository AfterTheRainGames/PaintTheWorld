using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public Material goodColor;
    public Material badColor;
    private Renderer render;
    private NPCAnimate npcScript;

    void Start()
    {
        render = GetComponent<Renderer>();
        npcScript = GetComponentInParent<NPCAnimate>();
        render.material = badColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(npcScript.isHappy)
        {
            render.material = goodColor;
        }
        else
        {
            render.material = badColor;
        }

    }
}
