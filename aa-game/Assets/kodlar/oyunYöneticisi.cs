using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class oyunYöneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject anaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir, iki,uc;
    public int kacKucukCemberOlsun;
    bool kontrol = true;

    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));


        donenCember = GameObject.FindGameObjectWithTag("donencemberTag");
        anaCember = GameObject.FindGameObjectWithTag("anaCemberTag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;
        if (kacKucukCemberOlsun < 2)
        {
            bir.text = kacKucukCemberOlsun + "";
        }
        else if (kacKucukCemberOlsun < 3)
        {
            bir.text = kacKucukCemberOlsun + "";
            iki.text = (kacKucukCemberOlsun - 1) + "";
        }
        else
        {
            bir.text = kacKucukCemberOlsun + "";
            iki.text = (kacKucukCemberOlsun - 1) + "";
            uc.text = (kacKucukCemberOlsun - 2) + "";
        }
    }

    public void KucukCemberlerdeTextGosterme()
    {
        kacKucukCemberOlsun--;
        if (kacKucukCemberOlsun < 2)
        {
            bir.text = kacKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kacKucukCemberOlsun < 3)
        {
            bir.text = kacKucukCemberOlsun + "";
            iki.text = (kacKucukCemberOlsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kacKucukCemberOlsun + "";
            iki.text = (kacKucukCemberOlsun - 1) + "";
            uc.text = (kacKucukCemberOlsun - 2) + "";
        }
        if (kacKucukCemberOlsun == 0)
        {
            StartCoroutine(yeniLevel());
        }
    }
    IEnumerator yeniLevel()
    {
        donenCember.GetComponent<dondurme>().enabled = false;
        anaCember.GetComponent<anaCember>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
    }
    public void OyunBitti()
    {
        StartCoroutine(CagrilanMetot());
        }
    IEnumerator CagrilanMetot()
    {
        donenCember.GetComponent<dondurme>().enabled = false;
        anaCember.GetComponent<anaCember>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;
        yield return new WaitForSeconds(2);

        
        SceneManager.LoadScene("AnaMenu");
    }
}
