using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    MenuManager _menuManager;
    AudioSource _thisAudio;

    void Start()
    {
        _menuManager = FindObjectOfType<MenuManager>();
        _thisAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            _menuManager.PlayerWins();
            _thisAudio.Play();
        }
    }
}
