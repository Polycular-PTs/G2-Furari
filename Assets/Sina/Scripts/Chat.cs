using UnityEngine;

public class Chat : MonoBehaviour
{
    [SerializeField] private GameObject chat;
    private bool chatActive = false;
    [SerializeField] private GameObject attachmentList;
    private bool attachmentListActive;

    void Start()
    {
        chat.SetActive(false);
        attachmentList.SetActive(false);
    }

    public void ChangeChat()
    {
        chatActive = !chatActive;
        chat.SetActive(chatActive);

        if (!chatActive) attachmentList.SetActive(false);
    }

    public void ShowAttachmentList()
    {
        //attachmentListActive = !attachmentListActive;
        attachmentList.SetActive(!attachmentList.activeSelf);
    }
}
