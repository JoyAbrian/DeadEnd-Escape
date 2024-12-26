using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI silverKeyCountText;
    [SerializeField] private TextMeshProUGUI goldKeyCountText;

    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI moneyCountText;

    // Update is called once per frame
    void Update()
    {
        silverKeyCountText.text = GlobalVariables.silverKeyCount.ToString();
        goldKeyCountText.text = GlobalVariables.goldKeyCount.ToString();

        playerNameText.text = GlobalVariables.playerName;
        moneyCountText.text = GlobalVariables.moneyCount.ToString();
    }
}
