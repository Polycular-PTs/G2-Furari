using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Result : MonoBehaviour
{
    [SerializeField] private CheckAndAnswer checkAndAnswer;
    [SerializeField] private Attachments attachments;
    private int extraWordsCount;
    private int essentialWordsCount;

    [SerializeField] private GameObject resultButton;
    [SerializeField] private GameObject resultUI;
    [SerializeField] private GameObject resultSlider;
    [SerializeField] private TextMeshProUGUI resultText;


    [Header("Score Text")]
    public string badScore;
    public string okScore;
    public string goodScore;
    public string greatScore;

    [SerializeField] private MapKnob mapKnob;

    void Start()
    {
        essentialWordsCount = checkAndAnswer.essentialWords.Count + attachments.attachmentsSent;
        extraWordsCount = checkAndAnswer.extraWords.Count;
        resultUI.SetActive(false);
        resultSlider.SetActive(false);
        resultButton.SetActive(false);
    }

    private void Update()
    {
        if (mapKnob.locationRemembdered)
        {
            resultButton.SetActive(true);
        }
    }

    public void ShowResult()
    {
        resultUI.SetActive(true);
        Debug.Log("Essential Words: " + checkAndAnswer.essentialWords.Count);
        if (checkAndAnswer.essentialWords.Count + attachments.attachmentsSent > attachments.attachmentsFound.Length - 1)
        {
            Debug.Log("bad");
            resultSlider.SetActive(false);
            SetResultText(badScore);
        }
        else
        {
            Debug.Log("else");
            ResultText();
            ResultSlider();
        }


    }

    private void ResultText()
    {
        float foundExtraPercent = 100 / extraWordsCount * checkAndAnswer.foundExtraWordsCount; 

        if (IsInRange(foundExtraPercent, 0f, 33f))
        {
            SetResultText(okScore);
            Debug.Log("ok");
        }
        else if (IsInRange(foundExtraPercent, 34f, 66f))
        {
            SetResultText(goodScore);
            Debug.Log("good");
        }
        else if (IsInRange(foundExtraPercent, 67f, 100f))
        {
            SetResultText(greatScore);
            Debug.Log("great");
        }
        
    }

    private void SetResultText(string scoreText)
    {
        resultText.text = scoreText;
    }

    private void ResultSlider()
    {
        Debug.Log("Slider Shown");
        resultSlider.SetActive(true);

        resultSlider.GetComponent<Slider>().maxValue = extraWordsCount + essentialWordsCount;
        resultSlider.GetComponent<Slider>().value = checkAndAnswer.foundExtraWordsCount + essentialWordsCount;
    }

    bool IsInRange(float value, float min, float max)
    {
        return value >= min && value <= max;
    }
}
