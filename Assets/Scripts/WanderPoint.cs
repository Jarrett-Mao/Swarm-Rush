using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderPoint : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private GameObject vehicle;
    private Transform target;
    private Transform avoidTarget;
    // private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 targetLocation;

    private float theta;

    private bool moveToTarget = true;
    private bool goRight;

    Vector3 right = new Vector3(0.2f, 0f, 0f);
    Vector3 left = new Vector3(0.2f, 0f, 0f);

    // public Body body;

    //braitenburg vehicle detects if other enemies are at the location
    //if so then move out of the current path to go elsewhere on the wall
    //does the target need to swtich from the 1st wall to the 2nd etc. until the tesseract?


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Tesseract").transform;
        targetLocation = target.position;
    }

    void FixedUpdate(){
        //calculates where the tesseract is and rotates towards it
        var direction = target.position - transform.position;
        // var angle = Mathf.Atan2(direction.y, (direction.x)) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        direction.Normalize();
        // movement = direction;
        if (moveToTarget == true){
            moveCharacter(targetLocation);    
        }
        else {
            avoid(avoidTarget);
        }
        
    }

    //moves the character forward based off the direction calculated in update()
    private void moveCharacter(Vector3 target){
        // rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
        // Debug.Log((target - transform.position).normalized * speed * Time.deltaTime);
    }

    private void avoid(Transform enemy){
        

        Vector3 enemyPosition = enemy.position;
        if (goRight){
            this.transform.position += ((right).normalized * speed * Time.deltaTime);
        }
        else {
            this.transform.position += ((left).normalized * speed * Time.deltaTime);
        }
        
        // this.transform.position += ((enemyPosition - transform.position).normalized * speed * Time.deltaTime);
        Debug.Log("avoiding!");
        Debug.Log(moveToTarget);
    }

    private void OnTriggerEnter2D(Collider2D enemy){
        if (enemy.gameObject.tag == "Zergling" || enemy.gameObject.tag == "Hydralisk" ||
        enemy.gameObject.tag == "Infestor" || enemy.gameObject.tag == "Infested"){
            moveToTarget = false;
            avoidTarget = enemy.gameObject.transform;
            if (Random.Range(0, 1) == 0){
                goRight = false;
            }
            else {
                goRight = true;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D enemy){
        if (enemy.gameObject.tag == "Zergling" || enemy.gameObject.tag == "Hydralisk" ||
        enemy.gameObject.tag == "Infestor" || enemy.gameObject.tag == "Infested"){
            moveToTarget = true;
        }
    }


    // Update is called once per frame
    // void Update()
    // {
    //     rb.velocity = new Vector2(
    //         Mathf.Clamp(rb.velocity.x, -maxspeed, maxspeed),
    //         Mathf.Clamp(rb.velocity.y, -maxspeed, maxspeed));
    //         // Mathf.Clamp(rb.velocity.z, -maxspeed, maxspeed));

    //     //calculates where the tesseract is and rotates towards it
    //     var direction = target.transform.position - transform.position;
    //     var angle = Mathf.Atan2(direction.y, (direction.x)) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    //     Seek(target.transform.position);
    // }

    // public void Seek(Vector3 target){
    //     Vector3 desired = target - rb.transform.position;
    //     desired.Normalize();
    //     desired *= maxspeed;
    //     Vector3 steer = (Vector2)desired - rb.velocity;

    //     steer.x = Mathf.Clamp(steer.x, -maxforce, maxforce);
    //     steer.y = Mathf.Clamp(steer.y, -maxforce, maxforce);
    //     // steer.z = Mathf.Clamp(steer.z, -maxforce, maxforce);
    //     applyForce(steer);
    // }

    // void applyForce(Vector3 force){
    //     rb.AddForce(force * Time.fixedDeltaTime);
    // }
}
