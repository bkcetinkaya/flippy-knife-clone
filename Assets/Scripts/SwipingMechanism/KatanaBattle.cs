using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KatanaBattle : MonoBehaviour
{
    private Vector2 startSwipePos;
    private Vector2 endSwipePos;

    public static bool swipeable;
    public bool isDead;

    public Rigidbody rb;

    private float timeWhenWeStartedFlying;
    private float force = 4f;
    private float torque = 5f;

    public AudioSource GameOverSound;
    public AudioSource SuccesSound;

    private bool isLanded;

    private void Start()
    {
        swipeable = true;
        isDead = false;
    }
    // Update is called once per frame
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
            if (isLanded)
            {
                rb.isKinematic = false;

                timeWhenWeStartedFlying = Time.time;

                Vector2 swipe = endSwipePos - startSwipePos;

                rb.AddForce(swipe * force, ForceMode.Impulse);
                rb.AddTorque(0, 0, -torque, ForceMode.VelocityChange);
                isLanded = false;
            }
        
        }

    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Block"))
        {
            rb.isKinematic = true;
            isLanded = true;
           
        

            
        }

        if (other.CompareTag("Level1Door") && isDead == false)
        {

            //SuccesSound.Play();
            PlayerPrefs.SetInt("Level1Passed", 1);
            StartCoroutine("SuccesSoundDelay", 2);
           // SceneManager.LoadScene("Map2");
            return;

        }

        if (other.CompareTag("Level2Door") && isDead == false)
        {
            //SuccesSound.Play();
            PlayerPrefs.SetInt("Level2Passed", 1);
            StartCoroutine("SuccesSoundDelay", 2);
            return;

        }

        if (other.CompareTag("Level3Door") && isDead == false)
        {
           // SuccesSound.Play();
            PlayerPrefs.SetInt("Level3Passed", 1);
            StartCoroutine("SuccesSoundDelay", 2);
            return;

        }

        if (other.CompareTag("Level4Door") && isDead == false)
        {
           // SuccesSound.Play();
            PlayerPrefs.SetInt("Level4Passed", 1);
            StartCoroutine("SuccesSoundDelay", 2);
            return;

        }




        if (other.CompareTag("Ground") && isDead == false)
        {

            //SuccesSound.Play();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //GameOverSound.Play();
            StartCoroutine("GameOverSoundDelay",2);


        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        float timeinAir = Time.time - timeWhenWeStartedFlying;

        if (collision.collider.CompareTag("Level1Door"))
        {
            PlayerPrefs.SetInt("Level1Passed", 1);
            //SuccesSound.Play();
          
            return;
        }

        if (collision.collider.CompareTag("Level2Door"))
        {
            PlayerPrefs.SetInt("Level2Passed", 1);
            //SuccesSound.Play();
            //SceneManager.LoadScene("Map3");
            return;
        }

        if (collision.collider.CompareTag("Level3Door"))
        {
            PlayerPrefs.SetInt("Level3Passed", 1);
           // SuccesSound.Play();
            //SceneManager.LoadScene("Map4");
            return;
        }

        if (collision.collider.CompareTag("Level4Door"))
        {
            PlayerPrefs.SetInt("Level4Passed", 1);
           // SuccesSound.Play();
           // SceneManager.LoadScene("Map5");
            return;
        }

        if (collision.collider.CompareTag("Level5Door"))
        {
            PlayerPrefs.SetInt("Level5Passed", 1);
            //SuccesSound.Play();
           // SceneManager.LoadScene("Map5");
            return;
        }

        if (collision.collider.CompareTag("Level6Door"))
        {
           // SuccesSound.Play();
            //SceneManager.LoadScene("Credits");
        }


        if (!rb.isKinematic && timeinAir >= .05f && isDead == false)
        {

            StartCoroutine("GameOverSoundDelay", 2);
            

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Debug.Log("Collision");

            //GameOverSound.Play();
          

        }

      
    }

    public void MenuButtonPressed()
    {

        SceneManager.LoadScene("MainMenu");
    }


    public void RestartButtonPressed()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    IEnumerator GameOverSoundDelay(int seconds)
    {
        swipeable = false;
        isDead = true;
        GameOverSound.Play();
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator SuccesSoundDelay(int seconds)
    {
        swipeable = false;
        isDead = true;
        SuccesSound.Play();
        yield return new WaitForSeconds(seconds);

        
        if(SceneManager.GetActiveScene().buildIndex == 13) 
        {
            SceneManager.LoadScene("Map2");
        }

        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            SceneManager.LoadScene("Map3");
        }

        if (SceneManager.GetActiveScene().buildIndex == 15)
        {
            SceneManager.LoadScene("Map4");
        }

        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            SceneManager.LoadScene("Map5");
        }

        if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            SceneManager.LoadScene("Map6");
        }

        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            SceneManager.LoadScene("Credits");
        }

    }

}
