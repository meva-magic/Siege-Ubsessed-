using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem; 

public class CannonControl : MonoBehaviour
{
    public GameObject projectilePrefab;   
    public Transform firePosition;       
    public float rotationSpeed = 10f;   
    public float shotCooldown = 0.5f;   
    private float nextFireTime = 0f;     
    public Slider massSlider;            

    void Update()
    {
        RotateTowardsMouse();

        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time > nextFireTime)
        {
            FireProjectile((float)massSlider.value); // передача массы снаряда
            nextFireTime = Time.time + shotCooldown;
        }
    }

    void RotateTowardsMouse()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);
        float targetRotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetRotationZ = Mathf.Clamp(targetRotationZ, 45f, 135f);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, targetRotationZ), rotationSpeed * Time.deltaTime);
    }

    void FireProjectile(float mass)
    {
        GameObject proj = Instantiate(projectilePrefab, firePosition.position, firePosition.rotation);
        proj.GetComponent<Projectile>().mass = mass; // установка массы снаряда
        proj.GetComponent<Rigidbody2D>().linearVelocity = transform.up.normalized * 10f; // скорость снаряда
    }
}