using UnityEngine;
using UnityEngine.UI;

public class StringAbgleicher : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private string correctWord;
    public bool useEasyMode = true;

    public Animator anim;

    public void InputSent()
    {
        if (inputField.text == correctWord)
        {
            RoomManager roomManager = FindFirstObjectByType<RoomManager>();
            roomManager.RoomCompleted(1);
            anim.gameObject.SetActive(false);
        }
        else
        {
            if (useEasyMode)
            {
                if (Menu.easyMode)
                {
                    anim.Play("wrongbirthday");
                }
            }
            
        }
    }

}
