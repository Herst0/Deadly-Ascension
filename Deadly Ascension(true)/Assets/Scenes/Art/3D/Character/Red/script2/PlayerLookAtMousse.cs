using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    public Camera mainCamera;        // Référence à la caméra principale
    public float sensitivity = 1.0f; // Facteur de sensibilité de la rotation
    public float rotationThreshold = 0.2f; // Seuil de mouvement de la souris pour la rotation

    void Update()
    {
        // Obtenir la position de la souris en pixels
        Vector3 mouseScreenPosition = Input.mousePosition;
        
        // Convertir la position de la souris en coordonnées du monde
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        
        if (playerPlane.Raycast(ray, out float hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Vector3 direction = targetPoint - transform.position;
            direction.y = 0; // Garder la rotation sur le plan horizontal
            
            // Vérifier si le mouvement de la souris est supérieur au seuil
            if (direction.magnitude > rotationThreshold)
            {
                // Faire tourner le joueur pour qu'il fasse face à la direction de la souris
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                
                // Interpoler la rotation pour ajuster la sensibilité
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, sensitivity * Time.deltaTime);
            }
        }
    }
}