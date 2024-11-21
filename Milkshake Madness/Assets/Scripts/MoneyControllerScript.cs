using UnityEngine;

public class MoneyControllerScript : MonoBehaviour
{
    private float Money;

    private void Awake()
    {
        // spawn money object 
    }

    private void Update()
    {
        // move the money upwards and make it fade away 
    }

    void MoneySpawner()
    {

    }


    void MoneyIncrementer(float amount)
    {
        Money += amount; // increase or decrease money 
    }

    void ResetMoney()
    {
        Money = 0;
    }
}
