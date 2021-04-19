using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerScript : MonoBehaviour
{
    private GameObject[] music;
    AudioSource _thisAudio;

    [SerializeField] AudioClip _normalMusic;
    [SerializeField] AudioClip _phew;

    void Start()
    {
        _thisAudio = GetComponent<AudioSource>();
        music = GameObject.FindGameObjectsWithTag("gameMusic");
        if (music.Length > 1)
        {
            Destroy(music[1]);
        }
    }

    // Update is called once per frame
    void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
    }

    public void PlayerSpotted()
    {
        _thisAudio.Pause();
    }

    public void PlayerSafe()
    {
        StartCoroutine(PlayerSafeAudio());
        _thisAudio.UnPause();
    }

    private IEnumerator PlayerSafeAudio()
    {
        _thisAudio.clip = _phew;
        _thisAudio.Play();
        yield return new WaitForSeconds(0.8f);
        _thisAudio.clip = _normalMusic;
        _thisAudio.Play();
    }
}
