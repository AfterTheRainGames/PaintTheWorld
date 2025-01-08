using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public int score = 0;
    public int bulletCount = 0;

  public void IncreaseScore()
    {
        score ++;
        Debug.Log(score);
    }

    public void AddBullet()
    {
        bulletCount++;
    }

}
