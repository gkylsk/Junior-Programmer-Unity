using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    public bool player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(player2)
        {
            horizontalInput = Input.GetAxis("Horizontal1");
            verticalInput = Input.GetAxis("Vertical1");
        }
        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput); //forward by 1 in z axis
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);// move the car to right or left based on speed
    }
}
