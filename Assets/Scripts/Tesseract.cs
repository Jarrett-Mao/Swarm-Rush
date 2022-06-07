using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseract : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ScoreManager scoreManager;
    
    public GameObject UIComponents;

    public Material noPower;
    public Material hasPower;

    private int rechargeTime = 5;
    private bool clickable = false;

    [SerializeField]
    private GameObject killwave;
    private GameObject wave;
    // public SpriteRenderer sr;
    // public Sprite newSprite;

    // ArrayList enemyList = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("powerUp");
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

    IEnumerator powerUp(){
        yield return new WaitForSeconds(rechargeTime);
        this.GetComponent<SpriteRenderer>().material = hasPower;
        clickable = true;
        rechargeTime += 1;
        Debug.Log(rechargeTime);
        Debug.Log(clickable);
    }

    void OnMouseDown(){
        Debug.Log("outside");
        if (clickable == true){
            StartCoroutine("spawnWave");
            Debug.Log("inside");
        }
        
    }

    IEnumerator spawnWave(){
        wave = Instantiate(killwave, gameObject.transform.position, Quaternion.identity);
        clickable = false;
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<SpriteRenderer>().material = noPower;
        StartCoroutine("powerUp");
    }
}
