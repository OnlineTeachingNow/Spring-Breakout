using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _playerWinsMenu;
    [SerializeField] TextMeshProUGUI _pointManager;
    [SerializeField] int _pointsValue = 1000;

    void Start()
    {
        _pointManager.text = _pointsValue.ToString();
        _gameOverMenu.SetActive(false);
        _playerWinsMenu.SetActive(false);
    }

    public void PlayerDeath()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayerWins()
    {
        _playerWinsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioControllerScript>().PlayerSafe();
        SceneManager.LoadScene(0);
        FindObjectOfType<EnemyMovement>().HasSeenPlayer(false);
        Time.timeScale = 1;
    }

    public void AddPoints(int pointValue)
    {
        _pointsValue += pointValue;
        _pointManager.text = _pointsValue.ToString();
    }

    public void DetractPoints(int pointValue)
    {
        _pointsValue -= pointValue;
        _pointManager.text = _pointsValue.ToString();
    }

    public int GetPoints()
    {
        return _pointsValue;
    }
}
