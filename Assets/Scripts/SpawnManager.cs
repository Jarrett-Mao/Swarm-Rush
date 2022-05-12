using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject zergling;
    [SerializeField]
    private GameObject hydralisk;
    [SerializeField]
    private GameObject infestor;

    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;

    private float zergSpawnSpeed = 3.0f;
    private int zergCounter = 0;

    private float hydraSpawnSpeed = 5.0f;
    private int hydraCounter = 0;

    private float infestorSpawnSpeed = 8.0f;
    private int infestorCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnEnemy", 0f, 2.0f);
        StartCoroutine(SpawnZerg(zergSpawnSpeed));

    }

    // Update is called once per frame
    void Update()
    {
        // if ((float)Time.deltaTime % 5.0f == 1){
        //     zergSpawnSpeed -= 0.2f;
        // }
    }

    IEnumerator SpawnZerg(float time){
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
            newEnemy = Instantiate(zergling, spawnPosition, Quaternion.identity);
            
            //add enemy to the list
            // enemyList.Add(enemy);
            zergCounter += 1;

            if (zergCounter % 10 == 1){
                zergSpawnSpeed -= 0.1f;
                // Debug.Log(zergSpawnSpeed);
            }

            if (zergCounter == 10){
                StartCoroutine(SpawnHydra(hydraSpawnSpeed));
            }
            
            yield return new WaitForSeconds(zergSpawnSpeed);
        }
    }

    IEnumerator SpawnHydra(float time){
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
            newEnemy = Instantiate(hydralisk, spawnPosition, Quaternion.identity);
            
            //add enemy to the list
            // enemyList.Add(enemy);
            hydraCounter += 1;

            if (hydraCounter % 5 == 1){
                hydraSpawnSpeed -= 0.2f;
                // Debug.Log(spawnSpeed);
            }

            if (hydraCounter == 5){
                StartCoroutine(SpawnInfestor(infestorSpawnSpeed));
            }
            
            yield return new WaitForSeconds(hydraSpawnSpeed);
        }
    }

    IEnumerator SpawnInfestor(float time){
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
            newEnemy = Instantiate(infestor, spawnPosition, Quaternion.identity);
            
            //add enemy to the list
            // enemyList.Add(enemy);
            infestorCounter += 1;

            if (infestorCounter % 3 == 1){
                infestorSpawnSpeed -= 0.5f;
                // Debug.Log(spawnSpeed);
            }
            
            yield return new WaitForSeconds(infestorSpawnSpeed);
        }
    }

    public void stopSpawning(){
        StopAllCoroutines();

    }

    public void newGame(){
        zergSpawnSpeed = 2.0f;
        zergCounter = 0;
        hydraSpawnSpeed = 5.0f;
        hydraCounter = 0;
        infestorSpawnSpeed = 8.0f;
        infestorCounter = 0;
    }
}
