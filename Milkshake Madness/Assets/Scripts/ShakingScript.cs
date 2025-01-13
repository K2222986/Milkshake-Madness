using Unity.Mathematics;
using UnityEngine;

public class ShakingScript : MonoBehaviour
{
    public GameControllerScript gameControllerScript;
    public GameObject Milkshake;
    public VolumeManager volumeManager;


    public float ShakeDetectionThreshold;
    public float MinShakeInterval; // how often to check for a shake
    public float MixingDisplayed;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    private int numberOfShakes; // 3 shakes is fully shaken

    private int MixingEnabled;
    public GameObject MixText;
    public GameObject MixButton;


    void Start()
    {
        
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
    }
    public void DisplayMixer()
    {
        if (PlayerPrefs.HasKey("Mixing")) // changed from MaxLevel
        {
            MixingEnabled = PlayerPrefs.GetInt("Mixing");// changed from MaxLevel
        }
        else
        {
            PlayerPrefs.SetInt("Mixing", 1);
            MixingEnabled = 1;
        }
        if (MixingEnabled == 1)
        {
            MixText.SetActive(true);
            MixButton.SetActive(false);
        }
        else
        {
            MixButton.SetActive(true);
            MixText.SetActive(false);
        }
    }
    
    void Update()
    {

        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval) // add another condition here for when it is loaded 
        {
            // The player has shaked 
            timeSinceLastShake = Time.unscaledTime;
            
            numberOfShakes++;
            Debug.Log("You Have Shaken!" + numberOfShakes);

            if (numberOfShakes >= 3)
            {
                // register that the player has mixed milkshake
                Milkshake.SetActive(true);
                numberOfShakes = 0;
                volumeManager.PlaySFX("Milkshake finished");
            }
        }
    }
    

}
