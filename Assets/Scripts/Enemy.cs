using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //test  

    //health bar variables
    public float maxHealth;
    public float health;
    public int pointValue;
    public int speed;
    public Slider slider;
    public GameObject healthBarUI;
    
    public bool isTouching = false;

    // public float speed;
    public GameObject gameObject;
    public ScoreManager scoreManager;

    [SerializeField]
    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
        // Vector3 direction = target.position - transform.position;
        // Debug.Log(target.position);
        rb = this.GetComponent<Rigidbody2D>();

        // target = GameObject.FindWithTag("target").transform;
        target = GameObject.FindWithTag("Tesseract").transform;
        
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

        health = maxHealth;
        slider.value = calculateHealth();
        healthBarUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching == false){
            var direction = target.position - transform.position;
            var angle = Mathf.Atan2(direction.y, (direction.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            direction.Normalize();
            movement = direction;

            moveCharacter(movement);
        }

        //calculates current health and activates slider if necessary
        slider.value = calculateHealth(); 
        if(health < maxHealth){
            healthBarUI.SetActive(true); 
        } 
    }

    //moves the character forward based off the direction calculated in update()
    // private void FixedUpdate() {
    //     if (isTouching == false){
    //         moveCharacter(movement);
    //     }
        
    // }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void OnMouseDown(){
        
        health -= 1;
        if (health <= 0){
            destroySelf();
        }

    }

    public void destroySelf(){
        scoreManager.updateScore(pointValue);
        GameObject.Destroy(gameObject);
    }

    float calculateHealth(){
        return health / maxHealth;
    }

    void OnCollisionEnter2D (Collision2D collision){
        if (collision.gameObject.tag == "Wall"){
            isTouching = true;
        }

        if (collision.gameObject.tag == "EnergyNova"){
            destroySelf();
        }
    }

    void OnCollisionExit2D (Collision2D collision){
        if (collision.gameObject.tag == "Wall"){
            isTouching = false;
        }
    }
}
