﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI = null;
    [SerializeField] private GameObject optionsMenuUI = null;
    [SerializeField] private GameObject inventoryMenuUI = null;
    [SerializeField] private Slider volumeSlider = null;
    public static bool gameIsPaused = false;

    private void Start()
    {
        volumeSlider.value = AudioManager.instance.startingVolume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        inventoryMenuUI.SetActive(true);

        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        inventoryMenuUI.SetActive(false);

        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void BackToPause()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void OptionsMenu()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void SetVolume(float sliderValue)
    {
        AudioManager.instance.startingVolume = sliderValue;
        PlayerPrefs.SetFloat("volume", sliderValue);
        AudioManager.instance.UpdateVolume(sliderValue);
    }

    public void PlayAudio()
    {
        //AudioManager.instance.Play("",false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }


}
