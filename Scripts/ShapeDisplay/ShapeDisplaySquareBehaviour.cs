using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShapeDisplaySquareBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour
{
    // Part modifier script
    private ShapeDisplaySquare modifier;

    private Canvas canvas;
    private Image square;

    private bool InDesigner;
    private bool InLevel;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (ShapeDisplaySquare)PartModifier;

        canvas = GetComponentInChildren<Canvas>();
        square = GetComponentInChildren<Image>();

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
            square.fillAmount = Mathf.Abs(InputController.Value);
        }
    }

    private void ApplyValues()
    {
        square.color = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);

        canvas.sortingOrder = modifier.SortOrder;
    }
}