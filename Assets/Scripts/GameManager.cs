using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOn;    
    public Image gameOverScreen;    
    public GameObject healthFrame;
    public Image titleScreen;
    public Button gameRestartButton;
    public Button startButton;
    public Button quitButton;
    public Button exitButton;
    public string SlimeSlasher;
    public string Title;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        SceneManager.LoadScene(SlimeSlasher);
    }
    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameRestartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);       
        healthFrame.gameObject.SetActive(false);
                
    }
    public void GameRestart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameQuit()
    {
        SceneManager.LoadScene(Title);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
