using UnityEngine;

public class ShootingLongRange : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 50f;
    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody rb;
    
    Vector3 movement;
    Vector3 mousePos;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        mousePos = cam.WorldToScreenPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector3 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }

    private Transform aimTransform; 
    private void Awake()
    {
        aimTransform = transform.Find("firePoint");
    }

    void Shoot()
    {
        GameObject Bullet =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.up, out hit));
    }
}
