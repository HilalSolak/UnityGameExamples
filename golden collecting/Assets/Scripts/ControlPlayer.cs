using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public AudioClip altin, fall;
    public GameControl oyunK;
    private float hiz=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif) { 
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        x *= Time.deltaTime * hiz;
        y *= Time.deltaTime * hiz;
        transform.Translate(x,0f,y);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("altin")){
            GetComponent<AudioSource>().PlayOneShot(altin,1f);
            GetComponent<AudioSource>().PlayOneShot(altin,1f);
            oyunK.altinArttir();
            Destroy(collision.gameObject);

        } 
        else if (collision.gameObject.tag.Equals("dusman")) {
            oyunK.oyunAktif = false;
            GetComponent<AudioSource>().PlayOneShot(fall, 1f);
        }
    }


}
