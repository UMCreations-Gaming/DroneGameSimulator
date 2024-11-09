using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip droneSound;
    [SerializeField] AudioClip bgsound;
    [SerializeField] AudioClip ringpasssound;
    [SerializeField] AudioClip levelCompetedsound;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRingPassSound()
    {
        Handheld.Vibrate();
        audioSource.PlayOneShot(ringpasssound, 1);
    } 
    
    public void PlayLevelreachSound()
    {
       // audioSource.PlayOneShot(levelCompetedsound, 1);
    }
}
