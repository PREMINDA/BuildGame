using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipUi : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private RectTransform bgTransform;
    public static ToolTipUi Instance;

    private void Awake()
    {
        textMeshPro = transform.Find("text").GetComponent<TextMeshProUGUI>();
        bgTransform = transform.Find("bg").GetComponent<RectTransform>();
        Hide();
        Instance = this;
    }
   

    private void Update()
    {
        transform.position = Input.mousePosition-(Vector3)new Vector2(-15,20);
    }

    private void SetText(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 padding = new Vector2(8,8);
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        bgTransform.sizeDelta = textSize+padding;
    }
    public void Show(string tooltiptext)
    {
        gameObject.SetActive(true);
        SetText(tooltiptext);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
