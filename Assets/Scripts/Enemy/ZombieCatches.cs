using UnityEngine;

public class ZombieCatches : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float catchDistance = 1.5f;

    [SerializeField] private GameObject UIManager;

    void Update()
    {
        if (!GlobalVariables.isGameSuccess && !GlobalVariables.isGameFailed && Vector3.Distance(transform.position, player.position) < catchDistance)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        GlobalVariables.isGameFailed = true;
        UIManager.GetComponent<GameOver>().GameOverScene(true);

        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
