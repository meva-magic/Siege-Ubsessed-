using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;          
    public float mass;                 
    public GameObject hitEffectPrefab; 
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime); // движение снаряда
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Castle"))
        {
            CastleWall wall = other.GetComponent<CastleWall>();
            Citadel citadel = other.GetComponent<Citadel>();

            if (wall != null)
            {
                wall.TakeDamage(mass);   // наносим урон стенке
                SpawnHitEffect();        // спавним эффект
            }
            else if (citadel != null)
            {
                citadel.TakeDamage(mass); // наносим урон цитадели
                SpawnHitEffect();        // спавним эффект
            }

            Destroy(gameObject);          // уничтожаем снаряд
        }
    }

    void SpawnHitEffect()
    {
        if(hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}