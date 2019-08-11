using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Train : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    //-1か1 
    private float direction = 1f;
    // Start is called before the first frame update
    [SerializeField] private AudioClip playerKillSound;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x+speed*direction,transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(PlayAndWait(playerKillSound, transform));
        }
    }

    //サウンドを再生しその秒数だけ待つ
    IEnumerator PlayAndWait(AudioClip clip, Transform transform)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        
        yield return new WaitForSeconds(clip.length);
        FindObjectOfType<SceneLoader>().LoadCurrentSceneAgain();

    }

    public void SetDirection(float direction)
    {
        this.direction = direction;
    }

   
}
