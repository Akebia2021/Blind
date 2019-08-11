using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ambient : MonoBehaviour
{
    [SerializeField] private AudioClip enterSound;
    [SerializeField] private AudioClip ambSound;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float volume = 1.0f;
    private SceneLoader sceneLoader;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        sceneLoader = FindObjectOfType<SceneLoader>();

        //Level1の時はEnterSOUNDを鳴らさない
        if (sceneLoader.GetCurrenSceneIndex() == 1)
        {
            audioSource.clip = ambSound;
            audioSource.Play();
        }
        else
        {

            AudioSource.PlayClipAtPoint(enterSound, FindObjectOfType<FirstPersonController>().transform.position);
            audioSource.clip = ambSound;
            audioSource.Play();
        }


    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
   

}
