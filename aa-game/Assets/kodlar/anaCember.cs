using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anaCember : MonoBehaviour
{
    public GameObject kucukCember;
    GameObject OyunYonetici;
    void Start()
    {
        OyunYonetici = GameObject.FindGameObjectWithTag("oyunYoneticisi");
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            kucukCemberOlustur();
        }
    }
    void kucukCemberOlustur()
    {
        Instantiate(kucukCember, transform.position, transform.rotation);
        OyunYonetici.GetComponent<oyunYöneticisi>().KucukCemberlerdeTextGosterme();
    }
}

