using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private Transform target;
    private EnemyScript enemy;
    private float uppingSpeed = 10f;    

    [Header("General")]
    public float range = 15f;

    [Header("Uses Bullets(Default)")]
    public float fireRate = 5f; //1 bullet 1 second
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;

    [Header("Laser Stuff")]
    public bool useLaser = false;
    public LineRenderer laserLine;
    public ParticleSystem impactEffect;
    public Light impactLight;
    public int damageOverTime = 35;
    public float speedOverTime = 5f;

    [Header("Unity Setup")]
    public string enemyTAG = "Enemy";
    public Transform partRotator;
    public float turnSpeed = 10f;    
    public Transform firePoint;

	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);        
	}
	
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTAG);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestDistance >= distanceToEnemy)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemy = nearestEnemy.GetComponent<EnemyScript>();            
        }

        else
            target = null;
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (laserLine.enabled)
                {                    
                    laserLine.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;                    
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
            LaserPower();

        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1 / fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bullet = bulletGO.GetComponent<BulletScript>();
        if (bullet != null)
            bullet.Seek(target);
    }

    private void LockOnTarget()
    {        
        Vector3 direction = target.position - transform.position;

        // Unity's way of dealing with rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // eulerAngles are those x, y, z coordinates you see in the inspector
        // for smooth transitioniong we are using lerp function
        Vector3 rotation = Quaternion.Lerp(partRotator.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partRotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // We could have just used this but it was making the turret turn awkwardly quick
        //Vector3 rotation = lookRotation.eulerAngles;
    }

    private void LaserPower()
    {
        enemy.TakeDamage(damageOverTime * Time.deltaTime);
        enemy.SlowDown(speedOverTime);

        if (!(laserLine.enabled))
        {
            laserLine.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, target.position);        

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
}
