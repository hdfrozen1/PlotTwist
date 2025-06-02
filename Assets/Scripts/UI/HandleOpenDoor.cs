using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleOpenDoor : MonoBehaviour
{
    public float minScaleY;
    public float maxScaleY;

    public Vector3 scaleVector;
    void Start()
    {
        minScaleY = 0;
        maxScaleY = 2.3f;
    }
    public void ChangeScale()
    {
        transform.localScale -= scaleVector;
        transform.position += scaleVector / 2;

    }

    public IEnumerator OpenTheDoor()
    {
        while (transform.localScale.y > 0)
        {
            ChangeScale();
            yield return new WaitForSeconds(0.2f);
        }

    }
    public void BeginOpenDoor(){
        StartCoroutine(OpenTheDoor());
    }
}
