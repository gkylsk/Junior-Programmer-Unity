using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    private float cameraChange;
    private Vector3 changeOffset = new Vector3(0, 1.5f, -7.6f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraChange = Input.GetAxis("Jump");
        transform.position = player.transform.position + offset - changeOffset * cameraChange;
    }
}
