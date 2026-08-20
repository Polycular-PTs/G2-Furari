using UnityEngine;

public class clickForBig : MonoBehaviour
{
    [SerializeField] private GameObject makeBigObj;
    public Animator animChat;

    void Start()
    {
        ResetBigObjectTransform(false);
        //animChat.Play("showChat");
    }

    public void ResetBigObjectTransform(bool bigObjEnabled)
    {
        makeBigObj.SetActive(bigObjEnabled);
        makeBigObj.transform.localScale = new Vector3(1, 1, 1);
        makeBigObj.transform.localPosition = new Vector3(0, 0, 0);
        gameObject.SetActive(!bigObjEnabled);
    }
}
