using UnityEngine;

public class ZombieCatches : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float catchDistance = 1.5f;

    [SerializeField] private GameObject UIManager;
    private bool isGameOver = false;
    private bool isGameSuccess = false;

    void Update()
    {
        if (!isGameSuccess && !isGameOver && Vector3.Distance(transform.position, player.position) < catchDistance)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        UIManager.GetComponent<GameOver>().GameOverScene(true);

        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
