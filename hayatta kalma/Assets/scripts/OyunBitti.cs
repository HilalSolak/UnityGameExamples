using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      

public class OyunBitti : MonoBehaviour
{
    public Text puan;
    void Start()
    {
        Cursor.visible = true;
        puan.text = "Puanýnýz:" + PlayerPrefs.GetInt("puan");

    }
     public void YenidenOyna()
    {
        SceneManager.LoadScene("oyun");
    }
}
