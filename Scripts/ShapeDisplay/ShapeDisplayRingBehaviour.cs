using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShapeDisplayRingBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour
{
    // Part modifier script
    private ShapeDisplayRing modifier;

    private Canvas canvas;
    private GameObject canvas_o;
    private RectTransform mask_rect;

    private GameObject bg;
    private Image bg_circle;

    private bool InDesigner;
    private bool InLevel;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (ShapeDisplayRing)PartModifier;

        canvas = GetComponentInChildren<Canvas>();
        canvas_o = canvas.gameObject;
        mask_rect = canvas_o.GetComponent<RectTransform>();

        bg = canvas_o.transform.Find("Back").gameObject;
        bg_circle = bg.GetComponent<Image>();

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
            bg_circle.fillAmount = Mathf.Abs(InputController.Value);
            bg_circle.fillClockwise = InputController.Value >= 0f;
        }
    }

    private void ApplyValues()
    {
        canvas.sortingOrder = modifier.SortOrder;

        mask_rect.sizeDelta = new Vector2(modifier.InRadius * 256, modifier.InRadius * 256);

        bg_circle.color = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);
    }
}