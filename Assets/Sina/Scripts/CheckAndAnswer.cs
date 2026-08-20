using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckAndAnswer : MonoBehaviour
{
    [Header("Words")]
    [SerializeField] public List<string> essentialWords;
    [SerializeField] public List<string> extraWords;
    [SerializeField] private List<string> foundWords;
    public int foundExtraWordsCount = 0;


    [Header("Attachments")]
    [SerializeField] private Attachments attachments;
    public RectTransform scrollwindow;

    [Header("Answers")]
    public GameObject answerObject;
    [SerializeField] private List<string> answerChoice;
    [SerializeField] private GameObject chatField;
    private float responseTime = 0.7f;

    public IEnumerator CheckMessage(string message)
    {
        Debug.Log("hier");
        yield return new WaitForSeconds(responseTime);

        if (essentialWords.Contains(message))
        {
            Answer(0);
            ListUpdate(message, essentialWords);
            Debug.Log("Essential Words: " + essentialWords.Count);
        }
        else if (extraWords.Contains(message))
        {
            Answer(1); 
            ListUpdate(message, extraWords);
            foundExtraWordsCount++;
            Debug.Log("Extra Words: " + extraWords.Count);
            Debug.Log("Found Extra Words:" + foundExtraWordsCount);
        }
        else if (foundWords.Contains(message))
        {
            Answer(2);
        }
        else
        {
            Answer(3);
        }

        scrollwindow.anchoredPosition = new Vector2(0, scrollwindow.sizeDelta.y/2);
    }

    private void ListUpdate(string message, List<string> wordType)
    {
        foundWords.Add(message);
        wordType.Remove(message);
    }

    public void Answer(int answerChoiceIndex)
    {
        GameObject answer = Instantiate(answerObject, chatField.transform);
        answer.GetComponent<TextMeshProUGUI>().text = answerChoice[answerChoiceIndex];
    }
}
