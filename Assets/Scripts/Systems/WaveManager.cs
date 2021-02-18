using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EnemysTypes;
    [SerializeField]
    List<BoxCollider> SpawnPoints;
    [SerializeField]
    int wave;
    [SerializeField]
    int EnemysPerWave;
    [SerializeField]
    bool isSpawningWave;
    [SerializeField]
    int LASTWAVE = 10;

    private StatMoverScript StatMover;

    [Header("UI")]
    [SerializeField]
    private Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        StatMover = FindObjectOfType<StatMoverScript>();
        isSpawningWave = false;
        ScoreText.text = "Curent Wave: " + wave.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wave >LASTWAVE)
        {
            SceneManager.LoadScene("Victory");
        }
        if (!isSpawningWave && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        isSpawningWave = true;
        int WhichSpawnPoint = Random.Range(0, SpawnPoints.Count);
        int EnemyTypeToSpawn = Random.Range(0, EnemysTypes.Count);
        wave++;
        ScoreText.text = "Curent Wave: " + wave.ToString();
        StatMover.WaveReached = wave;
        for (int i = 0; i < EnemysPerWave; i++)
        {
            Instantiate(EnemysTypes[EnemyTypeToSpawn], SpawnPoints[WhichSpawnPoint].transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        isSpawningWave = false;
    }

}
