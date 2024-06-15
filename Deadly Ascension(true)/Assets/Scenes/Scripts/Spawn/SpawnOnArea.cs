using Mirror;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    [SerializeField]
    private GameObject zomb1;

    [SerializeField]
    private GameObject zomb2;
    
    [SerializeField]
    private GameObject zomb3;
    
    [SerializeField]
    private GameObject zomb4;
    
    [SerializeField]
    private GameObject zomb5;

    [SerializeField]
    private Vector3 ZoneSize;



    void Start()
    {
        
        int randomIndex = Random.Range(3, 8);

        for (int i = 0; i <= randomIndex; i++)
        {
            int zomb = Random.Range(1, 6);
            if (zomb == 1)
            {
                GameObject instantiated = Instantiate(zomb1);
                instantiated.transform.position = new Vector3(
                    Random.Range(transform.position.x - ZoneSize.x / 2, transform.position.x + ZoneSize.x / 2),
                    Random.Range(transform.position.y - ZoneSize.y / 2, transform.position.y + ZoneSize.y / 2),
                    Random.Range(transform.position.z - ZoneSize.z / 2, transform.position.z + ZoneSize.z / 2)
                );
            }

            if (zomb == 2)
            {
                GameObject instantiated = Instantiate(zomb2);
                instantiated.transform.position = new Vector3(
                    Random.Range(transform.position.x - ZoneSize.x / 2, transform.position.x + ZoneSize.x / 2),
                    Random.Range(transform.position.y - ZoneSize.y / 2, transform.position.y + ZoneSize.y / 2),
                    Random.Range(transform.position.z - ZoneSize.z / 2, transform.position.z + ZoneSize.z / 2)
                );
            }

            if (zomb == 3)
            {
                GameObject instantiated = Instantiate(zomb3);
                instantiated.transform.position = new Vector3(
                    Random.Range(transform.position.x - ZoneSize.x / 2, transform.position.x + ZoneSize.x / 2),
                    Random.Range(transform.position.y - ZoneSize.y / 2, transform.position.y + ZoneSize.y / 2),
                    Random.Range(transform.position.z - ZoneSize.z / 2, transform.position.z + ZoneSize.z / 2)
                );
            }
            
            if (zomb == 4)
            {
                GameObject instantiated = Instantiate(zomb4);
                instantiated.transform.position = new Vector3(
                    Random.Range(transform.position.x - ZoneSize.x / 2, transform.position.x + ZoneSize.x / 2),
                    Random.Range(transform.position.y - ZoneSize.y / 2, transform.position.y + ZoneSize.y / 2),
                    Random.Range(transform.position.z - ZoneSize.z / 2, transform.position.z + ZoneSize.z / 2)
                );
            }
            
            if (zomb == 5)
            {
                GameObject instantiated = Instantiate(zomb5);
                instantiated.transform.position = new Vector3(
                    Random.Range(transform.position.x - ZoneSize.x / 2, transform.position.x + ZoneSize.x / 2),
                    Random.Range(transform.position.y - ZoneSize.y / 2, transform.position.y + ZoneSize.y / 2),
                    Random.Range(transform.position.z - ZoneSize.z / 2, transform.position.z + ZoneSize.z / 2)
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
