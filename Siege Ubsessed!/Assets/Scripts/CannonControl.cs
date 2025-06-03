using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public GameObject projectilePrefab;   // Префаб снаряда
    public Transform firePosition;       // Точка вылета снаряда
    public float rotationSpeed = 10f;    // Скорость вращения орудия
    public float minAngle = -45f;        // Минимальный допустимый угол поворота
    public float maxAngle = 45f;         // Максимальный допустимый угол поворота
    public float shotCooldown = 0.5f;   // Время перезарядки между выстрелами
    private float nextFireTime = 0f;     // Следующий возможный момент выстрела

    void Update()
    {
        RotateTowardsMouse();            // Следуем за положением курсора

        if(Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            FireProjectile();            // Выполняем выстрел
            nextFireTime = Time.time + shotCooldown;
        }
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x,
                                        mousePos.y - transform.position.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);              // Ограничиваем угол поворота

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FireProjectile()
    {
        GameObject proj = Instantiate(projectilePrefab, firePosition.position, firePosition.rotation);
        proj.GetComponent<Projectile>().speed = 10f;                // Можно задать любую постоянную скорость
    }
}