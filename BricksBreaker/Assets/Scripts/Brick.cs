using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject crashEffect;
    public AudioClip voiceEffectBrick;
    public AudioClip voiceEffectCrash;
    public static int AllBricks;
    public Sprite[] brickSprite;
    private int maxCarpmaSayisi;
    private int carpmaSayisi;
    private Point pointSc;
    // Start is called before the first frame update
    void Start()
    {
        maxCarpmaSayisi = brickSprite.Length + 1;
        AllBricks++;
        pointSc = GameObject.FindObjectOfType<Point>().GetComponent<Point>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("top")) {
            carpmaSayisi++;
            pointSc.puanPlusser();
            
            if (carpmaSayisi >= maxCarpmaSayisi) {
                AllBricks--;
                if (AllBricks <= 0) {
                    GameObject.FindObjectOfType<gameControl>().GetComponent<gameControl>().nextScene();
                }
               
                AudioSource.PlayClipAtPoint(voiceEffectCrash, transform.position);
                Destroy(this.gameObject);
            }else
                AudioSource.PlayClipAtPoint(voiceEffectBrick, transform.position);
            GetComponent<SpriteRenderer>().sprite = brickSprite[carpmaSayisi - 1];
        }
        
    }
}
