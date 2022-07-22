using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombihareket : MonoBehaviour
{
    private GameObject oyuncu;
    public GameObject kalp;
    private int zombieCan = 3;
    private int zombidenGelenPuan = 10;
    private float mesafe;
    private oyunkontrolu oKontrol;
    private AudioSource aSource;
    private bool zombieOluyor;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("oyuncu");
        oKontrol= GameObject.Find("scripttts").GetComponent<oyunkontrolu>();
    }

    // Update is called once per frame
    void Update()
    {               
         GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
         mesafe=Vector3.Distance(transform.position,oyuncu.transform.position);
        if (mesafe < 10)
        {
            if(!aSource.isPlaying)
            aSource.Play();
            if(!zombieOluyor)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");

        }
        else
        {
            if(aSource.isPlaying)
                aSource.Stop();
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("çarpýþma gerçekleþti");
            zombieCan--;
            if (zombieCan ==0)
            {
                zombieOluyor = true;
                oKontrol.PuanArtir(zombidenGelenPuan);
                Instantiate(kalp,transform.position,Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
