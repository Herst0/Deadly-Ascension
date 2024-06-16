using UnityEngine;

 [RequireComponent(typeof(PlayerMotor))]
 public class PlayerController : MonoBehaviour
 {
     [SerializeField] private float speed = 3f;
     private PlayerMotor motor;
     
     [SerializeField]
     private float mouseSensitivityX = 6f;
     [SerializeField]
     private float mouseSensitivityY = 3f;

     private void Start()
     {
         motor = GetComponent<PlayerMotor>();

     }

     private void Update()
     {
         float xMov = Input.GetAxis("Horizontal");
         float zMov = Input.GetAxis("Vertical");

         Vector3 moveHorizontal = transform.right * xMov;
         Vector3 moveVertical = transform.forward * zMov;

         Vector3 velocity = (moveHorizontal + moveVertical) * speed;
         
         motor.Move(velocity);

         float yRot = Input.GetAxis("Mouse X");
         Vector3 rotation = new Vector3(0, yRot, 0)*mouseSensitivityX;
         motor.Rotate(rotation);
         float xRot = Input.GetAxis("Mouse Y");
         Vector3 cameraRotation = new Vector3(xRot, 0, 0)*mouseSensitivityY;
         motor.RotateCamera(cameraRotation);
     }
 }
