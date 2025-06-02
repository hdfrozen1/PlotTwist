using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    
    public Text text;
    private Camera mainCamera;
    private Vector3 offset;
    private bool isDragging = false;
    private Rigidbody2D rb;
    public new Collider2D collider2D;
    public PartID partID;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.gravityScale = 0; // Nếu không muốn bị rơi
            //text.text = "call from location";
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        Vector3 worldTouch = mainCamera.ScreenToWorldPoint(eventData.position);
        offset = transform.position - new Vector3(worldTouch.x, worldTouch.y, transform.position.z);
        Debug.Log(partID.ToString());
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;


        Vector3 worldTouch = mainCamera.ScreenToWorldPoint(eventData.position);
        Vector3 targetPos = new Vector3(worldTouch.x, worldTouch.y, transform.position.z) + offset;
        if (rb != null && collider2D.isTrigger == false)
        {
            rb.MovePosition(targetPos); // Sử dụng vật lý để di chuyển
        }
        else
        {
            transform.position = targetPos;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("ontrigger");
        if (collision.transform.name == partID.ToString())
        {
            if (Vector3.Distance(transform.position, collision.transform.position) <= 0.2f)
            {
                transform.position = collision.transform.position;
                collision.gameObject.SetActive(false);
                this.enabled = false;
            }
        }
    }

}
public enum PartID
{
    Head,
    Body,
    ArmLeft,
    ArmRight,
    LegLeft,
    LegRight
}
