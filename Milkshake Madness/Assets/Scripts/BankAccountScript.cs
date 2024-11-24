using TMPro;
using UnityEngine;

public class BankAccountScript : MonoBehaviour
{
    public TextMeshProUGUI BankAccount;
    public TextMeshProUGUI RequiredAmount;

    private float TotalAmount = 0;

    private void Start()
    {
        UpdateAccount(0);
    }

    public float GetAccount() { return TotalAmount; }
    public void UpdateAccount(float amount) 
    { 
        TotalAmount += amount;
        BankAccount.text = "Bank Account: $" + TotalAmount;
    }

    public void SetRequiredAmount( float amount) { RequiredAmount.text = "Required amount: $" + amount; }



   
}
