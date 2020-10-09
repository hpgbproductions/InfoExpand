using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayFixedBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour
{
    // Part modifier script
    private TextDisplayFixed modifier;

    private Canvas Canvas;
    private RectTransform CanvasRect;
    private Text CanvasText;

    private TextDisplayFonts FontList;

    private GameObject ColliderObject;

    private bool InDesigner;
    private bool InLevel;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (TextDisplayFixed)PartModifier;

        Canvas = GetComponentInChildren<Canvas>();
        CanvasRect = GetComponentInChildren<RectTransform>();
        CanvasText = GetComponentInChildren<Text>();

        FontList = GetComponentInChildren<TextDisplayFonts>();

        ColliderObject = GetComponentInChildren<BoxCollider>().gameObject;

        ApplyValues();
    }

    private void Update()
    {
        if (InDesigner)
        {
            ApplyValues();
        }
        else if (InLevel)
        {
            ApplyFormatText();
        }
    }

    private void ApplyValues()
    {
        CanvasRect.sizeDelta = new Vector2Int(modifier.SizeX, modifier.SizeY);
        ColliderObject.transform.localScale = new Vector3(modifier.SizeX * 0.01f, modifier.SizeY * 0.01f, 0.1f);

        Canvas.sortingOrder = modifier.SortOrder;

        ApplyFormatText();

        CanvasText.font = FontList.SelectFont(modifier.FontFace);
        CanvasText.fontStyle = modifier.FontStyle;
        CanvasText.fontSize = modifier.FontSize;
        CanvasText.lineSpacing = modifier.LineSpacing;

        CanvasText.alignment = modifier.TextAnchor;
        CanvasText.resizeTextForBestFit = modifier.BestFit;

        CanvasText.color = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);
    }

    private void ApplyFormatText()
    {
        if (InDesigner)
        {
            if (modifier.InputType == "Float")
            {
                CanvasText.text = String.Format(modifier.Text, 0f);
            }
            else if (modifier.InputType == "Integer")
            {
                CanvasText.text = String.Format(modifier.Text, 0);
            }
        }
        else if (InLevel)
        {
            if (modifier.InputType == "Float")
            {
                CanvasText.text = String.Format(modifier.Text, InputController.Value);
            }
            else if (modifier.InputType == "Integer")
            {
                CanvasText.text = String.Format(modifier.Text, Mathf.RoundToInt(InputController.Value));
            }
        }
    }
}