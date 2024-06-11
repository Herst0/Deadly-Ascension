using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{

    private float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 _input;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * verticalInput));
        transform.Translate(Vector3.right * (Time.deltaTime * speed * horizontalInput));
    }
}
