using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class RetrieveDataScript : MonoBehaviour
{
    private List<bool> BoughtToppings;
    public CustomerDrinkGenerator DrinkGeneratorScript;
    private void Start()
    {
        LoadPurchases();
        DrinkGeneratorScript.CheckStore();
    }
    private void LoadPurchases()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            Debug.Log("Game Loaded");
            BoughtToppings = data.toppingsBought;
        }
    }

    public List<bool> CheckToppings()
    {
        return BoughtToppings;
    }
}
