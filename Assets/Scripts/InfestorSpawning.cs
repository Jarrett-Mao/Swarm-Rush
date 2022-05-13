using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfestorSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;

    public Transform infestedLocation;
    public Transform infested1Location; 
    public Transform infested2Location;
    public Transform infested3Location;
    public Transform infested4Location; 

    [SerializeField]
    private GameObject infested;

    private GameObject newEnemy;
    private GameObject newEnemy1;
    private GameObject newEnemy2;
    private GameObject newEnemy3;
    private GameObject newEnemy4;

    // public Enemy enemy;


    void Start()
    {
        infestedLocation = gameObject.transform.GetChild(0).gameObject.transform;
        infested1Location = gameObject.transform.GetChild(1).gameObject.transform;
        infested2Location = gameObject.transform.GetChild(2).gameObject.transform;
        infested3Location = gameObject.transform.GetChild(3).gameObject.transform;
        infested4Location = gameObject.transform.GetChild(4).gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if (enemy.health <= 0){
        //     SpawnInfested();
        // }
    }

    public void SpawnInfested(){
        newEnemy = Instantiate(infested, infestedLocation.position, Quaternion.identity);
        newEnemy1 = Instantiate(infested, infested1Location.position, Quaternion.identity);
        newEnemy2 = Instantiate(infested, infested2Location.position, Quaternion.identity);
        newEnemy3 = Instantiate(infested, infested3Location.position, Quaternion.identity);
        newEnemy4 = Instantiate(infested, infested4Location.position, Quaternion.identity);
    }


}
