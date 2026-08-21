using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontManager : MonoBehaviour
{
    public Font standardFont;
    public TMP_FontAsset font;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       var x = Resources.FindObjectsOfTypeAll<Text>(); //GameObject.FindObjectsOfTypeAll(typeof(Text));

        foreach (var item in x)
        {
            item.font = standardFont;
        }

        var y = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>(); //GameObject.FindObjectsOfTypeAll(typeof(Text));

        foreach (var item in y)
        {
            item.font = font;
        }
    }


}
