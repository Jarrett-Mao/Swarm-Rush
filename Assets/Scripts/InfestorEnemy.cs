using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfestorEnemy : MonoBehaviour
{
    //health bar variables
    public float maxHealth;
    public float health;
    public int pointValue;
    public Slider slider;
    public GameObject healthBarUI;
    
    [SerializeField]
    private InfestorSpawning infestorSpawning;

    public float speed;
    public GameObject gameObject;
    public ScoreManager scoreManager;

    public Transform tesseract;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
        // Vector3 direction = tesseract.position - transform.position;
        // Debug.Log(tesseract.position);
        rb = this.GetComponent<Rigidbody2D>();
        tesseract = GameObject.FindWithTag("Tesseract").transform;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

        health = maxHealth;
        slider.value = calculateHealth();
        healthBarUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var direction = tesseract.position - transform.position;
        var angle = Mathf.Atan2(direction.y, (direction.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        direction.Normalize();
        movement = direction;

        slider.value = calculateHealth(); //health bar status
        if(health < maxHealth){
            healthBarUI.SetActive(true); 
        } 
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void OnMouseDown(){
        
        health -= 1;
        if (health <= 0){
            infestorSpawning.SpawnInfested();
            destroySelf();
            scoreManager.updateScore(pointValue);
        }

    }

    public void destroySelf(){
        GameObject.Destroy(gameObject);
    }

    float calculateHealth(){
        return health / maxHealth;
    }


}
