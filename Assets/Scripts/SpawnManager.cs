using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;

    // public Transform tesseract;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy(){
        randomSpawnZone = Random.Range(0, 4);

        switch (randomSpawnZone){
            case 0:
            randomXposition = Random.Range(-11.0f, -10f);
            randomYposition = Random.Range(-8.0f, -8.0f);
            break;

            case 1:
            randomXposition = Random.Range(-10.0f, 10f);
            randomYposition = Random.Range(-7.0f, -8.0f);
            break;

            case 2:
            randomXposition = Random.Range(10.0f, 11f);
            randomYposition = Random.Range(-8.0f, 8.0f);
            break;

            case 3:
            randomXposition = Random.Range(-10.0f, 10f);
            randomYposition = Random.Range(7.0f, 8.0f);
            break;

        }

        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        // rend = newEnemy.GetComponenet<SpriteRenderer>();
        
    }
}
