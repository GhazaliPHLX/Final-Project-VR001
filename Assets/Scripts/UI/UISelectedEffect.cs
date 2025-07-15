using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GlowOnSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false; // Awalnya mati
    }

    public void OnSelect(BaseEventData eventData)
    {
        outline.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        outline.enabled = false;
    }
}
