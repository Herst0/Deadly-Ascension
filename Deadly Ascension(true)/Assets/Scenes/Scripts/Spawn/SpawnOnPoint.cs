using UnityEngine;
using Mirror;

public class SpawnOnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject Room1;

    [SerializeField]
    private GameObject Room2;

    [SerializeField]
    private GameObject Room3;
    
    [SerializeField]
    private GameObject Room4;

    [SerializeField]
    private GameObject Room5;
    
    [SerializeField]
    private GameObject Room6;

    [SerializeField]
    private Transform[] spawnPoints;

    void Start()
    {
        // Je ne sais pas si cela ne les fait pas spawn deux fois au même endroit ?
        SpawnRandomRoom();
    }

    void Update()
    {
        // Permet de faire spawn la pièce en appuyant sur "espace"
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomRoom();
        }
        */
    }

    void SpawnRandomRoom()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Quaternion rotation = Quaternion.identity; // Initialiser la rotation à l'identité
            // Choisir aléatoirement entre Room1, Room2, Room3, Room4, et Room5
            int randomIndex = Random.Range(0, 6);
            GameObject selectedRoom = (randomIndex == 0) ? Room1 :
                (randomIndex == 1) ? Room2 :
                (randomIndex == 2) ? Room3 :
                (randomIndex == 3) ? Room4 :
                (randomIndex == 4) ? Room5 : Room6;

            // Appliquer la rotation de 90 degrés autour de l'axe Y pour les indices 0 et 2
            if (i == 0 || i == 2)
            {
                rotation = Quaternion.Euler(0, 90, 0);
            }
            
            // Appliquer la rotation de -90 degrés autour de l'axe Y pour les indices 1 et 3
            if (i == 1 || i == 3)
            {
                rotation = Quaternion.Euler(0, -90, 0);
            }

            // Instancier la room sélectionnée avec la rotation appliquée
            Instantiate(selectedRoom, spawnPoints[i].position, rotation);
        }
    }
}