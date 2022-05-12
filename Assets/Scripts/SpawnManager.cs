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

    private float spawnSpeed = 2.0f;
    private int spawnCounter = 0;

    ArrayList enemyList = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnEnemy", 0f, 2.0f);
        StartCoroutine(SpawnEnemy(spawnSpeed));

    }

    // Update is called once per frame
    void Update()
    {
        // if ((float)Time.deltaTime % 5.0f == 1){
        //     spawnSpeed -= 0.2f;
        // }
    }

    IEnumerator SpawnEnemy(float time){
        yield return new WaitForSeconds(time);

        while (true){
            randomSpawnZone = Random.Range(0, 4);

            //spawning in random ranges
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
            
            //add enemy to the list
            enemyList.Add(enemy);
            spawnCounter += 1;

            if (spawnCounter % 5 == 1){
                spawnSpeed -= 0.1f;
                // Debug.Log(spawnSpeed);
            }
            
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    public void stopSpawning(){
        StopAllCoroutines();

    }

    public void newGame(){
        spawnSpeed = 2.0f;
        spawnCounter = 0;
    }
}
