using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI = null;
    [SerializeField] private GameObject OptionsMenuUI = null ;
    [SerializeField] private GameObject CreditsMenuUI = null ;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Slider effectsSlider = null;
    [SerializeField] public Toggle fullscreenToggle = null;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlaySound()
    {
        //AudioManager.instance.Play("", false); sonido de boton clickeado.
    }

    public void OptionsMenu()
    {
        volumeSlider.value = AudioManager.instance.startingVolume;
        musicSlider.value = AudioManager.instance.startingVolume;
        effectsSlider.value = AudioManager.instance.startingVolume;
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
        AudioManager.instance.UpdateEffectsVolume(sliderValue);
        AudioManager.instance.UpdateMusicVolume(sliderValue);

    }

    public void SetEffectsVolume(float sliderValue)
    {
        AudioManager.instance.UpdateEffectsVolume(sliderValue);
    }

    public void SetMusicVolume(float sliderValue)
    {
        AudioManager.instance.UpdateMusicVolume(sliderValue);
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

