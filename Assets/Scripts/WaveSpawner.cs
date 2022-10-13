using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TMP_Text waveCountdownText;

    private int waveIndex = 0;

       private void Update()
    {
        if (countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }


       
        waveCountdownText.text = Mathf.Ceil(countdown).ToString(); //Mathf.Round(countdown).ToString();
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
       
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    }
