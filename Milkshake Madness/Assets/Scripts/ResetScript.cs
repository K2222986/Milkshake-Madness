using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public void ResetData()
    {
        PlayerPrefs.SetInt("Level", 1);
    }
}
