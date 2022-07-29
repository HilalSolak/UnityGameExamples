using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTheGame : MonoBehaviour
{
    public UnityEngine.UI.Text point;
    // Start is called before the first frame update
    void Start()
    {
        point.text = "Puanýnýz :"+ GameObject.FindObjectOfType<Point>().GetComponent<Point>().tookPoint() ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToMainScene() {
        SceneManager.LoadScene(0);
            
            
            }
}
