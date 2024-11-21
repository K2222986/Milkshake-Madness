using System.Runtime.CompilerServices;
using UnityEngine;

public class CustomerDrinkGenerator : MonoBehaviour
{
    public GameObject[] MilkShake; // this is where the diffrent sprites are stored for the milkshakes
    public GameObject MilkShakeStation;
    private int random;

    // parent object stuff
    private GameObject ParentObject;
    private MilkShakeID MilkShakeID;
    private GameObject newObject;

    private changeMilkshake ChosenMilkshake;
    // TO DO: 
        // it should compare the values if its the same the custmer is happy if not they are unhappy
        // this all should loop 

    // milk shake flavour numbers 0: blueBerry, 1: watermelon, 2: peach, 3: bannana
    
    void Start()
    {
       ParentObject = GameObject.FindGameObjectWithTag("Customer"); // sets the parent object to the customer.
       GenMilkshake(); 
    }
    private void Update()
    {
        
         
        
    }

    public void CheckMilkShake() // checks if the milkshake matches the customers milkshake
    {
        MilkShakeID = newObject.GetComponent<MilkShakeID>(); // customer milkshake
        ChosenMilkshake = MilkShakeStation.GetComponent<changeMilkshake>(); // milk shake you choose

        if ( MilkShakeID.MilkShakeNum == ChosenMilkshake.GetMilkShakeID())
        {
            Debug.Log("You got it right!");

            GenMilkshake();

        }
        else
        {
            Debug.Log("You got it wrong!");
        }

        
    }
    void GenMilkshake() // chooses a random milk shake in the list and spawns it 
    {
        Destroy(newObject);
        random = Random.Range(0, MilkShake.Length); // sets it to a random milkshake
        newObject = Instantiate(MilkShake[random], transform.position, transform.rotation); // creates the milkshake
        newObject.transform.SetParent(ParentObject.transform); // sets the object as child of the customer (this is so it disapears when the customer does) 
    }
}
