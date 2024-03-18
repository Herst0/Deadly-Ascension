using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class ThirdPersonShooter : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
        [SerializeField] private GameObject crosshair;
        [SerializeField] private GameObject sphere;
        [SerializeField] private float normalSensitivity;
        [SerializeField] private float aimSensitivity;
        [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
        [SerializeField] private Transform debugTransform;
        [SerializeField] private Transform pfBulletProjectile;
        [SerializeField] private Transform spawnBulletPosition;

        private StarterAssetsInputs starterAssetsInputs;
        private ThirdPersonController thirdPersonController;
        private Animator animator;

        private void Awake()
        {
            thirdPersonController = GetComponent<ThirdPersonController>();
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            animator = GetComponent<Animator>();

            // Assurez-vous que le crosshair et la sphère sont désactivés au démarrage
            crosshair.SetActive(false);
            sphere.SetActive(false);
        }

        private void Update()
        {
            Vector3 mouseWorldPosition = Vector3.zero;
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                debugTransform.position = raycastHit.point;
                mouseWorldPosition = raycastHit.point;
            }

            if (starterAssetsInputs.aim)
            {
                aimVirtualCamera.gameObject.SetActive(true);
                thirdPersonController.SetSensitivity(aimSensitivity);
                thirdPersonController.SetRotateOnMove(false);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

                // Activer le crosshair et la sphère lorsque le joueur vise
                crosshair.SetActive(true);
                sphere.SetActive(true);

                Vector3 worldAimTarget = mouseWorldPosition;
                worldAimTarget.y = transform.position.y;
                Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

                transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            }
            else
            {
                aimVirtualCamera.gameObject.SetActive(false);
                thirdPersonController.SetSensitivity(normalSensitivity);
                thirdPersonController.SetRotateOnMove(true);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));

                // Désactiver le crosshair et la sphère lorsque le joueur ne vise pas
                crosshair.SetActive(false);
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
