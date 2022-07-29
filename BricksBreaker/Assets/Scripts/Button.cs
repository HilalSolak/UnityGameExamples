using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
   
    public void otherScene()
    {
        Brick.AllBricks = 0;
        GameObject.FindObjectOfType<Point>().GetComponent<Point>().PuanSifirla();
        SceneManager.LoadScene("Level1");
    }
}
