using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moove : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = 20f;

    private Vector3 moveD = Vector3.zero;

    CharacterController Cac;

    [SerializeField]
    private float forceMagnitude;
    
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


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var rigidBody = hit.collider.attachedRigidbody;

        if (rigidBody != null)
        {
            var forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            
            rigidBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);

            
        }
    }
}