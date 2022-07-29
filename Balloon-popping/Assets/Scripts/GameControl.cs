using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public UnityEngine.UI.Text zamanText, balonText;
    public GameObject patlama;
    public float ZamanSayaci=60;
    int PatlayanBalon = 0;

    // Start is called before the first frame update
    void Start()
    {
        balonText.text = "Balon:" + PatlayanBalon;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ZamanSayaci > 0)
        {
            ZamanSayaci -= Time.deltaTime;
            zamanText.text = "Süre : " + (int)ZamanSayaci;
        }
        else {
            GameObject[] go = GameObject.FindGameObjectsWithTag("balon");
            for (int i = 0;i<go.Length;i++) {
                Instantiate(patlama,go[i].transform.position,go[i].transform.rotation);
                Destroy(go[i]);
            }
        }
    }
    public void BalonEkle() {
        PatlayanBalon += 1;
        balonText.text = "Balon:" + PatlayanBalon;
    }
}
