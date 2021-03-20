using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 3f;

    public Text waveCountDownText;

    public int waveNumber=0;


    void Update()
    {
        if (countdown <=0)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = "Next wave:\n" + string.Format("{0:00.0}", countdown);
        //Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnWave()
    {
        if (waveNumber == 8)
        {
            waveNumber = 0;
        }
        waveNumber ++;
        for (int i=0; i< waveNumber; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
