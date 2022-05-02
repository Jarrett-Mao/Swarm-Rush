using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    public GameObject gameObject;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        
        health -= 1;
        if (health == 0){
            GameObject.Destroy(gameObject);
            scoreManager.score += 10;
            scoreManager.updateScore();
        }
        
    }
}
