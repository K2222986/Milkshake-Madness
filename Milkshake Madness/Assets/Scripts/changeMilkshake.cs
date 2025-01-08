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
    // milk shake flavour numbers 1: blueBerry, 2: watermelon, 3: peach, 4: bannana

    public void BananaSprite()
    {
        spriteRenderer.sprite = banana;
        milkshakeID = 4;
    }
    public void PeachSprite()
    {
        spriteRenderer.sprite = peach;
        milkshakeID = 3;
    }
    public void WatermelonSprite()
    {
        spriteRenderer.sprite = watermelon;
        milkshakeID = 2;
    }
    public void BlueberrySprite()
    {
        spriteRenderer.sprite = blueberry;
        milkshakeID = 1;
    }
    public void ClearMilkshake()
    {
        spriteRenderer.sprite = empty;
        milkshakeID = 0;
    }

    public int GetMilkShakeID() {return milkshakeID;}
}
