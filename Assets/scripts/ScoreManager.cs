using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    int score=0;
    public Text scoreText;
    
    public void GiveScore(int  score)
    {
        this.score += score;
        scoreText.text = "Score  " + this.score;
    }
}
