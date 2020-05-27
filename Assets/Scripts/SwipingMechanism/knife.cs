using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class knife : MonoBehaviour
{


    public static  bool swipeable = true;

    [SerializeField] private TextMeshProUGUI moneyText;


    public AudioSource StabbedSound;
    public AudioSource StabbedAppleSound;
    public AudioSource GameOverSound;

    public Rigidbody rb;
    public TextMeshProUGUI scoretext;

    public GameObject UIPanel;
    public GameObject PlayerObject;

    public BoxCollider boxCollider;



    private float timeWhenWeStartedFlying;
    private float force = 4f;
    private float torque = 5f;

   

    private Vector2 startSwipePos;
    private Vector2 endSwipePos;


    public int score;
    public static int totalCoin;

    


    public static PlayerPrefs playerPrefs = new PlayerPrefs();


    private void Start()
    {
        totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);

        score = 0;
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
            rb.isKinematic = false;

            timeWhenWeStartedFlying = Time.time;

            Vector2 swipe = endSwipePos - startSwipePos;

            rb.AddForce(swipe * force, ForceMode.Impulse);
            rb.AddTorque(0, 0, -torque, ForceMode.Impulse);
        }

    }

    public void ActivatePanel()
    {

        UIPanel.SetActive(true);
        rb.isKinematic = true;

    }

    public void PressedRestart()
    {
        UIPanel.SetActive(false);
        swipeable = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);




    }

    public void PressedMainMenu()
    {
        UIPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");



    }

    public void PressedSelectCharacter()
    {
        UIPanel.SetActive(false);
        SceneManager.LoadScene("CharachterSelection-knife");



    }

    public void SetCoins()
    {

        totalCoin += score;

        PlayerPrefs.SetInt("TotalCoin", totalCoin);

    }

    private void OnTriggerEnter(Collider other)
    {


        if (boxCollider.CompareTag("Apple"))
        {
            rb.isKinematic = true;


            StabbedAppleSound.Play();

            if (PlayerObject.CompareTag("Axe"))
            {
                score += 4;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Knife"))
            {
                score += 2;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Katana"))
            {
                
                score += 6;
                scoretext.text = score.ToString() + "$";


            }

            if (PlayerObject.CompareTag("BetterAxe"))
            {
                score += 10;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Saw"))
            {
                score += 20;
                scoretext.text = score.ToString() + "$";
            }

           

        }


        //if (boxCollider.CompareTag("Block"))
        //{
        //    swipeable = false;
        //    ActivatePanel();
        //    SetCoins();
        //    GameOverSound.Play();
        //}
         

                 //was other
            if (other.CompareTag("Block"))
        {

            rb.isKinematic = true;
            StabbedSound.Play();
           

            if (PlayerObject.CompareTag("Axe"))
            {
                score += 2;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Knife"))
            {
                score += 1;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Katana"))
            {
             
                score += 3;   
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("BetterAxe"))
            {
                score += 5;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Saw"))
            {
                score += 10;
                scoretext.text = score.ToString() + "$";
            }

            return;

        }


        if (other.CompareTag("Ground"))
        {
            swipeable = false;
            ActivatePanel();
            SetCoins();
            GameOverSound.Play();

          }

        if (other.CompareTag("Apple"))
        {

            StabbedAppleSound.Play();
            rb.isKinematic = true;


            

            if (PlayerObject.CompareTag("Axe"))
            {
                score += 4;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Knife"))
            {
                score += 2;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Katana"))
            {
                score += 6;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("BetterAxe"))
            {
                score += 10;
                scoretext.text = score.ToString() + "$";
            }

            if (PlayerObject.CompareTag("Saw"))
            {
                score += 20;
                scoretext.text = score.ToString() + "$";
            }


        }


        

    }


    private void OnCollisionEnter(Collision collision)
    {

        float timeinAir = Time.time - timeWhenWeStartedFlying;

       

        if (!rb.isKinematic && timeinAir >= .05f )
        {



            Debug.Log("Collision");
                GameOverSound.Play();
                swipeable = false;
                ActivatePanel();
                SetCoins();

        }


    }

  
    IEnumerator SpawnMoneyText(int seconds)
    {

        
        yield return new WaitForSeconds(seconds);
        

    }

}
 