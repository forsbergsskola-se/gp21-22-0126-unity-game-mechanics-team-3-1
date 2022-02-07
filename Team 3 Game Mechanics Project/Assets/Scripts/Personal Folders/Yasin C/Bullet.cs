using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollision()
    {
        Destroy(gameObject, 5f); 
    }
}
