using UnityEngine;

public class Attachments : MonoBehaviour
{
    [Header("Attachments")]
    [SerializeField] public GameObject[] attachmentTextObjects;
    public bool[] attachmentsFound;
    public int attachmentsSent;
    [SerializeField] CheckAndAnswer checkAndAnswer;

    [SerializeField] private GameObject nothingHereText;
    private bool anyFound;

    [SerializeField] private RoomManager roomManager;
    [SerializeField] private AudioRecManag recManager;

    public bool notTriggered = true;
    public Animator chatAnim;

    private void Start()
    {
        anyFound = false;
    }

    private void Update()
    {
        if (recManager.stuffedDone)
        {
            attachmentsFound[0] = true;
            recManager.stuffedDone = false;
        }
        if (recManager.birthdayDone) 
        {
            attachmentsFound[1] = true;
            recManager.birthdayDone = false;
        }
        if (recManager.songrecDone)
        {
            attachmentsFound[2] = true;
            recManager.songrecDone = false;
        }

        if ((attachmentsFound[0] ||
            attachmentsFound[1] ||
            attachmentsFound[2]) && notTriggered)
        {
            Debug.Log("All Found!");
            notTriggered = false;
            chatAnim.Play("showChat");

        }
    }


    public void AttachmentList()
    {
        for (int i = 0; i < attachmentsFound.Length; i++)
        {
            if (attachmentsFound[i] && attachmentTextObjects[i] != null)
            {
                attachmentTextObjects[i].SetActive(true);
                anyFound = true;
            }
        }

        nothingHereText.SetActive(!anyFound);
    }

    public void AttachmentAnswer()
    {
        Debug.Log("hallo");
        if (attachmentsSent == attachmentsFound.Length - 1)
        {
            checkAndAnswer.Answer(5);
            roomManager.RoomCompletion[4] = true;
        }
        else
        {
            attachmentsSent ++;
            checkAndAnswer.Answer(4);
        }
    }
}
