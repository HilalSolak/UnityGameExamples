using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public bool oyunAktif = true;
    public int altinSayisi = 0;
    public UnityEngine.UI.Text altinS;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void altinArttir() {
        altinSayisi += 1;
        altinS.text = "" + altinSayisi;
    }
}
