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

    private List<TextAdditionalInputBehaviour> AdditionalInputs;

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

        CanvasText.font = FontList.SelectFont(modifier.FontFace);
        CanvasText.fontStyle = modifier.FontStyle;
        CanvasText.fontSize = modifier.FontSize;
        CanvasText.lineSpacing = modifier.LineSpacing;

        CanvasText.alignment = modifier.TextAnchor;
        CanvasText.resizeTextForBestFit = modifier.BestFit;

        CanvasText.color = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);

        if (!InDesigner && InLevel)
        {
            AdditionalInputs = new List<TextAdditionalInputBehaviour>(FindObjectsOfType<TextAdditionalInputBehaviour>());
            for (int i = 0; i < AdditionalInputs.Count; i++)
            {
                if (AdditionalInputs[i].Channel != modifier.Channel)
                {
                    AdditionalInputs.RemoveAt(i);
                }
            }

            AdditionalInputs.Sort();
        }

        ApplyFormatText();
    }

    private void ApplyFormatText()
    {
        if (InDesigner)
        {
            CanvasText.text = modifier.Text;
        }
        else if (InLevel)
        {
            List<object> InputValues = new List<object>();

            // Built-in input
            InputValues.Add(ConvertValueType(modifier.InputType, InputController.Value));
            // Additional inputs
            foreach (TextAdditionalInputBehaviour taib in AdditionalInputs)
            {
                InputValues.Add(ConvertValueType(taib.InputType, taib.Value));
            }

            object[] args = InputValues.ToArray();
            CanvasText.text = string.Format(modifier.Text, args);
        }
    }

    private object ConvertValueType(string s, float v)
    {
        if (s == "Integer")
        {
            return Mathf.RoundToInt(v);
        }
        else
        {
            return v;
        }
    }
}