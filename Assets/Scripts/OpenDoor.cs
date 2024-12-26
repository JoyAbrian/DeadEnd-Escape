using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject doorClose, doorOpen;

    private BoxCollider openAreaCollider;

    void Start()
    {
        doorOpen.SetActive(false);
        doorClose.SetActive(true);

        openAreaCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GlobalVariables.silverKeyCount > 0)
            {
                openAreaCollider.enabled = false;

                doorOpen.SetActive(true);
                doorClose.SetActive(false);
            }
        }
    }
}