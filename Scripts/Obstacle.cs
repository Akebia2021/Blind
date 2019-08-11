using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] AudioClip[] obstacleSounds;
    [SerializeField] AudioClip playerKillSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySwordSounds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator PlaySwordSounds()
    {
        while (true)
        {
            //float selection = UnityEngine.Mathf.Round(UnityEngine.Random.Range(1f, 2f));
            //Debug.Log(selection);
            AudioSource.PlayClipAtPoint(obstacleSounds[1], transform.position);
            yield return new WaitForSeconds(2f);

        }
    }

   

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(PlayAndWait(playerKillSound, gameObject.transform));

        }
    }

    //サウンドを再生しその秒数だけ待つ
    IEnumerator PlayAndWait(AudioClip clip, Transform transform)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSeconds(clip.length);
        FindObjectOfType<SceneLoader>().LoadCurrentSceneAgain();

    }

}
