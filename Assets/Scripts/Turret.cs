using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    [Header("Atributes")]
    public float range = 15f;

    [Header("Bullets")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Laser (optional)")]
    public bool hasLaser = false;

    public int damageOverTime = 30;

    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public Light laserLight;

    [Header("Unity UI Setup")]
    public string enemyTag = "Enemy";

    public Transform toRotate;
    public float turnSpeed = 10f;

    
    public Transform firePoint;

   


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(hasLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserEffect.Stop();
                    laserLight.enabled = false;

                }
                    
            }
            return;
        }

        LockOnTarget();
         if(hasLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
       
        
        
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(toRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        toRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void Laser()
    {
        target.GetComponent<Enemy>().TakeDamage(damageOverTime * Time.deltaTime);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserEffect.Play();
            laserLight.enabled = true;
        }
            

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        laserEffect.transform.position = target.position + dir.normalized;

        laserEffect.transform.rotation = Quaternion.LookRotation(dir);

        
    }

    void Shoot()
    {
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
