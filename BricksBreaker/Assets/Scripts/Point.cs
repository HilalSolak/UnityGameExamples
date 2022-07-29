using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private int point;
    public void puanPlusser() {
        point++;
    }
    public int tookPoint() {
        return point;
    }
    public void PuanSifirla() {
        point = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
