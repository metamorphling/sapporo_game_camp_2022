using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStart : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audiosource;
    public AudioClip BGM;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        audiosource.PlayOneShot(BGM);
    }
}
