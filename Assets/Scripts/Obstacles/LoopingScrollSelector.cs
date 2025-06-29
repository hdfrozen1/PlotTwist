using UnityEngine;
using UnityEngine.UI;

public enum ScrollType
{
    Hour,
    Minute
}

public class LoopingScrollSelector : MonoBehaviour
{
    public ScrollType scrollType = ScrollType.Hour;

    public ScrollRect scrollRect;
    public RectTransform content;
    public float snapSpeed = 10f;
    public float itemHeight;

    private int mainItemStartIndex = 1;
    private int mainItemEndIndex = 24; // default to hour

    void Start()
    {
        if (scrollType == ScrollType.Minute)
            mainItemEndIndex = 60;

        float startY = mainItemStartIndex * itemHeight;
        content.anchoredPosition = new Vector2(content.anchoredPosition.x, startY);
    }

    void Update()
    {
        float y = content.anchoredPosition.y;
        int currentIndex = Mathf.RoundToInt(y / itemHeight);

        if (currentIndex >= mainItemEndIndex + 1)
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

    public int GetSelectedValue()
    {
        float y = content.anchoredPosition.y;
        int index = Mathf.RoundToInt(y / itemHeight);

        int range = scrollType == ScrollType.Minute ? 60 : 24;
        int value = (index - 1 + range) % range;
        return value;
    }
}
