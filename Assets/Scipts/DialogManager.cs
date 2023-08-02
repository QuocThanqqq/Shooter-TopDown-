using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text textDialog;
    public string[] lines;
    public float textSpeed;

    private int index;
    void Start()
    {
        textDialog.text = string.Empty;
        StartDialog();
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (textDialog.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textDialog.text = lines[index];
            }
        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textDialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
