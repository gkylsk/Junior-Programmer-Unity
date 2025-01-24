using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives = " + lives + "\nScore = " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLives(int val)
    {
        lives -= val;
        if (lives <= 0)
        {
            Debug.Log("Lives = " + lives);
            Debug.Log("Game Over");
            lives = 0;
        }
    }

    public void AddScore(int val)
    {
        score += val;
        Debug.Log("Score = " + score);
    }
}
