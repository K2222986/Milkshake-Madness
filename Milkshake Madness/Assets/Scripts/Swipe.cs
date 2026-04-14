using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject Kitchen;
    public GameObject Counter;
    public GameObject LevelMenu;
    public GameObject Milkshake;
    public GameObject Fruits;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Update()
    {
        if (!LevelMenu.activeSelf)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                if (endTouchPosition.x > startTouchPosition.x + 400)
                {
                    SetCounter();
                }

                if (endTouchPosition.x < startTouchPosition.x - 400)
                {
                    SetKitchen();
                }
                if (endTouchPosition.y > startTouchPosition.y + 400)
                {
                    GiveDrink();
                }
            }
        }
    }

    public void SetKitchen()
    {
        Kitchen.SetActive(true);
        Counter.SetActive(false);
    }

    public void SetCounter()
    {
        Counter.SetActive(true);
        Kitchen.SetActive(false);
    }

    public void GiveDrink()
    {
        CustomerDrinkGenerator.Instance.CheckMilkShake();
        changeMilkshake.Instance.ClearMilkshake();
        ChangeTopping.Instance.NoTopping();
        Milkshake.SetActive(false);
        Fruits.SetActive(false);
    }
}
