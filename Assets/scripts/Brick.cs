using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitPoint;
    public int score;
    public ScoreManager scoreManager;
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            hitPoint -= 1;
            if (hitPoint == 0) 
            {
                scoreManager.GiveScore(score);
                Destroy(gameObject);
            }
        }
    }
}

