using UnityEngine;

public class ShootingShortRange : MonoBehaviour
{
    public int damage;
    public float range;
    public float fireRate = 15f;
    public float nextTimeToFire = 0f;
    public int magazineSize, bulletsLeft;
    public float reloadTime;
    public bool isReloading, isShooting;
    public Camera cam;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Rigidbody rb;
    
    private Vector3 mousePos;
    private void Awake()
    {
        bulletsLeft = magazineSize;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (isShooting && !isReloading && bulletsLeft > 0 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !isReloading)
        {
            Reload();
        }
        
        mousePos = cam.WorldToScreenPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.up, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        bulletsLeft--;
    }

    void Reload()
    {
        isReloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
    }
}