using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround : MonoBehaviour
{
    public LayerMask groundLayer;
    public string tag_name;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireCube(transform.position, new Vector3(0.86f,0.1f,1));
    }
}
