using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllWall : MonoBehaviour
{
    public GameObject crash;
    public AudioClip voiceEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(voiceEffect,transform.position);
        Vector3 pos = collision.contacts[0].point;
        GameObject go = Instantiate(crash,pos,Quaternion.identity) as GameObject;
        Destroy(go,1f);
        
    }
}
