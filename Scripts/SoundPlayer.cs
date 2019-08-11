using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    //main audio clip
    [SerializeField] private AudioClip sound1;

    //Audio source reference
    private AudioSource audioSource;

    [SerializeField] private float timeBetweenSoundMin = 1f;
    [SerializeField] private float timeBetweenSoundMax = 3f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound1;
        StartCoroutine(PlaySoundRondomRange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlaySoundRondomRange()
    {

        while (true)
        {
            float lastingDuration = UnityEngine.Random.Range(timeBetweenSoundMin, timeBetweenSoundMax);
            audioSource.Play();
            yield return new WaitForSeconds(lastingDuration);
        }
    }
}
