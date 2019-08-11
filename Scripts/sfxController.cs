using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxController : MonoBehaviour
{
    [SerializeField] private AudioClip enterSound;
    [SerializeField] private AudioClip exitSound;
    

    public void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }

}
