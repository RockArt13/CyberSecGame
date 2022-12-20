using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;


    public float startHealth = 100f;
    private float health;

    public int value = 50;

    public GameObject deathEffect;

    [Header("Unity Related")]
    public Image healthBar;

    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }



    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health<0 && !isDead)
        {
            Die();
        }
    }

    public void Slow (float range)
    {
        speed = startSpeed * (1f - range);
    }


    void Die()
    {
        isDead = true;
        PlayerState.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
   
}
