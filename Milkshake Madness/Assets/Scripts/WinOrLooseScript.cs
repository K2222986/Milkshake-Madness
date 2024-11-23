using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLooseScript : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProUGUI;
    void Start()
    {
        TextMeshProUGUI.text = "";
    }

    public void GameWonText() { TextMeshProUGUI.text = "YOU HAVE WON!"; }
    public void GameLostText() { TextMeshProUGUI.text = "YOU HAVE LOST!"; }

}
