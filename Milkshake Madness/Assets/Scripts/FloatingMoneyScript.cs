using TMPro;
using UnityEngine;

public class FloatingMoneyScript : MonoBehaviour
{

    // should spawn a text object 
    // the text object should display the amount of money the player gained 
    // the text object should spawn next to the customer and then slowly fade (probaly with alpha) while moving upwards

    public TextMeshProUGUI PlayerBank; // the parent object this should be attached to 

    private TextMeshProUGUI newGameObject;

    public float lifetime = 3f; 

    void Start()
    {
       
    }

    public void AmountGained(float amount) {PlayerBank.text = "+" + amount; CreateFloatingMoney(); } // enter the amount and it will create the object as well

    private void CreateFloatingMoney() // creates the number and then calls the destroy function after 3 seconds
    {
        newGameObject = Instantiate(PlayerBank, transform.position, transform.rotation); // creates the milkshake
        
        newGameObject.transform.SetParent(transform);

        DeleteFloatingMoney();
    }

    private void DeleteFloatingMoney()
    {
        Destroy(newGameObject.gameObject, lifetime);
    }

   
}
