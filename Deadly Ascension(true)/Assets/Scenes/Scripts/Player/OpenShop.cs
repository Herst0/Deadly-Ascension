using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private ManagerUi managerUi;

    [SerializeField] private GameObject medikitPrefab; // Référence au prefab du medikit
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject strongPrefab; // Référence au prefab du medikit
    [SerializeField] private Transform spawnPoint2; // Point de spawn pour le medikit

    void Start()
    {
        managerUi = FindObjectOfType<ManagerUi>();
        if (managerUi == null)
        {
            Debug.LogError("ManagerUi script not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered the shop area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player exited the shop area.");
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Player pressed T in the shop area.");
            if (managerUi.Buymedikit())
            {
                SpawnMedikit();
            }
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Y))
        {
            if (managerUi.BuyStrong())
            {
                SpawnStrong();
            }
        }
    }

    void SpawnStrong()
    {
        if (strongPrefab != null && spawnPoint2 != null)
        {
            Instantiate(strongPrefab, spawnPoint2.position, spawnPoint2.rotation);
            Debug.Log("strong spawned at " + spawnPoint2.position);
        }
        else
        {
            Debug.LogError("Medikit prefab or spawn point not assigned!");
        }
    }

    void SpawnMedikit()
    {
        if (medikitPrefab != null && spawnPoint != null)
        {
            Instantiate(medikitPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Medikit spawned at " + spawnPoint.position);
        }
        else
        {
            Debug.LogError("Medikit prefab or spawn point not assigned!");
        }
    }
}