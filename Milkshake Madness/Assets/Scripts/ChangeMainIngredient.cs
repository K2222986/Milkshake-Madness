using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMainIngredient : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite banana;
    public Sprite peach;
    public Sprite watermelon;
    public Sprite blueberry;
    public Sprite empty;

    private int MainIngredientID;
    // milk shake flavour numbers 1: blueBerry, 2: watermelon, 3: peach, 4: bannana

    public void BananaSprite()
    {
        spriteRenderer.sprite = banana;
        MainIngredientID = 4;
    }
    public void PeachSprite()
    {
        spriteRenderer.sprite = peach;
        MainIngredientID = 3;
    }
    public void WatermelonSprite()
    {
        spriteRenderer.sprite = watermelon;
        MainIngredientID = 2;
    }
    public void BlueberrySprite()
    {
        spriteRenderer.sprite = blueberry;
        MainIngredientID = 1;
    }
    public void ClearMilkshake()
    {
        spriteRenderer.sprite = empty;
        MainIngredientID = 0;
    }

    public int GetMilkShakeID() { return MainIngredientID; }
}

