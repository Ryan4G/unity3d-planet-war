using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform thumb;

    private Vector2 originalPosition;
    private Vector2 originalThumbPosition;

    public Vector2 delta;


    public void OnBeginDrag(PointerEventData eventData)
    {
        thumb.gameObject.SetActive(true);

        Vector3 worldPoint = new Vector3();

        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out worldPoint
        );

        GetComponent<RectTransform>().position = worldPoint;

        thumb.localPosition = originalThumbPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint = new Vector3();

        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out worldPoint
        );

        thumb.position = worldPoint;

        var size = GetComponent<RectTransform>().rect.size;

        delta = thumb.localPosition;

        delta.x /= size.x * 0.5f;
        delta.y /= size.y * 0.5f;

        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localPosition = originalPosition;

        delta = Vector2.zero;

        thumb.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = GetComponent<RectTransform>().localPosition;

        originalThumbPosition = thumb.localPosition;

        thumb.gameObject.SetActive(false);

        delta = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
