using Cinemachine;
using StarterAssets;
using UnityEngine;

namespace Player
{
 public class ThirdPersonShotter : MonoBehaviour
 {
  [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
  [SerializeField] private float normalSensitivity;
  [SerializeField] private float aimSensitivity;
  
  private StarterAssetsInputs starterAssetsInputs;
  private ThirdPersonController thirdPersonController;
  private void Awake()
  {
   thirdPersonController = GetComponent<ThirdPersonController>();
   starterAssetsInputs = GetComponent<StarterAssetsInputs>();
  }

  private void Update()
  {
   if (starterAssetsInputs.aim)
   {
    aimVirtualCamera.gameObject.SetActive(true);
    thirdPersonController.SetSensitivity(aimSensitivity);
   }
   else
   {
    aimVirtualCamera.gameObject.SetActive(false);
    thirdPersonController.SetSensitivity(normalSensitivity);
   }
  }
 }
}
