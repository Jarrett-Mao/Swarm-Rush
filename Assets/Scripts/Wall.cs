using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Slider slider;
    public GameObject healthBarUI;

    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = calculateHealth();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = calculateHealth(); //health bar status
        if(health < maxHealth){
            healthBarUI.SetActive(true); 
        } 
        if (health <= 0){
            destroySelf();
        }

        // checkCollision();
        
    }

        void destroySelf(){
        GameObject.Destroy(gameObject);
    }

    float calculateHealth(){
        return health / maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D enemy){
        if (enemy.gameObject.tag == "Zergling"){
            health -= 1;
            Debug.Log(health);
        }
        
    }
}
