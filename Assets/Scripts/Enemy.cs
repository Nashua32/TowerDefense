using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex =  0;

    public int health = 100;

    void Start ()
    {
        target = Waypoints.points[0];
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerStats.money += 20;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            PlayerStats.lives --;
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
