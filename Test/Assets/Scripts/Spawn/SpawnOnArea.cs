
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField]
    private GameObject Room;

    [SerializeField]
    private Vector3 ZoneSize;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instantiated = Instantiate(Room);

            instantiated.transform.position = new Vector3(
                Random.Range(transform.position.x - ZoneSize.x/2, transform.position.x + ZoneSize.x/2),
                Random.Range(transform.position.y - ZoneSize.y/2, transform.position.y + ZoneSize.y/2),
                Random.Range(transform.position.z - ZoneSize.z/2, transform.position.z + ZoneSize.z/2)
                

            ); 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, ZoneSize);
    }
}
