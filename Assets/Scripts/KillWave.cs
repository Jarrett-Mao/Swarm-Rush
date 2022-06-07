using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("this is the start");
        StartCoroutine(destroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void isTri

    // private void OnTriggerEnter2D(Collider2D enemy){
    //         GameObject enemyGameObject = enemy.gameObject;
    //         switch (enemy.gameObject.tag){
    //         case "Zergling":
    //             enemyGameObject.Destroy(enemyGameObject);
    //             break;
    //         case "Hydralisk":
    //             enemyGameObject.Destroy(enemyGameObject);
    //             break;
    //         case "Infestor":
    //             enemyGameObject.Destroy(enemyGameObject);
    //             break;
    //         case "Infested":
    //             enemyGameObject.Destroy(enemyGameObject);
    //             break;
    //     }
    // }

    IEnumerator destroySelf(){
        // Debug.Log("killingself");
        yield return new WaitForSeconds(1.1f);
        GameObject.Destroy(gameObject);
    }
}
