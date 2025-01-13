using UnityEngine;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    public TextMeshProUGUI Text;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Mixing")) // changed from MaxLevel
        {
            if (PlayerPrefs.GetInt("Mixing") == 1)
            {
                Text.text = "Mixing Enabled";
            }
            else
            {
                Text.text = "Mixing Disabled";
            }
        }
    }
    public void ToggleMixing()
    {
        if (PlayerPrefs.HasKey("Mixing")) // changed from MaxLevel
        {
            if (PlayerPrefs.GetInt("Mixing") == 1)
            {
                PlayerPrefs.SetInt("Mixing", 0);
                Text.text = "Mixing Disabled";
            }
            else
            {
                PlayerPrefs.SetInt("Mixing", 1);
                Text.text = "Mixing Enabled";
            }
        }
        else
        {
            PlayerPrefs.SetInt("Mixing", 0);
            Text.text = "Mixing Disabled";
        }
    }
}
