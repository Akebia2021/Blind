using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private AudioClip exitSound;

    [SerializeField] private AudioClip objectiveSound;

    [SerializeField] private float timeBetweenSoundMin = 1f;
    [SerializeField] private float timeBetweenSoundMax = 3f;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private Obstacle[] obstacles;

    private void Start()
    {
        obstacles = FindObjectsOfType<Obstacle>();

        //If Current scene is 1(bell sound level), call bell sound coroutine
        if (objectiveSound)
        {
            StartCoroutine(PlayBellSound());
        }
    }

       

    //if the player get in the trigger, stops bgm and load next scene.
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StopEmittingSound();
            foreach(Obstacle obstacle in obstacles)
            {
                GameObject.Destroy(obstacle);
            }

            StartCoroutine(playSndAndLoadScene(exitSound));

        }

    }

    //Play exit sound and load next scene
    IEnumerator playSndAndLoadScene(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSeconds(clip.length);
       
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    private void StopEmittingSound()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }

    //instancing AudioSource bell sound and wait roundom second to play next sound. 
    //Destroy function does not work yet??
    IEnumerator PlayBellSound()
    {

        while (true)
        {
            float lastingDuration = UnityEngine.Random.Range(timeBetweenSoundMin, timeBetweenSoundMax);
            AudioSource.PlayClipAtPoint(objectiveSound, transform.position);
            yield return new WaitForSeconds(lastingDuration);
        }
    }


}
