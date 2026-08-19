using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;

    private Vector3 orgPosition, fsbposition;
    private Transform FSBParent, StammbaumFieldParent;

    private Friendshipbook fsbScript;

    private bool inTrigger;
    private bool inStammbaumField;
    private float scalefactor = 1.2f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        SaveFsbPosition();
        SaveFSBParent();
        ReturnFSBScript();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector3(scalefactor, scalefactor, 1f);
        SaveOrgPosition();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Vector3 mousePosition = Input.mousePosition;
        this.transform.position = mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.localScale = Vector3.one;
        transform.GetChild(0).gameObject.SetActive(true);
        if (!inTrigger)
        {
            rectTransform.localPosition = orgPosition;
        }
        else if (inTrigger)
        {
            if (inStammbaumField)
            {
                if (StammbaumFieldParent != null) { rectTransform.SetParent(StammbaumFieldParent); rectTransform.localPosition = Vector3.zero; EditText(new Vector2 (0, -70f), 18);}
                else { rectTransform.localPosition = orgPosition; }
            }
            else
            { rectTransform.SetParent(FSBParent); rectTransform.localPosition = fsbposition; EditText(new Vector2(260f, 0), 37); }
        }
        bool isFilled = StammbaumIsFull();
        if (isFilled) { bool isRight = Evaluation(); Debug.Log("You Solution is " + isRight); if (isRight) { Feedback(); RoomManager roomManager = FindFirstObjectByType<RoomManager>(); roomManager.RoomCompleted(0); } }
    }

    private void Feedback()
    {
        print("Feedback");
        Color colorFromHex;
        ColorUtility.TryParseHtmlString("C5F1CC", out colorFromHex);

        Color newColor = new Color(0.72f,1f,0.72f,1);

        foreach (var item in fsbScript.fsbPhotos)
        {
            //print(item.name);
            item.GetComponent<Image>().color = newColor;
        }
    }

    private void EditText(Vector2 position, int fontsize)
    {
        Transform child = rectTransform.GetChild(0);
        child.GetComponent<RectTransform>().anchoredPosition = position; child.GetComponent<Text>().alignment = TextAnchor.MiddleCenter; child.GetComponent<Text>().color = Color.white;
        child.GetComponent<Text>().fontSize = 18;
    }

    private Vector3 SaveOrgPosition()
    {
        return orgPosition = gameObject.GetComponent<RectTransform>().localPosition;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        ReturnInTrigger(true);

        if (fsbScript.stammbaumFields.Contains(other.gameObject) && fsbScript.fsbPhotos.Contains(gameObject))
        {
            ReturnInStammbaumField(true);

            if (other.gameObject.transform.childCount == 0)
            { ReturnStammbaumParent(other.gameObject.transform); }
            else
            { ReturnStammbaumParent(null); }
        }
        else if (other.gameObject.name == "FSBTrigger" && fsbScript.fsbPhotos.Contains(gameObject)) { ReturnInStammbaumField(false); }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (fsbScript != null)
        {
            if (fsbScript.stammbaumFields.Contains(other.gameObject) && fsbScript.fsbPhotos.Contains(gameObject)) { ReturnInTrigger(false); }
        }
        else if (other.gameObject.name == "FSBTrigger" && fsbScript.fsbPhotos.Contains(gameObject))
        {
            ReturnInTrigger(false);
        }
    }
    private Friendshipbook ReturnFSBScript()
    {
        return fsbScript = FindFirstObjectByType<Friendshipbook>();
    }
    private bool ReturnInTrigger(bool x)
    {
        return inTrigger = x;
    }
    private bool ReturnInStammbaumField(bool x)
    {
        return inStammbaumField = x;
    }
    private Vector3 SaveFsbPosition()
    {
        return fsbposition = rectTransform.localPosition;
    }
    private Transform SaveFSBParent()
    {
        return FSBParent = this.gameObject.transform.parent;
        
    }
    private Transform ReturnStammbaumParent(Transform transform)
    {
        return StammbaumFieldParent = transform;
    }

    private bool StammbaumIsFull()
    {
        foreach (GameObject field in fsbScript.stammbaumFields)
        {
            if (field.transform.childCount == 0)
            {
                return false;
            }
        }
        return true;
    }
    private bool Evaluation()
    {

        foreach (GameObject field in fsbScript.stammbaumFields)
        {
            if (field.transform.GetChild(0).name != fsbScript.fsbPhotos[fsbScript.stammbaumFields.IndexOf(field)].name)
            {
                return false;
            }
        }
        return true;
    }
}
