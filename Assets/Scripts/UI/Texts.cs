using System.Collections;
using TMPro;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] text;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == text[index])
            {
                NextText();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = text[index];
            }
        }
    }

    void StartText()
    {
        index = 0;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        // Type text one letter at a time
        foreach (char letter in text[index].ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextText()
    {
        if (index < text.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeText());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
