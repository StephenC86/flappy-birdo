using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject bird;
    public AudioSource audioSource;
    public AudioClip flap;
    public AudioClip death;
    public AudioClip score;
    public bool soundPlayed = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    { 
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Bird>().birdIsAlive)
        {
            playerScore = playerScore + scoreToAdd;

            audioSource.clip = score;
            audioSource.Play();
        }
        
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (soundPlayed == false)
        {
            audioSource.clip = death;
            audioSource.Play();
            soundPlayed = true;
        }
        gameOverScreen.SetActive(true);
    }
}