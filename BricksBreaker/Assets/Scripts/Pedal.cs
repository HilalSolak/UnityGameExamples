using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    public AudioClip voiceEffect;
    private GameObject top;
    // Start is called before the first frame update
    void Start()
    {
        top = GameObject.Find("top");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = new Vector3(Mathf.Clamp(mPos.x, -2.91f, 2.91f), transform.position.y, transform.position.z);
        //transform.position = new Vector3(top.transform.position.x,transform.position.y,transform.position.z);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(voiceEffect, transform.position);

    }
}
