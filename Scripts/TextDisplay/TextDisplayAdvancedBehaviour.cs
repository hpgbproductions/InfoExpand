using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.SimplePlanesReflection.Assets.Scripts.Parts;
using Jundroo.SimplePlanes.ModTools;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayAdvancedBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour
{
    // Part modifier script
    private TextDisplayAdvanced modifier;

    private RectTransform CanvasRect;
    private Text CanvasText;

    private TextDisplayFonts FontList;

    private GameObject ColliderObject;

    private bool InDesigner;
    private bool InLevel;

    private float data0 = 0f;
    private float data1 = 0f;
    private float data2 = 0f;
    private float data3 = 0f;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (TextDisplayAdvanced)PartModifier;

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
            data0 = 0;
            data1 = 0;
            data2 = 0;
            data3 = 0;
        }
        else if (InLevel)
        {
            data0 = InputController.Value;
            data1 = InputController.Value;
            data2 = InputController.Value;
            data3 = InputController.Value;

            CanvasText.text = String.Format(modifier.Text, data0, data1, data2, data3);
        }
    }

    private void ApplyValues()
    {
        CanvasRect.sizeDelta = new Vector2Int(modifier.SizeX, modifier.SizeY);
        ColliderObject.transform.localScale = new Vector3(modifier.SizeX * 0.01f, modifier.SizeY * 0.01f, 0.1f);

        CanvasText.text = modifier.Text;
        CanvasText.font = FontList.SelectFont(modifier.FontFace);
        CanvasText.fontStyle = modifier.FontStyle;
        CanvasText.fontSize = modifier.FontSize;
        CanvasText.lineSpacing = modifier.LineSpacing;

        CanvasText.alignment = modifier.TextAnchor;
        CanvasText.resizeTextForBestFit = modifier.BestFit;

        CanvasText.color = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);
    }
}