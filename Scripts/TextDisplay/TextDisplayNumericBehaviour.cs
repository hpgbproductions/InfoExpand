using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayNumericBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour
{
    // Part modifier script
    private TextDisplayNumeric modifier;

    private RectTransform CanvasRect;
    private Text CanvasText;

    private TextDisplayFonts FontList;

    private GameObject ColliderObject;

    private bool InDesigner;
    private bool InLevel;

    private float NumericValue = 0f;
    private int NumericIntValue = 0;

    private string FormatType;
    private string FormatSpec;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (TextDisplayNumeric)PartModifier;

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
            NumericValue = 0;
        }
        else if (InLevel)
        {
            NumericValue = InputController.Value;
            NumericIntValue = Mathf.RoundToInt(InputController.Value);
        }

        if (modifier.FormatOption == "D" || modifier.FormatOption == "X")
        {
            CanvasText.text = NumericIntValue.ToString(FormatSpec);
        }
        else
        {
            CanvasText.text = NumericValue.ToString(FormatSpec);
        }
    }

    private void ApplyValues()
    {
        CanvasRect.sizeDelta = new Vector2Int(modifier.SizeX, modifier.SizeY);
        ColliderObject.transform.localScale = new Vector3(modifier.SizeX * 0.01f, modifier.SizeY * 0.01f, 0.1f);

        CanvasText.font = FontList.SelectFont(modifier.FontFace);
        CanvasText.fontStyle = modifier.FontStyle;
        CanvasText.fontSize = modifier.FontSize;
        CanvasText.lineSpacing = modifier.LineSpacing;

        CanvasText.alignment = modifier.TextAnchor;
        CanvasText.resizeTextForBestFit = modifier.BestFit;

        CanvasText.color = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);

        // BEGIN create the format specifier

        if (modifier.FormatLower)
        {
            FormatType = modifier.FormatOption.ToLower();
        }
        else
        {
            FormatType = modifier.FormatOption;
        }

        if (modifier.FormatPrecision < 0)
        {
            FormatSpec = FormatType;
        }
        else
        {
            FormatSpec = FormatType + modifier.FormatPrecision;
        }
    }
}