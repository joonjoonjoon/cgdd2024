using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTrigger : MonoBehaviour
{

    public float maxReflectAngle;
    void OnTriggerEnter2D(Collider2D collider)
    {
        var ball = collider.attachedRigidbody;
        var ballAngle = Vector2.Angle(transform.up, ball.velocity);
        
        if(ballAngle > 90)
        {
            var reflect = Vector2.Reflect(ball.velocity, transform.up);
            var reflectAngle = Vector2.SignedAngle(transform.up, reflect);

            if(Mathf.Abs(reflectAngle) > maxReflectAngle)
            {

                var delta = (maxReflectAngle - Mathf.Abs(reflectAngle)) * Mathf.Sign(reflectAngle);
                var clampedRot = Quaternion.Euler(0,0,delta );
                reflect = clampedRot * reflect;
            }
            ball.velocity = reflect;

            if(Game_Cool.i != null)
                Game_Cool.i.AddScore();
            if(Game.i != null)
                Game.i.AddScore();
        }
    }
}
