using Mirror;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    [SerializeField]
    private GameObject zomb1;

    [SerializeField]
    private GameObject zomb2;

    [SerializeField]
    private Vector3 ZoneSize;


    void Start()
    {
        int zomb = Random.Range(1,3);
        int randomIndex = Random.Range(0, 8);

        for (int i = 0; i<= randomIndex; i++)
        {
            if (zomb == 1)
            {
                GameObject instantiated = Instantiate(zomb1);
                 instantiated.transform.position = new Vector3(
                Random.Range(transform.position.x - ZoneSize.x/2, transform.position.x + ZoneSize.x/2),
                Random.Range(transform.position.y - ZoneSize.y/2, transform.position.y + ZoneSize.y/2),
                Random.Range(transform.position.z - ZoneSize.z/2, transform.position.z + ZoneSize.z/2)
            ); 
            }
            if (zomb == 2)
            {
                GameObject instantiated = Instantiate(zomb2);
                 instantiated.transform.position = new Vector3(
                Random.Range(transform.position.x - ZoneSize.x/2, transform.position.x + ZoneSize.x/2),
                Random.Range(transform.position.y - ZoneSize.y/2, transform.position.y + ZoneSize.y/2),
                Random.Range(transform.position.z - ZoneSize.z/2, transform.position.z + ZoneSize.z/2)
            );
            } 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, ZoneSize);
    }
}
