using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI levelText;

    //public Sprite Empty = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelText.text = level.ToString();
        if (level > PlayerPrefs.GetInt("Level"))
        {
            this.gameObject.SetActive(false);
        }
        
    }

    public void LoadLevel()
    {
        GameControllerScript.Instance.SetLevel(level);
    }
}
