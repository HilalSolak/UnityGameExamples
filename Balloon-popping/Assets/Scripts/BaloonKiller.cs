using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonKiller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject patlama;
    GameControl CreatorSc;
     void Start()
    {
        CreatorSc = GameObject.Find("_Scripts").GetComponent<GameControl>();
        
    }
    void OnMouseDown()
    {
        GameObject go = Instantiate(patlama, transform.position, transform.rotation)as GameObject;
       
        Destroy(this.gameObject);
        Destroy(go, 0.517f);
        CreatorSc.BalonEkle();

    }
}
