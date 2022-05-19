using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private GameObject vehicle;
    private Transform target;
    // private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 targetLocation;

    // public Body body;

    //braitenburg vehicle detects if other enemies are at the location
    //if so then move out of the current path to go elsewhere on the wall
    //does the target need to swtich from the 1st wall to the 2nd etc. until the tesseract?


    // Start is called before the first frame update
    void Start()
    {
        // rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Tesseract").transform;
        targetLocation = target.position;
    }

    void FixedUpdate(){
        //calculates where the tesseract is and rotates towards it
        var direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, (direction.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        // direction.Normalize();
        // movement = direction;

        moveCharacter(targetLocation);
    }

    //moves the character forward based off the direction calculated in update()
    private void moveCharacter(Vector3 target){
        // rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
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
