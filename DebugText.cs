using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string txt = SceneManager.GetActiveScene().name;
        GetComponent<UnityEngine.UI.Text>().text = txt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
