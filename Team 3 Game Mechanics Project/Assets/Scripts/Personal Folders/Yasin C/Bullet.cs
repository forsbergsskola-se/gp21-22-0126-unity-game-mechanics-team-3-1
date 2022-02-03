using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Enemie")
        {
            Destroy(collision.gameObject);
        }
    }
}
