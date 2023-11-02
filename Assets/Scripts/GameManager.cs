using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel, endPanel;

    [HideInInspector]
    public bool gameIsOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        FindObjectOfType<SpawnManager>().enabled = false;
    }

    public void StartButton()
    {
        FindObjectOfType<SpawnManager>().enabled = true;
        startPanel.SetActive(false);
    }

    public void EndGameActivation()
    {
        gameIsOver = true;
        startPanel.SetActive(false);
        endPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AudioCheck()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
        {
            // Mute am thanh
            
        }
        else
        {
            // Hien button am thanh 
            // Cho phat ra nhac
        }
    }
}
