using UnityEngine;
using Mirror;

namespace Player
{
	public class BasicRigidBodyPush : NetworkBehaviour
	{
		[Header("Push Settings")]
		[SerializeField] private LayerMask pushLayersMask;
		[SerializeField] private bool canPush = true;
		[SerializeField, Range(0.5f, 5f)] private float strength = 1.1f;

		private const float minVerticalThreshold = -0.3f;

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			if (canPush)
			{
				PushRigidBodies(hit);
			}
		}

		private void PushRigidBodies(ControllerColliderHit hit)
		{
			if (hit.collider == null || hit.collider.attachedRigidbody == null || hit.collider.attachedRigidbody.isKinematic)
			{
				return;
			}

			var body = hit.collider.attachedRigidbody;

			var bodyLayerMask = 1 << body.gameObject.layer;
			if ((bodyLayerMask & pushLayersMask.value) == 0 || hit.moveDirection.y < minVerticalThreshold)
			{
				return;
			}

			var pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

			// Use ForceMode.VelocityChange instead of ForceMode.Impulse
			body.AddForce(pushDir * strength, ForceMode.VelocityChange);
		}
    
	}
}