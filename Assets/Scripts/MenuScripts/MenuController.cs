using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject Axe;
    private float rotationSpeed = 40f;

    public static int selectedObject;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   

        Axe.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);



    }

    public void SetSelectedObject()
    {

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 3)
        {
            
            selectedObject = 1;
            PlayerPrefs.SetInt("SelectedObject", selectedObject);
            knife.swipeable = true;
            SceneManager.LoadScene("MainMenu");



        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 4)
        {
            selectedObject = 2;
            PlayerPrefs.SetInt("SelectedObject", selectedObject);
            knife.swipeable = true;
            SceneManager.LoadScene("MainMenu");



        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 5)
        {
            selectedObject = 3;
            PlayerPrefs.SetInt("SelectedObject", selectedObject);
            knife.swipeable = true;
            SceneManager.LoadScene("MainMenu");



        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 6)
        {
            selectedObject = 4;
            PlayerPrefs.SetInt("SelectedObject", selectedObject);
            knife.swipeable = true;
            SceneManager.LoadScene("MainMenu");



        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 7)
        {

            selectedObject = 5;
            PlayerPrefs.SetInt("SelectedObject", selectedObject);
            knife.swipeable = true;
            SceneManager.LoadScene("MainMenu");



        }

    }

    public void GoToMainMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }

    public void GoToNextObject()
    {
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 3)
        {
            SceneManager.LoadScene("CharachterSelection-axe");
        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 4)
        {
            SceneManager.LoadScene("CharacterSelection-katana");
        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 5)
        {
            SceneManager.LoadScene("CharacterSelection-betteraxe");
        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 6)
        {
            SceneManager.LoadScene("CharacterSelection-saw");
        }




    }

    public void GoToBackwardObject()
    {
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 4)
        {
            SceneManager.LoadScene("CharachterSelection-knife");
        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 5)
        {
            SceneManager.LoadScene("CharachterSelection-axe");
        }
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 6)
        {
            SceneManager.LoadScene("CharacterSelection-katana");
        }

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).buildIndex == 7)
        {
            SceneManager.LoadScene("CharacterSelection-betteraxe");
        }

    }


    public void RestartActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
