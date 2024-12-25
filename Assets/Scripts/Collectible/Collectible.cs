using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        SilverKey,
        GoldKey,
        SilverCoin,
        GoldCoin
    }

    [SerializeField] private CollectibleType type;
    [SerializeField] private float rotationSpeed = 50f;

    void Update()
    {
        RotateCollectible();
    }

    private void RotateCollectible()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateGlobalVariables();
            Destroy(gameObject);
        }
    }

    private void UpdateGlobalVariables()
    {
        switch (type)
        {
            case CollectibleType.SilverKey:
                GlobalVariables.silverKeyCount++;
                break;
            case CollectibleType.GoldKey:
                GlobalVariables.goldKeyCount++;
                break;
            case CollectibleType.SilverCoin:
                GlobalVariables.moneyCount += 100;
                break;
            case CollectibleType.GoldCoin:
                GlobalVariables.moneyCount += 300;
                break;
        }
    }
}