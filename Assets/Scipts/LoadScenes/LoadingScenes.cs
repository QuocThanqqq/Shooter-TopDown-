using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{
    public GameObject loadingScene;
    public Image imageLoading;
    public int idScene;

    public void Loading()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(idScene);
        loadingScene.SetActive(true);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
