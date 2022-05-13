using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseract : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ScoreManager scoreManager;
    
    public GameObject UIComponents;

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

        if (collider.gameObject.tag == "Zergling" || collider.gameObject.tag == "Hydralisk" ||
        collider.gameObject.tag == "Infestor" || collider.gameObject.tag == "Infested" ){
            //updates high score
            scoreManager.updateHighScore(); 

            //stops spawning and deletes all existing enemies
            spawnManager.stopSpawning();
            foreach (Enemy enemy in GameObject.FindObjectsOfType<Enemy>()){
                GameObject.Destroy(enemy.gameObject);
            }
            foreach (InfestorEnemy iEnemy in GameObject.FindObjectsOfType<InfestorEnemy>()){
                GameObject.Destroy(iEnemy.gameObject);
            }
            GameObject.Destroy(gameObject);

            //sets buttons to active 
            UIComponents.gameObject.SetActive(true);

            //effectively pauses the game
            Time.timeScale = 0;


        }
        
    }

    
}
