using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button gameRestartButton;
    public Image gameOverScreen;
    public bool isGameOn;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {        
        gameOverScreen.gameObject.SetActive(true);
        gameRestartButton.gameObject.SetActive(true);
        isGameOn = false;
    }
    public void GameRestart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
