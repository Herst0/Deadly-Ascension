using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moove : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = 20f;
    private Vector3 moveD = Vector3.zero;
    
    private Animator _animator;
    
    
    private bool _walking;
    private bool _dodging; 
    private float dodgeEndTime;
    public float dodgeDuration = 0.1f; 
    private Vector3 _smoothDampVelocity; 
    

    CharacterController Cac;

    [SerializeField]
    private float forceMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        Cac = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleDodgeInput();

        // Set the "Walking" parameter based on the magnitude of movement (PS : C'est normal que tu ne comprennes pas, je t'expliquerai un jour, mais là, j'ai la flemme, j'écris ça à 00h23)[Théo]
        _animator.SetBool("Walking", _walking);

        // Set the "Dodge" trigger based on the dodge state
        _animator.SetBool("Dodge", _dodging);
    }

    void HandleMovementInput()
    {
        if (Cac.isGrounded)
        {
            moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;

            // Check if movement keys are pressed
            _walking = (Mathf.Abs(moveD.x) > 0.1f || Mathf.Abs(moveD.z) > 0.1f);
        }

        moveD.y -= gravity * Time.deltaTime;
        Cac.Move(moveD * Time.deltaTime);
    }

    void HandleDodgeInput()
    {
        if (_dodging)
        {
            // Calculate the target position for backward movement
            Vector3 targetPosition = transform.position - transform.forward * 2f; // Adjust the distance as needed

            // Use SmoothDamp to interpolate between the current position and target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _smoothDampVelocity, 0.15f);

            // If enough time has passed, end the dodge
            if (Time.time > dodgeEndTime)
            {
                _dodging = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _dodging = true;
            dodgeEndTime = Time.time + dodgeDuration; // Set the end time of the dodge
        }
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