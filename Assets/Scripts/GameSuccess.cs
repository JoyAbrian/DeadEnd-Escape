using UnityEngine;

public class GameSuccess : MonoBehaviour
{
    public GameObject UIManager;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GlobalVariables.goldKeyCount > 0)
            {
                if (!GlobalVariables.isGameSuccess && !GlobalVariables.isGameFailed)
                {
                    GlobalVariables.goldKeyCount--; 
                    TriggerGameSuccess();
                }
            }
        }
    }

    void TriggerGameSuccess()
    {
        GlobalVariables.isGameSuccess = true;
        UIManager.GetComponent<GameOver>().GameOverScene(false);

        player.GetComponent<PlayerMovement>().enabled = false;
    }
}