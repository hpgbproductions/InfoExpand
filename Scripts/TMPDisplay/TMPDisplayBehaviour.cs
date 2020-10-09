using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using TMPro;

public class TMPDisplayBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour
{
    private TMPDisplay modifier;

    private RectTransform tc_rect;
    private TextMeshPro tc;

    private TMPDisplayFonts FontList;

    private GameObject ColliderObject;

    private bool InDesigner;
    private bool InLevel;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (TMPDisplay)PartModifier;

        tc_rect = GetComponentInChildren<RectTransform>();
        tc = GetComponentInChildren<TextMeshPro>();

        FontList = GetComponentInChildren<TMPDisplayFonts>();

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
            tc.text = String.Format(modifier.Text, InputController.Value);
        }
    }

    private void ApplyValues()
    {
        tc_rect.sizeDelta = new Vector2(modifier.SizeX, modifier.SizeY);
        ColliderObject.transform.localScale = new Vector3(modifier.SizeX, modifier.SizeY, 0.1f);

        tc.text = String.Format(modifier.Text, 0f);
        tc.font = FontList.SelectFont(modifier.FontFace);
        tc.fontStyle = modifier.FontStyle;
        tc.fontSize = modifier.FontSize;
        tc.enableAutoSizing = modifier.AutoSize;
        //tc.horizontalAlignment = modifier.HorizontalAlignment;
        //tc.verticalAlignment = modifier.VerticalAlignment;

        tc.color = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);
    }
}