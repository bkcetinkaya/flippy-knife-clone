using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{



    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public GameObject button;


    public void EndTutorial()
    {

        SceneManager.LoadScene("MainMenu");

    }



    public void DeactivatePanel()
    {

        panel1.SetActive(false);
        panel2.SetActive(true);

    }


    public void DeactivatePanel2()
    {

        panel2.SetActive(false);
        button.SetActive(true);
        StartCoroutine(Delayer(1));
        
        
        

    }

    IEnumerator Delayer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        knifeForTutorial.swipeable = true;


    }

    public  void ActivatePanel3()
    {
        panel3.SetActive(true);
        knifeForTutorial.swipeable = false;

    
    }


    public void DeactivatePanel3()
    {

        panel3.SetActive(false);
        knifeForTutorial.swipeable = true;
    }

    public void ActivatePanel4()
    {
        panel4.SetActive(true);
        knifeForTutorial.swipeable = false;


    }


    public void DeactivatePanel4()
    {

        panel4.SetActive(false);
        knifeForTutorial.swipeable = true;
    }



}
