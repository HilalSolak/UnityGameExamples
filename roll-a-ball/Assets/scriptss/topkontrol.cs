using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class topkontrol : MonoBehaviour
{
    Rigidbody fizik;
    public int hiz;
    int sayac = 0;
    public int ToplanýlacakobjeSayisi;
    public Text sayacText;
    public Text OyunBittiText;
    void Start()
   {
        fizik = GetComponent<Rigidbody>();  
    }
    void Update() //topun ilerleme yönleri x ve x yönlerinde hareket edebilir yukarý aþaðý gidemez.
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");
        Debug.Log("yatay= " + yatay +  "   dikey= "+ dikey);
        Vector3 vec = new Vector3(yatay,0, dikey);
        fizik.AddForce(vec*hiz);
    }
    private void OnTriggerEnter(Collider other)//topumuz engele deðdiðinde engeli gözden kaybetmek
    {
        if (other.gameObject.tag == "engel")
        {
            other.gameObject.SetActive(false);
            sayac++;
            sayacText.text = "Sayac= " + sayac; //engellere deðdikçe puan topluyoruz.
            if(sayac== ToplanýlacakobjeSayisi)
            {
                OyunBittiText.text = "OYUN BÝTTÝ "; //tüm engeller bittiðinde oyun bitti yazýsýný ekrana ver.
            }
        }
    }

}
