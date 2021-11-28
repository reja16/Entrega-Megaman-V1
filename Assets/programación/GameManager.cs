using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject Felicitacion1;
    [SerializeField]int conteo;
    public megaman vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = FindObjectOfType<megaman>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        perder();
    }
    void perder()
    {
        if(vida.vida <= 0)
        {
            gameOverMenu.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void PauseGame()
    {
        //pausar y "despausar" el juego
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
        
    }
}
