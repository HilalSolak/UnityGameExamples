using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class oyunkontrolu : MonoBehaviour
{
    public GameObject zombi;
    private float zamanSayaci;
    private float olusumSureci=10f;
    public Text puanText;
    private int puan;
    void Start()
    {
        zamanSayaci = olusumSureci;
    }
        
    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0)
        {
            Vector3 pos = new Vector3(Random.Range(696,857), 458.3f, Random.Range(660,859));
            Instantiate(zombi,pos,Quaternion.identity);
            zamanSayaci = olusumSureci;
        }
    }
    public void PuanArtir(int p)
    {
        puan += p;
        puanText.text = "" + puan;
    }
    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan", puan);
        SceneManager.LoadScene("Oyunbitti");
    }
}
