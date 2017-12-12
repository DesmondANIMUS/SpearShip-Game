using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawnerScript : MonoBehaviour
{
    public WaveData[] waves;
    public static int enemiesAlive = 0;    
    public Transform spawnPoint;
    public Text WaveTimer;        
    public GameManager gameManager;
    public float timeBetweenWaves = 2f;

    private float countDoun = 2f;
    private int waveIndex = 0;
    private float coRoutineTime = 1f;

    private void Start()
    {
        enemiesAlive = 0;
    }

    private void Update ()
    {
        if (enemiesAlive > 0)
            return;

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            enabled = false;
        }

        if (countDoun <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDoun = timeBetweenWaves;
        }

        countDoun -= Time.deltaTime;

        countDoun = Mathf.Clamp(countDoun, 0f, Mathf.Infinity);
        string time = string.Format("{0:00.00}", countDoun);
        WaveTimer.text = "Time: " + time;
    }

    IEnumerator SpawnWave()
    {        
        PlayerStats.Rounds++;
        WaveData wave = waves[waveIndex];
        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(coRoutineTime / wave.spawnRate);
        }
        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {       
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);        
    }
}