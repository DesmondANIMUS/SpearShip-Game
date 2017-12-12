using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;
    public float startHealth = 100;
    public int worth = 10;    

    [HideInInspector]
    internal float currentHealth;

    public GameObject enemyDeathEffect;
    public Image healthBar;
    public Text healthText;
    public Image healthBar2;
    public Text healthText2;

    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        currentHealth = startHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        healthText.text = currentHealth.ToString();
        healthBar.fillAmount = currentHealth / startHealth;
        healthText2.text = currentHealth.ToString();
        healthBar2.fillAmount = currentHealth / startHealth;

        if (currentHealth / startHealth <= 0.3f)
        {
            healthBar.color = Color.red;
            healthBar2.color = Color.red;
        }

        if (currentHealth <= 0 && !isDead)
            DeadEnemy();        
    }

    public void SlowDown(float slow)
    {
        if (speed <= 0.1f)
            return;
        speed -= slow;
    }       
    
    private void DeadEnemy()
    {
        isDead = true;
        PlayerStats.Money += worth;

        var effect = Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);        
        Destroy(effect, 0.25f);

        WaveSpawnerScript.enemiesAlive--;
        Destroy(gameObject);        
    }    
}
