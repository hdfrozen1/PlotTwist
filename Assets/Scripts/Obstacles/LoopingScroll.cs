using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoopingScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public float snapSpeed = 10f;

    public float itemHeight;
    private int mainItemStartIndex = 1;
    private int mainItemEndIndex = 24;
    private bool isSnapping = false;

    void Start()
    {
        //itemHeight = content.GetChild(0).GetComponent<RectTransform>().rect.height;
        float startY = mainItemStartIndex * itemHeight;
        content.anchoredPosition = new Vector2(content.anchoredPosition.x, startY);
    }

    void Update()
    {
        // Cuộn vòng
        float y = content.anchoredPosition.y;
        int currentIndex = Mathf.RoundToInt(y / itemHeight);

        if (currentIndex >= 25)
        {
            float newY = itemHeight * mainItemStartIndex;
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, newY);
        }
        else if (currentIndex <= 0)
        {
            float newY = itemHeight * mainItemEndIndex;
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, newY);
        }
    }


    public int GetSelectedHour()
    {
        float y = content.anchoredPosition.y;
        int index = Mathf.RoundToInt(y / itemHeight);
        int hour = (index - 1 + 24) % 24;
        return hour;
    }
}

