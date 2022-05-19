using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadingPoint : MonoBehaviour
{
    public float wanderRadius;
    public Transform wanderPoint;

    private Vector3 wanderPointLoc;
    private Vector3 newLocation;

    public float theta;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        theta = Mathf.PI/2;
        
    }

    // Update is called once per frame
    void Update()
    {
        wanderPointLoc = wanderPoint.position;
        x = wanderRadius * Mathf.Cos(theta);
        y = wanderRadius * Mathf.Sin(theta);
        Vector3 addVector = new Vector3 (x, y, 0);
        newLocation = wanderPointLoc + addVector;

        // x = Random.Range(-0.1f, 0.1f);
        // y = Random.Range(-0.1f, 0.1f);
        // addVector = new Vector3 (x, y, 0);
        this.transform.position = newLocation; 
    }
}
