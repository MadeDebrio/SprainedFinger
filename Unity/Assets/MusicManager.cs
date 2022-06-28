using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private int index;
    private int index1;
    public AudioClip[] SoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void playOnClick()
    {
        _audioSource.clip = SoundEffect[6];
        _audioSource.pitch = 3;
        _audioSource.Play();
    }

    public void playOnSpawn()
    {
        _audioSource.clip = SoundEffect[1];
        _audioSource.pitch = 3;
        _audioSource.Play();
    }
}
