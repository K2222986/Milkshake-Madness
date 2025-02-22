using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CustomerDrinkGenerator : MonoBehaviour
{
    public GameObject[] MilkShake; // this is where the diffrent sprites are stored for the milkshakes
    public List<GameObject> Topping;
    public GameObject MilkShakeStation;
    private int random;
    private bool NoTopping = false; // this needs to be a variable thats turned on or off in the Main Menu
    // parent object stuff
    private GameObject ParentObject;
    private GameObject newMilkShake;
    private GameObject newTopping;

    // identifying milkshake
    private changeMilkshake ChosenMilkshake;
    private ChangeTopping ChosenTopping;
    private MilkShakeID MilkShakeID;
    private ToppingID ToppingsID;

    public BankAccountScript BankAcccount;
    public FloatingMoneyScript FloatingMoney;

    public GameObject MilkshakeActivething;
    public GameControllerScript GameController;

    public RetrieveDataScript LoadScript;
    private List<bool> BoughtToppings;
    

    // TO DO: 
    // it should compare the values if its the same the custmer is happy if not they are unhappy
    // this all should loop 

    // milk shake flavour numbers 1: blueBerry, 2: watermelon, 3: peach, 4: bannana

    void Start()
    {
        ParentObject = GameObject.FindGameObjectWithTag("Customer"); // sets the parent object to the customer.
    }
   

    public void CheckMilkShake() // checks if the milkshake matches the customers milkshake
    {
        MilkShakeID = newMilkShake.GetComponent<MilkShakeID>(); // customer milkshake
        ToppingsID = newTopping.GetComponent<ToppingID>(); // customer topping
        ChosenMilkshake = MilkShakeStation.GetComponent<changeMilkshake>(); // milk shake you choose
        ChosenTopping = MilkShakeStation.GetComponent<ChangeTopping>(); // milk shake you choose

        if ((MilkShakeID.MilkShakeNum == ChosenMilkshake.GetMilkShakeID()) && (ToppingsID.ToppingNum == ChosenTopping.GetToppingsID()) && MilkshakeActivething.activeSelf )
        {
            Debug.Log("You got it right!");

            GenMilkshake();
            BankAcccount.UpdateAccount(12); // This adds 4 to the bank account check BankAccountScript
            FloatingMoney.AmountGained(12);
            GameController.CheckWinCondition();
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
        Destroy(newTopping);
        random = Random.Range(1, MilkShake.Length); // sets it to a random milkshake
        newMilkShake = Instantiate(MilkShake[random], transform.position + new Vector3(-0.8f, 0.1f, -1), transform.rotation); // creates the milkshake
        newMilkShake.transform.SetParent(ParentObject.transform); // sets the object as child of the customer (this is so it disapears when the customer does)

        if (!NoTopping)
        {
            random = Random.Range(0, Topping.Count - 1); // sets it to a random topping
            newTopping = Instantiate(Topping[random], transform.position + new Vector3(0.8f, 0.1f, -1), transform.rotation); // creates the milkshake
            newTopping.transform.SetParent(ParentObject.transform); // sets the object as child of the customer (this is so it disapears when the customer does) 
        }
        else
        {
            newTopping = Instantiate(Topping[0], transform.position + new Vector3(0.8f, 0.1f, -1), transform.rotation); // creates the milkshake
        }

    }

    public void CheckStore()
    {
        BoughtToppings = LoadScript.CheckToppings();
        if (BoughtToppings != null)
        {
            if (BoughtToppings[0] == false)
            {
                for (int i = BoughtToppings.Count - 1; i > 0; i--)
                {
                    if (BoughtToppings[i] == false)
                    {
                        Topping.RemoveAt(i);
                
                    }
                }

            }
        }
        else
        {
            for (int i = Topping.Count -1; i > 0; i--)
                {
                    Topping.RemoveAt(i);
                }
        }
        
        GenMilkshake();
    }

}
