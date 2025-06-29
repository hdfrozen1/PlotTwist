using UnityEngine;

public class MirrorCloneFade : MonoBehaviour
{
    public Transform player; // gán reference nhân vật chính
    public SpriteRenderer cloneRenderer;
    
    [Tooltip("Khoảng cách tối đa để bắt đầu làm mờ")]
    public float fadeDistance = 5f;

    private void Update()
    {
        float distanceToMirror = Mathf.Abs(player.position.x); // mirror ở x = 0
        float alpha = Mathf.Clamp01(1f - distanceToMirror / fadeDistance);

        Color color = cloneRenderer.color;
        color.a = alpha;
        cloneRenderer.color = color;
    }
}
