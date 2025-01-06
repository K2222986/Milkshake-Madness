using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMilkshake : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite banana;
    public Sprite peach;
    public Sprite watermelon;
    public Sprite blueberry;
    public Sprite empty;

    private int milkshakeID;
    // milk shake flavour numbers 0: blueBerry, 1: watermelon, 2: peach, 3: bannana

    public void BananaSprite()
    {
        spriteRenderer.sprite = banana;
        milkshakeID = 3;
    }
    public void PeachSprite()
    {
        spriteRenderer.sprite = peach;
        milkshakeID = 2;
    }
    public void WatermelonSprite()
    {
        spriteRenderer.sprite = watermelon;
        milkshakeID = 1;
    }
    public void BlueberrySprite()
    {
        spriteRenderer.sprite = blueberry;
        milkshakeID = 0;
    }
    public void ClearMilkshake()
    {
        spriteRenderer.sprite = empty;
        milkshakeID = 5;
    }

    public int GetMilkShakeID() {return milkshakeID;}
}
