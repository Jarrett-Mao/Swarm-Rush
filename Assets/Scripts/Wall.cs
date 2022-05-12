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

    private int zerglingTouching = 0;
    private int hydraTouching = 0;
    private int infestorTouching = 0;

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

    //returns a percentage of health
    float calculateHealth(){
        return health / maxHealth;
    }

    //when enemies touch the wall they are counted
    private void OnTriggerEnter2D(Collider2D enemy){ 
        // takeDamage = true;
        // if (enemy.gameObject.tag == "Zergling"){
        //     // Debug.Log("enter");
        //     zerglingTouching += 1;  
        // }
        switch (enemy.gameObject.tag){
            case "Zergling":
                zerglingTouching += 1;
                break;

            case "Hydralisk":
                hydraTouching += 1;
                break;
            case "Infestor":
                infestorTouching += 1;
                break;
        }
    }

    //when enemies are destroyed they are counted
    private void OnTriggerExit2D(Collider2D enemy){
        // takeDamage = false;
        // if (enemy.gameObject.tag == "Zergling"){
        //     // Debug.Log("exit");
        //     zerglingTouching -= 1;  
        // }
        switch (enemy.gameObject.tag){
            case "Zergling":
                zerglingTouching -= 1;
                break;
                
            case "Hydralisk":
                hydraTouching -= 1;
                break;
            case "Infestor":
                infestorTouching -= 1;
                break;
        }
    }

    IEnumerator loseHealth(){
        float damageValue = (0.25f * zerglingTouching) + (0.5f * hydraTouching) + (0.75f * infestorTouching);

        health -= damageValue;
        
        yield return new WaitForSeconds(3.0f);
        // yield return null;
    }
}
