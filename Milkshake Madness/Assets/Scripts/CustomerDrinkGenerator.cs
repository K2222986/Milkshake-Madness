using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerDrinkGenerator : MonoBehaviour
{
    public GameObject[] MilkShake; // this is where the diffrent sprites are stored for the milkshakes
    public GameObject MilkShakeStation;
    private int random;

    // parent object stuff
    private GameObject ParentObject;
    private GameObject newMilkShake;

    // identifying milkshake
    private changeMilkshake ChosenMilkshake;
    private MilkShakeID MilkShakeID;

    public BankAccountScript BankAcccount;
    public FloatingMoneyScript FloatingMoney;

    // TO DO: 
    // it should compare the values if its the same the custmer is happy if not they are unhappy
    // this all should loop 

    // milk shake flavour numbers 1: blueBerry, 2: watermelon, 3: peach, 4: bannana

    void Start()
    {
       ParentObject = GameObject.FindGameObjectWithTag("Customer"); // sets the parent object to the customer.
       GenMilkshake(); 
    }
   

    public void CheckMilkShake() // checks if the milkshake matches the customers milkshake
    {
        MilkShakeID = newMilkShake.GetComponent<MilkShakeID>(); // customer milkshake
        ChosenMilkshake = MilkShakeStation.GetComponent<changeMilkshake>(); // milk shake you choose

        if ( MilkShakeID.MilkShakeNum == ChosenMilkshake.GetMilkShakeID())
        {
            Debug.Log("You got it right!");

            GenMilkshake();
            BankAcccount.UpdateAccount(4); // This adds 4 to the bank account check BankAccountScript
            FloatingMoney.AmountGained(4);
        }
        else
        {
            Debug.Log("You got it wrong!");
            // show some sort of sad emote from the customer and then regenerate the drink
        }

        
    }
    void GenMilkshake() // chooses a random milk shake in the list and spawns it 
    {
        Destroy(newMilkShake);
        random = Random.Range(1, MilkShake.Length); // sets it to a random milkshake
        newMilkShake = Instantiate(MilkShake[random], transform.position, transform.rotation); // creates the milkshake
        newMilkShake.transform.SetParent(ParentObject.transform); // sets the object as child of the customer (this is so it disapears when the customer does) 
    }

   
}
