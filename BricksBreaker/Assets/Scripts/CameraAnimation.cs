using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private Vector3 pos1;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        transform.position = new Vector3(pos1.x,pos1.y-6f,pos1.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pos1, 2 * Time.deltaTime);
    }
}
