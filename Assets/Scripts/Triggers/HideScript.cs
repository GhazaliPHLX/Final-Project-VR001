using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideScript : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI btnText;
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
    }

    public void ToggleHide()
    {
        var playerMap = playerInput.actions.FindActionMap("Player", true);
        var uiMap = playerInput.actions.FindActionMap("UI", true);

        if (player.tag == "Player")
        {
            player.tag = "Hide";
            playerMap.Disable();
            uiMap.Enable();
            btnText.text = "Out";
           
        }
        else
        {
            player.tag = "Player";
            playerMap.Enable();
            btnText.text = "Hide";

        }
    }
}
