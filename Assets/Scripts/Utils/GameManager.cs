using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public HandleOpenDoor handleOpenDoor;
    public OpenDoorButton openDoorButton;
    public GameObject nextLevelCollider;

    [Header("Move Buttons")]
    public HandleMoveButton moveRightButton;
    public HandleMoveButton moveLeftButton;
    public HandleMoveButton jumpButton;
    [Header("Gravity")]
    public Vector2 gravityDirection;
    public int level = 2; // bạn có thể thay đổi số này

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        openDoorButton = GameObject.FindObjectOfType<OpenDoorButton>();
        handleOpenDoor = GameObject.FindObjectOfType<HandleOpenDoor>();
    }
    public void SetUpLevel1()
    {
        Debug.Log("set up level 1");
    }
    public void SetUpLevel2()
    {
        //openDoorButton.buttonClickedCount = 4;
    }
    public void SetUpLevel3()
    {
        playerController.tag_name = "Untagged";
        playerController.ChangeTag();
    }
    public void SetUpLevel4()
    {
        //change position of nextLevelCollider
    }
    public void SetUpLevel5()
    {
        //chang tag of player to "Soul"
        // and change tag of soul to player
    }
    public void SetUpLevel6(){
        //change position and scale of door to open state
    }
    public void SetUpLevel7(){
        // set gravity lower
    }
    public void SetUpLevel8(){
        moveRightButton.isJumpButton = true;
        moveLeftButton.isLeftButton = false;
        jumpButton.isJumpButton = false;
        jumpButton.isLeftButton = true;
    }
    public void SetUpLevel9(){
        Physics2D.gravity = gravityDirection;
    }
    public void SetUpLevel10(){
        // press jump button and gravity will * (-1)
        jumpButton.changeJump -= playerController.SetJump;
        jumpButton.changeJump += ChangeGravityDirection;
    }
    public void SetUpLevel11()
    {
        
    }
    private void ChangeGravityDirection(bool value)
    {
        gravityDirection = gravityDirection * -1;
        Physics2D.gravity = gravityDirection;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            string methodName = $"SetUpLevel{level}";
            MethodInfo method = typeof(GameManager).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

            if (method != null)
            {
                method.Invoke(this, null); // Gọi hàm
            }
            else
            {
                Debug.Log("ko tim thay ham");
            }
        }

    }
}
