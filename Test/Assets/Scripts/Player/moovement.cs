using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moove : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = 20f;

    private Vector3 moveD = Vector3.zero;

    CharacterController Cac;
    
    // Start is called before the first frame update
    void Start()
    {
        Cac = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cac.isGrounded)
        {
            moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;
            
        }

        moveD.y -= gravity * Time.deltaTime;

        Cac.Move(moveD * Time.deltaTime);
    }
}
