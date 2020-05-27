using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public GameObject OnButton;
    public GameObject OffButton;

    public AudioSource audioSource;

    public int value;



    // Start is called before the first frame update
    void Awake()
    {

       value =  PlayerPrefs.GetInt("MusicOn", 1);

        if(value == 1)
        {
            MusicActivated();

        }

        if (value == 0)
        {
            MusicDeactivated();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicActivated()
    {
        
        OffButton.SetActive(false);
        OnButton.SetActive(true);
        audioSource.volume = 1;

        PlayerPrefs.SetInt("MusicOn", 1);

    }


    public void MusicDeactivated()
    {

        OnButton.SetActive(false);
        OffButton.SetActive(true);
        audioSource.volume = 0;

        PlayerPrefs.SetInt("MusicOn", 0);
    }

}
