using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{



    private int money;

    private int priceOfKatana;
    private int priceOfBetterAxe;
    private int priceOfSabre;

    public bool isBetterAxePurchased;
    public bool isKatanaPurchased;

    public GameObject SelectButton;
    public GameObject BuyButton;
    public GameObject priceText;
    public GameObject prosConsText;

    

    public AudioSource BoughtSound;

    public GameObject NotEnoughMoneyText;


    public ParticleSystem particles;

   

    // Start is called before the first frame update
    void Start()
    {

       

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (PlayerPrefs.GetInt("KatanaPurchased", 0) == 1)
            {

                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                priceText.SetActive(false);
                prosConsText.SetActive(true);


            }
        }

       

        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (PlayerPrefs.GetInt("BetterAxePurchased", 0) == 1)
            {

                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                priceText.SetActive(false);
                prosConsText.SetActive(true);

            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (PlayerPrefs.GetInt("SawPurchased", 0) == 1)
            {

                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                priceText.SetActive(false);
                prosConsText.SetActive(true);

            }
        }






        money = PlayerPrefs.GetInt("TotalCoin", 0);
        priceOfKatana = 300;
        priceOfBetterAxe = 500;
        priceOfSabre = 5000;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyKatana()
    {

        if (money >= priceOfKatana)
        {

            int lastMoney = money - priceOfKatana;


            SelectButton.SetActive(true);
            BuyButton.SetActive(false);
            priceText.SetActive(false);
            prosConsText.SetActive(true);

            PlayerPrefs.SetInt("KatanaPurchased", 1);

            PlayerPrefs.SetInt("TotalCoin", lastMoney);

            particles.Play();

            BoughtSound.Play();

            //set selected item

        }

        if (money < priceOfKatana)
        {

            StartCoroutine("NotEnoughMoney", 2);

        }


    }

    public void BuyBetterAxe()
    {


        if (money >= priceOfBetterAxe)
        {

            int lastMoney = money - priceOfBetterAxe;


            SelectButton.SetActive(true);
            BuyButton.SetActive(false);
            priceText.SetActive(false);
            prosConsText.SetActive(true);

            isBetterAxePurchased = true;
          



            PlayerPrefs.SetInt("BetterAxePurchased", 1);

            PlayerPrefs.SetInt("TotalCoin", lastMoney);

            particles.Play();
            BoughtSound.Play();

            //set selected item

        }


        if (money < priceOfBetterAxe)
        {

            StartCoroutine("NotEnoughMoney", 2);

        }
    }

    public void BuySaw()
    {


        if (money >= priceOfSabre)
        {

            int lastMoney = money - priceOfSabre;


            SelectButton.SetActive(true);
            BuyButton.SetActive(false);
            priceText.SetActive(false);
            prosConsText.SetActive(true);

            isBetterAxePurchased = true;



            PlayerPrefs.SetInt("SawPurchased", 1);

            PlayerPrefs.SetInt("TotalCoin", lastMoney);

            particles.Play();
            BoughtSound.Play();

            //set selected item

        }

        if (money < priceOfSabre)
        {

            StartCoroutine("NotEnoughMoney",2);

        }


    }



    IEnumerator NotEnoughMoney(int time)
    {
        NotEnoughMoneyText.SetActive(true);

        yield return new WaitForSeconds(time);

        NotEnoughMoneyText.SetActive(false);


    }


}


