using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelsManager : MonoBehaviour
{

    public Button button1;
    public Color theColor;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject lock5;





    // Start is called before the first frame update
    void Start()
    {

        


        if(PlayerPrefs.GetInt("Level1Passed") == 1)
        {
            UnlockTheLock(lock1);
        }

        if (PlayerPrefs.GetInt("Level2Passed") == 1)
        {
            UnlockTheLock(lock2);
        }

        if (PlayerPrefs.GetInt("Level3Passed") == 1)
        {
            UnlockTheLock(lock3);
        }

        if (PlayerPrefs.GetInt("Level4Passed") == 1)
        {
            UnlockTheLock(lock4);
        }

        if (PlayerPrefs.GetInt("Level5Passed") == 1)
        {
            UnlockTheLock(lock5);
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1ButtonPressed()
    {
        SceneManager.LoadScene("Map1");

        
    }

    public void Level2ButtonPressed()
    {
        SceneManager.LoadScene("Map2");

    }

    public void Level3ButtonPressed()
    {
        SceneManager.LoadScene("Map3");

    }


    public void Level4ButtonPressed()
    {
        SceneManager.LoadScene("Map4");

    }

    public void Level5ButtonPressed()
    {
        SceneManager.LoadScene("Map5");

    }

    public void Level6ButtonPressed()
    {
        SceneManager.LoadScene("Map6");

    }

  


    public void UnlockTheLock(GameObject image)
    {

        image.SetActive(false);
        
        

    }

    public void BackPressed()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
