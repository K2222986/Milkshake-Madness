using System.Runtime.CompilerServices;
using UnityEngine;

public class CustomerDrinkGenerator : MonoBehaviour
{
    public GameObject[] MilkShake; // this is where the diffrent sprites are stored for the milkshakes

    private int random;
        // choose a random milkshake to ask for 
        // sets a value to it 
        // it should display the milk shake they want for the player to see 
        // the player should then pick a milk shake in the other view and it will have its own value 
        // it should compare the values if its the same the custmer is happy if not they are unhappy
        // this all should loop 

    // milk shake flavour numbers 0: blueBerry, 1: watermelon, 2: peach, 3: bannana
    
    void Start()
    {
       GenMilkshake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void GenMilkshake()
    {
        random = Random.Range(0, MilkShake.Length); // sets it to a random milkshake
        Instantiate(MilkShake[random], transform.position, transform.rotation); // creates the milkshake
    }
}
