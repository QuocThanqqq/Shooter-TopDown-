using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string sceneName;
    public int dnaPass;

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerSystem.numberDNA >= dnaPass)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
