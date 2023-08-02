using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToIntro : MonoBehaviour
{
    public GameObject loadPage;

    private void Start()
    {
        loadPage.SetActive(true);    
        OnSkip();           
    }

    public void OnSkip()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

}
