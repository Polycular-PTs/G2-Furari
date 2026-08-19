using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject cheatcodes;

    public void RestartGame()
    { 
        SceneManager.LoadScene("Vale");
    }

    public void ToggleCheatcodes()
    {
        cheatcodes.SetActive(!cheatcodes.activeSelf);
    }
}
