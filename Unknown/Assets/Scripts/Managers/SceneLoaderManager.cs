using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{

    [SerializeField] private string levelName;
        
    public void ChangeLevel()
    {
        StartCoroutine(ChangingLevel());
    }

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void Menu()
    {
        StartCoroutine(LoadMenu());
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private IEnumerator ChangingLevel()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.StopSound("MenuMusic");
        AudioManager.instance.Play("AmbientHorror", true);
        SceneManager.LoadScene(levelName);
    }

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    

}
