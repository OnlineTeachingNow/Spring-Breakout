using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        _gameOverMenu.SetActive(false);
    }

    public void PlayerDeath()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
