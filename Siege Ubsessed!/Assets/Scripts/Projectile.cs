using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;      // Скорость снаряда
    public float mass = 10f;       // Масса снаряда (определяет силу повреждения)

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime); // Перемещение снаряда вперёд
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Castle")) // Проверяем столкновение с объектом, помеченным тегом "Castle"
        {
            CastleWall castleWall = other.GetComponent<CastleWall>(); // Пробуем получить компонент CastleWall
            Citadel citadel = other.GetComponent<Citadel>(); // Пробуем получить компонент Citadel

            if (castleWall != null || citadel != null) // Если хотя бы один компонент найден
            {
                if (castleWall != null)
                    castleWall.TakeDamage(mass); // Применяем повреждение стене замка
                else
                    citadel.TakeDamage(mass); // Или применяем повреждение цитадели

                Destroy(gameObject); // Самоуничтожение снаряда после попадания
            }
        }
    }
}