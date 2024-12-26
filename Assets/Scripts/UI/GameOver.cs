using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameOverMenu;

    public Text title;
    public Text coinValue;

    [Header("Game Failed")]
    public Image bloodyScreen;
    public GameObject failedStars;
    public GameObject rewind;

    [Header("Game Success")]
    public GameObject successStars;
    public GameObject nextGame;

    public float transitionDuration = 1f;
    private Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 hiddenScale = Vector3.zero;

    void Start()
    {
        gameOverPanel.SetActive(false);
        bloodyScreen.gameObject.SetActive(false);
        gameOverMenu.transform.localScale = hiddenScale;
    }

    public void GameOverScene(bool isFailed)
    {
        SetupGameOverUI(isFailed);
        StartZoomIn();
    }

    private void SetupGameOverUI(bool isFailed)
    {
        gameOverPanel.SetActive(true);
        bloodyScreen.gameObject.SetActive(isFailed);

        if (isFailed)
        {
            title.text = "You Died!";
            coinValue.text = "+0";

            failedStars.SetActive(true);
            successStars.SetActive(false);

            rewind.SetActive(true);
            nextGame.SetActive(false);
        }
        else
        {
            title.text = "You Escaped!";
            coinValue.text = "+10";

            failedStars.SetActive(false);
            successStars.SetActive(true);

            rewind.SetActive(false);
            nextGame.SetActive(true);
        }
    }

    private void StartZoomIn()
    {
        gameOverMenu.transform.localScale = hiddenScale;
        StartCoroutine(ZoomInCoroutine());
    }

    private System.Collections.IEnumerator ZoomInCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;
            gameOverMenu.transform.localScale = Vector3.Lerp(hiddenScale, targetScale, t);
            yield return null;
        }

        gameOverMenu.transform.localScale = targetScale;
    }
}