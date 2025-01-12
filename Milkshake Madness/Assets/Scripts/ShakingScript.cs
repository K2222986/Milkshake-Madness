using Unity.Mathematics;
using UnityEngine;

public class ShakingScript : MonoBehaviour
{
    public GameControllerScript gameControllerScript;
    public GameObject Milkshake;


    public float ShakeDetectionThreshold;
    public float MinShakeInterval; // how often to check for a shake
    public float MixingDisplayed;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    private int numberOfShakes; // 3 shakes is fully shaken


    void Start()
    {
        
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
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
            }
        }
    }
    

}
