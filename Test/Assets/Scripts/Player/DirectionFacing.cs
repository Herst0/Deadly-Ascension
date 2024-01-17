using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWithMouse : MonoBehaviour
{
    // Vitesse de rotation du personnage
    public float rotationSpeed = 0f;

    void Update()
    {
        // Appeler la fonction pour faire tourner le personnage en fonction de la souris
        RotateWithMouse();
    }

    void RotateWithMouse()
    {
        // Obtenir la position de la souris par rapport à l'écran
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y - transform.position.y;

        // Convertir la position de la souris en une direction dans le monde
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculer la direction de la souris par rapport au personnage
        Vector3 lookDirection = worldMousePosition - transform.position;
        lookDirection.y = 0f; // Garantir que la rotation n'a lieu que dans le plan horizontal

        // Faire tourner le personnage pour regarder vers la direction de la souris
        if (lookDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}