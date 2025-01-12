using TMPro;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.SceneManagement;


public class ChangeTopping : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite caramel;
    public Sprite chocolate;
    public Sprite choppedNuts;
    public Sprite sprinkles;
    private int toppingsID;
    private changeMilkshake Milkshake;
    public GameObject MilkShakeStation;

  

    private void Start()
    {
        Milkshake = MilkShakeStation.GetComponent<changeMilkshake>();
    }
    public void NoTopping()
    {
        
        spriteRenderer.sprite = null;
        toppingsID = 0;
    }
    public void CaramelSprite()
    {
        if (Milkshake.GetMilkShakeID() != 0 && Milkshake.gameObject.activeSelf)
        {
            spriteRenderer.sprite = caramel;
            toppingsID = 1;
        }
    }
    public void ChocolateSprite()
    {
        if (Milkshake.GetMilkShakeID() != 0 && Milkshake.gameObject.activeSelf)
        {
            spriteRenderer.sprite = chocolate;
            toppingsID = 2;
        }
    }
    public void ChoppedNutsSprite()
    {
        if (Milkshake.GetMilkShakeID() != 0 && Milkshake.gameObject.activeSelf)
        {
            spriteRenderer.sprite = choppedNuts;
            toppingsID = 3;
        }
    }
    public void SprinklesSprite()
    {
        if (Milkshake.GetMilkShakeID() != 0 && Milkshake.gameObject.activeSelf)
        {
            spriteRenderer.sprite = sprinkles;
            toppingsID = 4;
        }
    }
    public int GetToppingsID() { return toppingsID; }
}
