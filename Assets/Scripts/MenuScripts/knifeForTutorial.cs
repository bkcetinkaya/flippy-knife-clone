using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeForTutorial : MonoBehaviour
{

    public  Rigidbody Rb;
    public static bool swipeable;


    public int p3alreadyActivated;
    public int p4alreadyActivated;

    private float timeWhenWeStartedFlying;
    public float force = 10f;
    public float torque = 20f;
   



    private Vector2 startSwipePos;
    private Vector2 endSwipePos;

    public TutorialScript tutorialScript;


    void Start()
    {

        Rb.GetComponent<Rigidbody>();
        Rb.isKinematic = true;
        swipeable = false;

        PlayerPrefs.SetInt("p3activated", 0);
        PlayerPrefs.SetInt("p4activated", 0);

      
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startSwipePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endSwipePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Swipe();
        }



    }

    void Swipe()
    {

        if (swipeable)
        {
            Rb.isKinematic = false;

            timeWhenWeStartedFlying = Time.time;

            Vector2 swipe = endSwipePos - startSwipePos;

            Rb.AddForce(swipe * force, ForceMode.Impulse);
            Rb.AddTorque(0, 0, -torque, ForceMode.Impulse);

        }


    }

    private void OnTriggerEnter(Collider other)
    {

        Rb.isKinematic = true;

        if (other.CompareTag("Block") || other.CompareTag("Apple"))
        {
            p3alreadyActivated = PlayerPrefs.GetInt("p3activated", 0);

            if (p3alreadyActivated == 0)
            {

                tutorialScript.ActivatePanel3();
                PlayerPrefs.SetInt("p3activated", 1);
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        p4alreadyActivated = PlayerPrefs.GetInt("p4activated", 0);

        if(p4alreadyActivated == 0)
        {
            Debug.Log("sikerim ha");
            tutorialScript.ActivatePanel4();
            PlayerPrefs.SetInt("p4activated", 1);
        }
    }

}
