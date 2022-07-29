using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonCreator : MonoBehaviour
{
    public GameObject baloon;
    float balonCreatedTime = 1f;
    float TimeSpacer = 0f;
    GameControl okScripti;
    // Start is called before the first frame update
    void Start()
    {
        okScripti = this.gameObject.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        int katSayi = (int)(okScripti.ZamanSayaci / 10)-6;
        katSayi *= -1;
        TimeSpacer -= Time.deltaTime;
        if (TimeSpacer<0 && okScripti.ZamanSayaci>0)
        {
            GameObject go = Instantiate(baloon, new Vector3(Random.Range(-2.75f, 2.75f), -6f, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,Random.Range(30f*katSayi,80f*katSayi),0));
            TimeSpacer = balonCreatedTime;

        }
        
    }
}
