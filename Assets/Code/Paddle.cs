using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Paddle : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) ||  Input.GetMouseButton(0))
        {
            transform.Rotate(0,0,speed);
        
        }
    }
}
