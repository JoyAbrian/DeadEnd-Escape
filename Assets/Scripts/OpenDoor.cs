using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private BoxCollider doorCollider, openAreaCollider;

    void Start()
    {
        doorCollider = door.GetComponent<BoxCollider>();
        openAreaCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GlobalVariables.silverKeyCount > 0)
            {
                doorCollider.enabled = false;
                openAreaCollider.enabled = false;

                door.transform.position = new Vector3(-0.633f, 0f, -0.733f);
                door.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
        }
    }
}