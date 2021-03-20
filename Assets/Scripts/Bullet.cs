using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject hitEffect;

    public int damage = 50;

    public void FindTarget(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed*Time.deltaTime;
        if (dir.magnitude <= distThisFrame)
        {
            Destroy(gameObject);
            GameObject effectIns = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
            if (explosionRadius > 0)
            {
                Explode();
            }
            else
            {
                Damage(target);
            }
            Destroy(effectIns, 5f);
            return;
        }
        transform.Translate(dir.normalized * distThisFrame, Space.World);

        transform.LookAt(target);
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e!= null)
        {
            e.takeDamage(damage);
        }

        //Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
