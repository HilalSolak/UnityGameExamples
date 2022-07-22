using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncukontrol : MonoBehaviour
{
    public AudioClip atisSesi, olmeSesi, canAlmaSesi, yaralanmaSesi;
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject patlama;
    public Image canImaj;
    public float canDegeri = 100;
    public oyunkontrolu oKontrol;
    private AudioSource aSource;
  
    void Start()
    {
        aSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            aSource.PlayOneShot(atisSesi, 1f);
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
            GameObject goPatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;
            Destroy(go.gameObject, 2f);
            Destroy(goPatlama.gameObject, 2f);

        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            Debug.Log("zombi saldýrýda. ");
            canDegeri -= 10f;
            float x = canDegeri / 100f;
            canImaj.fillAmount = x;
            canImaj.color = Color.Lerp(Color.red, Color.green, x);
            if (canDegeri <= 0)
            {
                aSource.PlayOneShot(olmeSesi, 1f);
                oKontrol.OyunBitti();
            }
        }
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("kalp"))
        {
            aSource.PlayOneShot(canAlmaSesi, 1f);
            if (canDegeri < 100)
            {
                canDegeri += 10f;
                float x = canDegeri / 100f;
                canImaj.fillAmount = x;
                canImaj.color = Color.Lerp(Color.red, Color.green, x);
                Destroy(c.gameObject);
            }
        }
    }
}
