using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float horsePower = 0f;
    [SerializeField] float rpm;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    //public bool player2;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //if(player2)
        //{
        //    horizontalInput = Input.GetAxis("Horizontal1");
        //    verticalInput = Input.GetAxis("Vertical1");
        //}

        if (isOnGround())
        {
            //Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput); //forward by 1 in z axis
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);//add force in local
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);// move the car to right or left based on speed

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);//for mph 3.6 to 2.237
            speedometerText.SetText("Speed: " + speed + " kph");

            //calculate rpm
            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
