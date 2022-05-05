using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseract : MonoBehaviour
{
    public SpawnManager spawnManager;

    // ArrayList enemyList = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        
        // Debug.Log("testing");

        if (collider.gameObject.tag == "Zergling"){
            spawnManager.stopSpawning();
            foreach (Enemy enemy in GameObject.FindObjectsOfType<Enemy>()){
                GameObject.Destroy(enemy.gameObject);
            }
        }
        
    }

    
}
