using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 50f;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb= bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up*bulletForce,ForceMode.Impulse);
    }
}
