using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject cheatcodes;

    public Button[] buttons;
    public Color[] baseHighlightColor;
    public Toggle toggle;
    public static bool easyMode = true;

    private void Start()
    {
        baseHighlightColor = new Color[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            baseHighlightColor[i] = buttons[i].colors.highlightedColor;
        }
    }

    public void ToggleEasyMode()
    {
        if (toggle.isOn)
        {
            easyMode = true;


            for (int i = 0; i < buttons.Length; i++)
            {
                ColorBlock colors = buttons[i].colors;
                colors.highlightedColor = baseHighlightColor[i];
                buttons[i].colors = colors;

            }
        }
        else
        {
            easyMode = false;

            for (int i = 0; i < buttons.Length; i++)
            {
                ColorBlock colors = buttons[i].colors;
                colors.highlightedColor = colors.normalColor;
                buttons[i].colors = colors;
            }
        }
    }



    public void RestartGame()
    { 
        SceneManager.LoadScene("Vale");
    }

    public void ToggleCheatcodes()
    {
        cheatcodes.SetActive(!cheatcodes.activeSelf);
    }


    public void WiggleInEasyMode(Animator anim)
    {
        if (easyMode)
        {
            anim.Play("wrongbirthday");
        }
    }
}
