using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject sky1;
    public GameObject sky2;
    public float backSpeed = -1.5f;
    Rigidbody2D physic1;
    Rigidbody2D physic2;
    float len=0;
    public GameObject obstacle;
    public int howMobst;
    GameObject[] obstacles;
    float delTime = 0;
    int temp;
    bool gameFinished=true;
    
    // Start is called before the first frame update
    void Start()
    {
        physic1 = sky1.GetComponent<Rigidbody2D>();
        physic2 = sky2.GetComponent<Rigidbody2D>();
        physic1.velocity = new Vector2(backSpeed,0);
        physic2.velocity = new Vector2(backSpeed,0);
        len = sky1.GetComponent<BoxCollider2D>().size.x;
        obstacles = new GameObject[howMobst];
        for (int i=0;i<obstacles.Length;i++) {
            obstacles[i] = Instantiate(obstacle,new Vector2(-20,-20),Quaternion.identity);
           Rigidbody2D physic=   obstacles[i].AddComponent<Rigidbody2D>();
            physic.gravityScale = 0;
            physic.velocity = new Vector2(backSpeed,0);
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinished)
        {
            if (sky1.transform.position.x <= -len)
            {

                sky1.transform.position += new Vector3(len * 2, 0);
            }
            if (sky2.transform.position.x <= -len)
            {

                sky2.transform.position += new Vector3(len * 2, 0);
            }
            delTime += Time.deltaTime;
            if (delTime > 2f)
            {

                delTime = 0;
                float YEcs = Random.Range(-0.80f, 1.16f);
                obstacles[temp].transform.position = new Vector3(18, YEcs);
                temp++;
                if (temp >= obstacles.Length)
                {
                    temp = 0;
                }

            }
        }
        else { 
            
        
        }

    }
        public void gameOver() {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            physic1.velocity = Vector2.zero;
            physic2.velocity = Vector2.zero;
        }
        gameFinished = false;
    }
}
