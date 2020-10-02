using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI = null;
    [SerializeField] private GameObject OptionsMenuUI = null ;
    [SerializeField] private GameObject CreditsMenuUI = null ;
    [SerializeField] private Slider volumeSlider = null;
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

