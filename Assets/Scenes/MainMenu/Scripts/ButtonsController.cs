using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] public UnityEngine.Canvas main;

    [SerializeField] public UnityEngine.Canvas options;

    [SerializeField] public UnityEngine.Canvas loading;

    [SerializeField] public Scrollbar scrollbar;

    [SerializeField] public Text loadingInfo;

    public void Awake()
    {
        main.enabled = true;
        loading.enabled = false;
        options.enabled = false;
    }

    public void PlayGame()
    {
        main.enabled = false;
        loading.enabled = true;
        StartCoroutine(LoadSceneAsync("SampleScene"));
    }

    public void OpenSettings()
    {
        main.enabled = false;
        options.enabled=true;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void BackToMainMenu(){
        options.enabled = false;
        main.enabled = true;
    }
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            scrollbar.value = progress;
            loadingInfo.text = $"Загрузка: {progress * 100}%";
            yield return null;
        }
    }
}