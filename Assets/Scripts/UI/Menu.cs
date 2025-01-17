﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    #region Singleton
    public static Menu instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    //Arrow Counter
    public Text Arrowcounterdisplay;
    public int ArrowCounter;
    public int MaxArrowAmount;

    //Display
    public Slider sensesslide;
    public Text sensestext;
    public Toggle exploration;

    private void Start()
    {
        if(sensesslide != null && sensesslide.value == 0)
        {
            sensesslide.value = 25;
        }
    }


    private void Update()
    {
        if (Arrowcounterdisplay != null)
        {
            Arrowcounterdisplay.text = "";
            Arrowcounterdisplay.text = ArrowCounter.ToString() + "/" + MaxArrowAmount.ToString();
        }else
        if(sensesslide != null)
        {
            Preferencesholder.instance.MouseSensitivity = sensesslide.value;
            Preferencesholder.instance.isExplorationMode = exploration.isOn;
            sensestext.text = (sensesslide.value).ToString();
        }
 
    }






    //Methods to ad and remove arrows
    public void AddArrow(int numbertoadd)
    {
       if(ArrowCounter != MaxArrowAmount)
        {
            ArrowCounter += numbertoadd;
        }
        if (ArrowCounter > MaxArrowAmount)
            ArrowCounter = MaxArrowAmount;
    }
    public void RemoveArrow()
    {
        if(ArrowCounter != 0)
        ArrowCounter -= 1;
        if (ArrowCounter < 0)
            ArrowCounter = 0;
    }
    //Main menu Methods
    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void OpenOptions(GameObject optionsmenu)
    {
        optionsmenu.SetActive(true);
    }
    public void CloseOptionsmenu(GameObject optinonsmenu)
    {
        optinonsmenu.SetActive(false);
    }

}
