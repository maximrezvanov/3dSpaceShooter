using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;


    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();   
    }

    // Update is called once per frame
   public void ScoreHit(int scorePerHit)
    {

        score += scorePerHit;
        scoreText.text = score.ToString();

    }
}
