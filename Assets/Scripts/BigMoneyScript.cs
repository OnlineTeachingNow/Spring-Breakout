using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMoneyScript : MonoBehaviour
{
    MenuManager _menuManager;
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
            int _currentPoints = _menuManager.GetPoints();
            int _pointsToThousand = 1000 - _currentPoints;
            _menuManager.AddPoints(_pointsToThousand);
            Destroy(this.gameObject);
         
        }
    }
}
