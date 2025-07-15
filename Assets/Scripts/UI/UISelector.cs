using UnityEngine;
using UnityEngine.EventSystems;

public class UISelector : MonoBehaviour
{
    public GameObject firstSelected;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}