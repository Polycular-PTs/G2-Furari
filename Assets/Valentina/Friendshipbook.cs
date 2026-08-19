using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Friendshipbook : MonoBehaviour
{
    [SerializeField] private GameObject bookPuzzle;
    [SerializeField] private GameObject buttonToBook;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject infoText;
    [SerializeField] private Animator bookAnim;
    [SerializeField] private Image roomImage;
    [SerializeField] private Sprite newRoomSprite;
    public List<GameObject> pageList;

    public List<GameObject> stammbaumFields;
    public List<GameObject> fsbPhotos;

    private bool bookPickedUp = false;

    private void Start()
    {
        bookPuzzle.SetActive(false); blackScreen.SetActive(false);
    }
    public void OpenOrCloseFriendshipbook()
    {
        if (bookPickedUp)
        {

            if (bookPuzzle.activeSelf) { bookPuzzle.SetActive(false); blackScreen.SetActive(false); } else { bookPuzzle.SetActive(true); blackScreen.SetActive(true); }
        }
        else { ShowInfoText(); }
    }
    public void ShowInfoText()
    {
          bookAnim.Play("wrongbirthday");
    }

    public void WiggleStammbaum()
    {
        infoText.GetComponent<Animator>().Play("wrongbirthday");
    }

    public void PickUpFriendshipbook()
    {
        ReturnFsbValue();
        bookAnim.Play("pickupbook");
        //Destroy(buttonToBook);
        //ChangeRoomSprite();
    }

    public void TurnPage()
    {
        foreach (GameObject page in pageList)
        {
            if (page.activeSelf)
            {
                page.SetActive(false);
                if (pageList.IndexOf(page) != pageList.Count - 1) { pageList[pageList.IndexOf(page) + 1].SetActive(true); break; }
                else { pageList[0].SetActive(true); break; }
            }
        }
    }

    private bool ReturnFsbValue()
    {
        return bookPickedUp = true;
    }

    private void ChangeRoomSprite()
    {
        roomImage.sprite = newRoomSprite;
    }

}
