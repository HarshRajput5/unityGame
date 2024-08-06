using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScore : MonoBehaviour
{
    public void DestoryMethod(){
        Destroy(gameObject);
    }
    
    void Update()
    {
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
