using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;
    public float minimumEnemyHealthThreshold = 30f;
    public float maximumEnemyHealthThreshold = 80f;
    public int moneyTaken = 100;

    private EnemyScript enemy;

    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        target = WaypointScript.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWayPoint();

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWayPoint()
    {
        if (wavePointIndex >= WaypointScript.points.Length - 1)
        {
            EndOfPath();
            return;
        }

        wavePointIndex++;
        target = WaypointScript.points[wavePointIndex];
    }

    private void EndOfPath()
    {        
        if (enemy.currentHealth < minimumEnemyHealthThreshold)
            PlayerStats.Lives -= 3;
        else if (enemy.currentHealth > maximumEnemyHealthThreshold)
        {
           PlayerStats.Lives -= 1;
           PlayerStats.Money -= moneyTaken;
        }
        else
            PlayerStats.Lives -= 2;

        WaveSpawnerScript.enemiesAlive--;
        Destroy(gameObject);                
    }
}
