using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;
    public float expRadius = 0f;
    public float speed = 70f;

    public int damgeEnemy = 20;    

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);
        transform.LookAt(target);
	}

    private void HitTarget()
    {        
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);

        if (expRadius > 0f)
            Explode(target);    
        else
            Damage(target);

        Destroy(gameObject);        
    }

    void Damage(Transform enemyGO)
    {
        var enemy = enemyGO.GetComponent<EnemyScript>();
        if (enemy != null)
            enemy.TakeDamage(damgeEnemy);
    }

    void Explode(Transform e)
    {
        Collider[] hitObjects = Physics.OverlapSphere(e.position, expRadius);
        foreach(var hit in hitObjects)
        {
            if (hit.CompareTag("Enemy"))
                Damage(hit.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, expRadius);        
    }
}
