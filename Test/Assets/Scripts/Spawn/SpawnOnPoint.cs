using UnityEngine;

public class SpawnOnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject Room;

    [SerializeField]
    private Transform[] spawnPoints;

    void Start()
    {
        // Je ne sais pas ci cela ne les fait pas spawn deux fois au même endroit ?

        SpawnRandomRoom();
     
    }

    void Update()
    {
        // Permet de faire spawn la pièce en appuyant sur "espace"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomRoom();
        }
    }

    void SpawnRandomRoom()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Quaternion rotation = Quaternion.identity; // Initialiser la rotation à l'identité
            
            // Appliquer la rotation de -90 degrés autour de l'axe Y pour les indices 2 et 4
            if (i == 0 || i == 2)
            {
                rotation = Quaternion.Euler(0, 90, 0);
            }
            
            // Appliquer la rotation de 90 degrés autour de l'axe Y pour les indices 2 et 4
            if (i == 1 || i == 3)
            {
                rotation = Quaternion.Euler(0,-90, 0);
            }

            // Instancier la room avec la rotation appliquée
            Instantiate(Room, spawnPoints[i].position, rotation);
        }
    }
}




/*
using UnityEngine;

public class SpawnOnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject Room;

    [SerializeField]
    private Transform[] spawnPoints;

    void Start()
    {
        //je ne sais pas ci cela ne les fait pas spawn deux fois au même endoit ?
        for(int i = 0; i<=spawnPoints.Length;i++)
        {
            SpawnRandomRoom();
        }
    }

    void Update()
    {
        //permet de faire spawn la pièce en appuyant sur "espace"

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomRoom();
        }
        
    }

    void SpawnRandomRoom()
    {
        for (int i = 0; i <  spawnPoints.Length; i++)
                {
                    Instantiate(Room, spawnPoints[i].position, Quaternion.identity);
                }
    }
}
*/