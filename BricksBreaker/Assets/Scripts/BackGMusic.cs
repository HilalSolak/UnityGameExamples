using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class BackGMusic : MonoBehaviour
{
    static bool BackM;
    // Start is called before the first frame update
    void Start()
    {
        if (!BackM)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            BackM = true;
        }
        else {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
