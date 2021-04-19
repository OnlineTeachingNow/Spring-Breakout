using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    MenuManager _menuManager;
    [SerializeField] int _coinValue = 200;
    AudioSource _thisAudio;
    Transform _mainCameraPosition;

    private void Start()
    {
        _menuManager = FindObjectOfType<MenuManager>();
        _thisAudio = GetComponent<AudioSource>();
        _mainCameraPosition = FindObjectOfType<Camera>().transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            AudioSource.PlayClipAtPoint(_thisAudio.clip, _mainCameraPosition.position, 1.0f);
            _menuManager.AddPoints(_coinValue);
            Destroy(this.gameObject);

        }
    }
}
