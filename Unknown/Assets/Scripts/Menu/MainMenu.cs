using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject OptionsMenuUI;
    [SerializeField] private GameObject CreditsMenuUI;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle fullscreenToggle;



    private void Start()
    {
               
        volumeSlider.value = AudioManager.instance.startingVolume;
       // AudioManager.instance.Play("MusicMenu", true); musica de menu.
    }

    public void PlaySound()
    {
        //AudioManager.instance.Play("", false); sonido de boton clickeado.
    }

    public void OptionsMenu()
    {
        MainMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);

    }
    public void CreditsMenu()
    {
        OptionsMenuUI.SetActive(false);
        CreditsMenuUI.SetActive(true);
    }

    public void BackToMainMenu()
    {
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void BackToOptionsMenu()
    {
        CreditsMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void SetVolume(float sliderValue)
    {
        AudioManager.instance.startingVolume = sliderValue;
        PlayerPrefs.SetFloat("volume", sliderValue);
        AudioManager.instance.UpdateVolume(sliderValue);

    }


    public void SetFullscreen(bool isFullscreen)
    {
        PlayerPrefs.SetString("fullscreen", isFullscreen.ToString());
        if (isFullscreen)
        {
            Screen.SetResolution(1920, 1080, isFullscreen);
        }
        else
        {
            Screen.SetResolution(1024, 768, isFullscreen);

        }
    }
}

