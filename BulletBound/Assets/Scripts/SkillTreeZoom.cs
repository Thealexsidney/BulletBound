using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTreeZoom : MonoBehaviour, IDragHandler, IScrollHandler
{
    public RectTransform skillTreeRooot;
    public float zoomSpeed = 0.1f;
    public float minZoom = 0.5f;
    public float maxZoom = 2f;

    private Vector2 lastMousePosition;
    private Vector2 originalScale;
    void Start()
    {
        originalScale = skillTreeRooot.localScale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        skillTreeRooot.anchoredPosition += eventData.delta;
    }

    public void OnScroll(PointerEventData eventData)
    {
        float scroll = eventData.scrollDelta.y * zoomSpeed;
        float newScale = Mathf.Clamp(skillTreeRooot.localScale.x + scroll, minZoom, maxZoom);
        skillTreeRooot.localScale = new Vector3(newScale, newScale, 1f);
    }
}
