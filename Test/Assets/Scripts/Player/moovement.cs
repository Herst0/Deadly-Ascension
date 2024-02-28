using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moove : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = 20f;
    private Vector3 moveD = Vector3.zero;
    
    private Animator animator;
    private bool isWalking = false;
    CharacterController Cac;

    [SerializeField]
    private float forceMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        Cac = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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
        
        
        if (Input.GetKey(KeyCode.Z))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        
        animator.SetBool("IsWalking", isWalking);
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
