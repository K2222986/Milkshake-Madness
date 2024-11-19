using System.Runtime.CompilerServices;
using UnityEngine;

public class CustomerDrinkGenerator : MonoBehaviour
{
    public GameObject[] MilkShake; // this is where the diffrent sprites are stored for the milkshakes

    private int random;

    // parent object stuff
    private GameObject ParentObject;
    private GameObject newObject;
    private bool Ininitialstart;
    private bool inKitchen;

    // TO DO: 
        // the player should pick a milk shake in the other view and it will have its own value 
        // it should compare the values if its the same the custmer is happy if not they are unhappy
        // this all should loop 

    // milk shake flavour numbers 0: blueBerry, 1: watermelon, 2: peach, 3: bannana
    
    void Start()
    {
       Ininitialstart = true;
       inKitchen = false;
       ParentObject = GameObject.FindGameObjectWithTag("Customer"); // sets the parent object to the customer.
       GenMilkshake(); 
    }
    private void Update()
    {
        if (Ininitialstart == false) // if initial start then it should not check if you had the correct milkshake
        {
            // you have gone to the kitchen in orer to get here 
            Debug.Log("You have entered the kichen for the first time");
            if (!inKitchen) // if you are in the kitchen it should not check if you have the correct milkshake
            {
                // you have come back from the kitchen to get here
                Debug.Log("You have come back from the kitchen");
            }

        }
        else if (ParentObject.transform.parent.gameObject.activeSelf == false)
        {
            Ininitialstart = false;
            Debug.Log("InitialStart is now false");
          
        }
        // once the player has seen the milkshake that was asked they should go to the kitchen 
        
        // once in the milk shake they should select a milk shake and go back to the main room where the customer is 
        // then it should check if the milkshake is correct
    }

    void GenMilkshake() // chooses a random milk shake in the list and spawns it 
    {
        random = Random.Range(0, MilkShake.Length); // sets it to a random milkshake
        newObject = Instantiate(MilkShake[random], transform.position, transform.rotation); // creates the milkshake
        newObject.transform.SetParent(ParentObject.transform); // sets the object as child of the customer (this is so it disapears when the customer does) 
    }
}
