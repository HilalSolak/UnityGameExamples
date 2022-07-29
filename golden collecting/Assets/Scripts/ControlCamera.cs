using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public GameControl oyunK;
    float Sens = 5f;
    float hum = 2f;
    Vector2 gecisPos;
    Vector2 camPos;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif) { 
        Vector2 MausePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        MausePos = Vector2.Scale(MausePos,new Vector2(Sens*hum,Sens*hum));
        gecisPos.x = Mathf.Lerp(gecisPos.x,MausePos.x,1f/hum);
        gecisPos.y = Mathf.Lerp(gecisPos.y,MausePos.y,1f/hum);
        camPos += gecisPos;
        transform.localRotation = Quaternion.AngleAxis(-camPos.y,Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(camPos.x,player.transform.up);
        }
    }
}
