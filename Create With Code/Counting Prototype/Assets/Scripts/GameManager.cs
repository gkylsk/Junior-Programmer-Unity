using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameObject startScreen;
    public GameObject gameOverScreen;

    public AudioSource audioSource;
    public AudioClip gameOverAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameOverScreen.SetActive(false);
        startScreen.SetActive(false);
        spawnManager.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        spawnManager.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        audioSource.PlayOneShot(gameOverAudio, 1.0f);
    }    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        StartGame();
    }
}
