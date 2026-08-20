using TMPro;
using UnityEngine;

public class Send : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Attachments attachments;

    [SerializeField] private GameObject message;

    [SerializeField] private GameObject chatField;

    [SerializeField] private CheckAndAnswer checkAndAnswer;

    public void MessageSent()
    {
        if (inputField.text != null)
        {
            GameObject newMessage = Instantiate(message, chatField.transform);
            newMessage.GetComponent<TextMeshProUGUI>().text = inputField.text;
            StartCoroutine(checkAndAnswer.CheckMessage(inputField.text));
        }
    }

    public void SendPrompt()
    {
        GameObject blankMessage = Instantiate(message, chatField.transform);
        blankMessage.GetComponent<TextMeshProUGUI>().text = "........";
        
        GameObject newMessage = Instantiate(message, chatField.transform);
        var x = newMessage.GetComponent<TextMeshProUGUI>();
        x.text = "Tell me ALL you have learned so far and then finish your hacking!";
        x.alignment = TextAlignmentOptions.Left;
    }

    public void AttachmentSent(int index) 
    {
        GameObject newMessage = Instantiate(message, chatField.transform);
        newMessage.GetComponent<TextMeshProUGUI>().text = attachments.attachmentTextObjects[index].GetComponent<TextMeshProUGUI>().text;
        Destroy(attachments.attachmentTextObjects[index]);
        attachments.AttachmentAnswer();
    }


}
