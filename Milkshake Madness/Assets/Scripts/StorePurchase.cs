using TMPro;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using NUnit.Framework;
using Unity.VisualScripting;

public class StorePurchase : MonoBehaviour
{
    public TextMeshProUGUI PurchaseText;
    public Bundle[] soldItems;
    private Bundle purchase;

    private void Start()
    {
        LoadPurchases();
    }
    public void UpdateText(string item)
    {
        PurchaseText.text = "Are you sure you want to purchase the " + item;
    }
    public void SetupPurchase(Bundle item)
    {
        purchase = item;
        if (purchase.sold)
        {
            PurchaseText.text = "You have already purchased this item";
        }
    }
    public void ConfirmPurchase()
    {
        purchase.SetSold(true);
        SavePurchase();
    }
    public void SavePurchase()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        if(File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/save.dat");
        }
        SaveData data = new SaveData();
        foreach(Bundle s in soldItems)
        {
            data.toppingsBought.Add(s.sold);
        }

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game Saved");
    }
    public void LoadPurchases()
    {
        if(File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            for(int i = 0; i < data.toppingsBought.Count; i++)
            {
                soldItems[i].sold = data.toppingsBought[i];
            }
            file.Close();
            Debug.Log("Game Loaded");
        }
    }
}

[Serializable]

public class SaveData
{
    public List<bool> toppingsBought;

    public SaveData()
    {
        toppingsBought = new List<bool>();
    }
}
