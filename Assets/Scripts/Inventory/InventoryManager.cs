using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance {get ; private set;}

    public GameObject playerInventoryUI;

    void awake()
    {
        if (instance == null){instance = this;}
        else{Destroy(gameObject);}
    }
    void update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerInventoryUI.SetActive(!playerInventoryUI.activeSelf);

            if (playerInventoryUI.activeSelf)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                //Player.Instance.freeze = true;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
                //  Player.Instance.freeze = false;
            }
        }
    }
}
