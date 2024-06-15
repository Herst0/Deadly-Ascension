using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class ThirdPersonShooter : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
        [SerializeField] private GameObject sphere;
        [SerializeField] private float normalSensitivity;
        [SerializeField] private float aimSensitivity;
        [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
        [SerializeField] private Transform debugTransform;
        [SerializeField] private Transform pfBulletProjectile;
        [SerializeField] private Transform spawnBulletPosition;
        private Vector3 spherePosition;

        private StarterAssetsInputs starterAssetsInputs;
        private ThirdPersonController thirdPersonController;
        private Animator animator;

        private void Awake()
        {
            thirdPersonController = GetComponent<ThirdPersonController>();
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            animator = GetComponent<Animator>();

            // Assurez-vous que  la sphère est désactivé au démarrage
           
            sphere.SetActive(false);
        }

        private void Update()
        {
            Vector3 mouseWorldPosition = Vector3.zero;
// Décaler le centre de l'écran vers le bas et la gauche
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f - 20f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                debugTransform.position = raycastHit.point;
                mouseWorldPosition = raycastHit.point;
            }
            spherePosition = raycastHit.point;

            if (starterAssetsInputs.aim)
            {
                aimVirtualCamera.gameObject.SetActive(true);
                thirdPersonController.SetSensitivity(aimSensitivity);
                thirdPersonController.SetRotateOnMove(false);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

                // Activer la sphère lorsque le joueur vise
                sphere.SetActive(true);

                Vector3 worldAimTarget = mouseWorldPosition;
                worldAimTarget.y = transform.position.y;
                Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

                transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
                     if (starterAssetsInputs.shoot)
                        {
                            // Tirer à partir de la position de la sphère rouge
                            Vector3 aimDir = (spherePosition - spawnBulletPosition.position).normalized;
                            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                            starterAssetsInputs.shoot = false;
                        }
            }
            else
            {
                aimVirtualCamera.gameObject.SetActive(false);
                thirdPersonController.SetSensitivity(normalSensitivity);
                thirdPersonController.SetRotateOnMove(true);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));

                // Désactiver la sphère lorsque le joueur ne vise pas
              
                sphere.SetActive(false);
            }

            if (starterAssetsInputs.shoot)
            {
                // Use player's forward direction instead of aim direction
                Vector3 forwardDirection = transform.forward;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(forwardDirection, Vector3.up));
                starterAssetsInputs.shoot = false;
            }

        
        }
    }
}
