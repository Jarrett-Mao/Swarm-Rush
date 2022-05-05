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

    public int zerglingTouching = 0;

    // private bool takeDamage = false;

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

        StartCoroutine(loseHealth());
        
    }

        void destroySelf(){
        GameObject.Destroy(gameObject);
    }

    float calculateHealth(){
        return health / maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D enemy){
        // takeDamage = true;
        if (enemy.gameObject.tag == "Zergling"){
            Debug.Log("enter");
            zerglingTouching += 1;  
        }
    }

    private void OnTriggerExit2D(Collider2D enemy){
        // takeDamage = false;
        if (enemy.gameObject.tag == "Zergling"){
            Debug.Log("exit");
            zerglingTouching -= 1;  
        }
    }

    IEnumerator loseHealth(){
        float damageValue = 0.25f * zerglingTouching;

        health -= damageValue;
        
        yield return new WaitForSeconds(3.0f);
        // yield return null;
    }
}
