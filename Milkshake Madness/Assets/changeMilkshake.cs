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

    public void BananaSprite()
    {
        spriteRenderer.sprite = banana;
    }
    public void PeachSprite()
    {
        spriteRenderer.sprite = peach;
    }
    public void WatermelonSprite()
    {
        spriteRenderer.sprite = watermelon;
    }
    public void BlueberrySprite()
    {
        spriteRenderer.sprite = blueberry;
    }
}
