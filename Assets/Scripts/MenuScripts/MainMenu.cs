using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour

    
{

    

    public  TextMeshProUGUI CoinText;

    public Button button1;

   // public static int coinCount;
   // public static int globalCoin;

    


    private void Start()
    {

        CoinText.text = PlayerPrefs.GetInt("TotalCoin", 0).ToString() + "$";
        PlayerPrefs.SetInt("p3activated", 0);

    }


    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadSelectScene()
    {

        SceneManager.LoadScene("CharachterSelection-knife");

    }


    public void PlayButtonPressed()
    {



       int selectedObject = PlayerPrefs.GetInt("SelectedObject", 0);


        if(selectedObject == 0)
        {

            SceneManager.LoadScene("CharachterSelection-knife");
        }

        if(selectedObject == 1)
        {
            knife.swipeable = true;
            SceneManager.LoadScene("KnifeSelected");
        }

        if (selectedObject == 2)
        {
            knife.swipeable = true;
            SceneManager.LoadScene("AxeSelected");
        }
        if (selectedObject == 3)
        {
            knife.swipeable = true;
            SceneManager.LoadScene("KatanaSelected");
        }

        if (selectedObject == 4)
        {
            knife.swipeable = true;
            SceneManager.LoadScene("BetterAxeSelected");
        }

        if (selectedObject == 5)
        {
            knife.swipeable = true;
            SceneManager.LoadScene("SawSelected");
        }



        //if (MenuController.selectedObject == 0)
        //{
        //    knife.swipeable = true;
        //    SceneManager.LoadScene("KnifeSelected");

        //}


        //if (MenuController.selectedObject == 1)
        //{
        //    knife.swipeable = true;
        //    SceneManager.LoadScene("KnifeSelected");

        //}



        //if (MenuController.selectedObject == 2)
        //{
        //    knife.swipeable = true;
        //    SceneManager.LoadScene("AxeSelected");

        //}

    }

    public void PressedExtra()
    {
        SceneManager.LoadScene("ExtraLevelList");


    }

    

}
