using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI levelText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelText.text = level.ToString();
    }

    public void LoadLevel()
    {
        GameControllerScript.Instance.SetLevel(level);
    }
}
