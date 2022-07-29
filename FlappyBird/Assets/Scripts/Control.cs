using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
    public Sprite[] birdSprite;
    SpriteRenderer spriteRender;
    bool nextbackCont = true;
    int birdtemp = 0;
    float birdAnimTime;
    Rigidbody2D physic;
    int point = 0;
    public Text pointText;
    bool gameOver = true;
    GameControl gameControl;
    AudioSource[] voice;
    int bestPoint = 0;
   
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        physic = GetComponent<Rigidbody2D>();
        gameControl = GameObject.FindGameObjectWithTag("gameControl").GetComponent<GameControl>();
        
        voice = GetComponents<AudioSource>();
        bestPoint = PlayerPrefs.GetInt("log");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& gameOver) {
            physic.velocity = new Vector2(0,0);//speed=0 right now
            physic.AddForce(new Vector2(0,200));
            voice[0].Play();
        }
        if (physic.velocity.y>0) {
            transform.eulerAngles = new Vector3(0,0,45);
        }
        else {
            transform.eulerAngles = new Vector3(0, 0, -45);

        }
        birdAnimation();


    }
    void birdAnimation()
    {
        birdAnimTime += Time.deltaTime;
        if (birdAnimTime > 0.1f)
        {
            birdAnimTime = 0;
            if (nextbackCont)
            {
                spriteRender.sprite = birdSprite[birdtemp];
                birdtemp++;
                if (birdtemp == birdSprite.Length)
                {
                    birdtemp--;
                    nextbackCont = false;
                }
            }
            else
            {
                birdtemp--;
                spriteRender.sprite = birdSprite[birdtemp];
                if (birdtemp == 0)
                {
                    birdtemp++;
                    nextbackCont = true;
                }
            }
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="point") {
            point++;
            pointText.text = "Score : "+point;
            voice[1].Play();

        }
        if (collision.gameObject.tag=="obstacle") {

            gameOver = false;
            voice[2].Play();
            gameControl.gameOver();
            GetComponent<CircleCollider2D>().enabled = false;
            if (point>bestPoint) {
                bestPoint = point;
                PlayerPrefs.SetInt("log",bestPoint);
            }
            Invoke("goToMainMenu",2);
            
        }
    }
    void goToMainMenu()
    {
        PlayerPrefs.SetInt("log2",point);
        SceneManager.LoadScene("MainMenu");
        
    }
}
