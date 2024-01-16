using UnityEngine;

public class SpawnOnPosition : MonoBehaviour
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
                    Instantiate(Room, spawnPoints[i].position, Quaternion.identity);
                }
    }
}
