using TMPro;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.SceneManagement;

public class GameControlerScript : MonoBehaviour
{
    // pause overlay menu
    public GameObject MenuOverlay;

    // Win or loose text
    public WinOrLooseScript WinOrLooseScript;

    // Level text
    public GameObject LevelWindow;
    public TextMeshProUGUI LevelText;

    //Money Stuff
    public BankAccountScript BankAcccount;
    public FloatingMoneyScript FloatingMoney;
    public float RequiredMoney = 50;

    // Timer Stuff
    public TimeofDayScript TimeBar;
    public float MaxTime;
    public float CurrentTime;

    public int Level;
    public int MaxLevel;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("Level")) // changed from MaxLevel
        {
            Level = PlayerPrefs.GetInt("Level");// changed from MaxLevel
        }
        else
        {
            Level = 0;
            PlayerPrefs.SetInt("Level",Level);// changed from MaxLevel
        }
        LevelText.text = "Level " + Level;
        Debug.Log(Level);
        DifficultyChange();
       

        //Money stuff
        BankAcccount.SetRequiredAmount(RequiredMoney);

        // Time Stuff
        TimeBar.SetMaxTime(MaxTime);
        CurrentTime = MaxTime;
        InvokeRepeating("DecreaseTime", 1.0f, 1.0f); // decreases the timer by 1


        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecreaseTime()
    {
        if (MenuOverlay.activeSelf || LevelWindow.activeSelf)
        {
            // do nothing
        }
        else if (CurrentTime > 0)
        {
            CurrentTime -= 1;
            TimeBar.SetCurrentTime(CurrentTime);
        }
        else if (CurrentTime <= 0)
        {
            LevelOver();
        }
    }

    private void LevelOver() // checks if the player has gotten enough money
    {
        Debug.Log("The game is over!");


        if (RequiredMoney <= BankAcccount.GetAccount())
        {
            LevelWon();
        }
        else
        {
           LevelLost();
        }
       
    }
    private void LevelLost()
    {
        Debug.Log("You have lost! :(");
        WinOrLooseScript.GameLostText();
        Invoke("LoadMenu", 3f);
    }

    private void LevelWon()
    {
        Debug.Log("You have won! :)");
        WinOrLooseScript.GameWonText();
        PlayerPrefs.SetInt("Level", Level + 1);
        Invoke("LoadMenu", 3f);
    }

   void DifficultyChange()
    {
        RequiredMoney = RequiredMoney + Level * 8;
        if (RequiredMoney > 100)
        {
            RequiredMoney = 100;
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void LevelMenu()
    {

    }
}
