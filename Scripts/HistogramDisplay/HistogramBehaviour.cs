using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HistogramBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour
{
    // Part modifier script
    private Histogram modifier;

    private LineRenderer LineRenderer;
    private GameObject ColliderObject;

    private float[] HistogramValues;
    private int HistogramCount = 2;
    private int PreviousCount = 0;

    private int FrameInterval = 1;
    private int FrameCounter = 1;

    private float PosRight;
    private float PosInter;

    private bool InDesigner;
    private bool InLevel;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (Histogram)PartModifier;

        LineRenderer = GetComponentInChildren<LineRenderer>();
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
            if (ServiceProvider.Instance.GameState.IsPaused || !InputController.Active)
            {
                return;
            }

            FrameCounter--;
            if (FrameCounter <= 0)
            {
                // Shift by one index
                for (int i = HistogramCount - 2; i >= 0; i--)
                {
                    HistogramValues[i + 1] = HistogramValues[i];
                }
                HistogramValues[0] = InputController.Value;
                ApplyLine();

                FrameCounter = FrameInterval;
            }
        }
    }

    private void ApplyLine()
    {
        float absheight = modifier.SizeY * 0.005f;

        for (int i = 0; i < HistogramCount; i++)
        {
            float xpos = PosRight - PosInter * i;
            float ypos = HistogramValues[i] * absheight;
            
            if (modifier.Clamping)
            {
                ypos = Mathf.Clamp(ypos, -absheight, absheight);
            }

            LineRenderer.SetPosition(i, new Vector3(xpos, ypos, 0f));
        }
    }

    private void ApplyValues()
    {
        ColliderObject.transform.localScale = new Vector3(modifier.SizeX * 0.01f, modifier.SizeY * 0.01f, 0.1f);

        HistogramCount = Math.Max(modifier.Points, 2);

        // Because HistogramCount > 2 and default PreviousCount = 0,
        // this will always run on the first ApplyValues call
        if (HistogramCount != PreviousCount)
        {
            HistogramValues = new float[HistogramCount];
            for (int i = 0; i < HistogramCount; i++)
            {
                HistogramValues[i] = 0;
            }
            PreviousCount = HistogramCount;
        }

        FrameInterval = Math.Max(modifier.Interval, 1);
        FrameCounter = FrameInterval;

        PosRight = modifier.SizeX * 0.005f;
        PosInter = modifier.SizeX * 0.01f / (HistogramCount - 1);

        LineRenderer.startWidth = modifier.Thickness * 0.01f;
        LineRenderer.endWidth = modifier.Thickness * 0.01f;

        LineRenderer.startColor = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);
        LineRenderer.endColor = new Color(modifier.ColorR / 255f, modifier.ColorG / 255f, modifier.ColorB / 255f, modifier.ColorA / 255f);

        // Set up and apply default line
        LineRenderer.positionCount = HistogramCount;
        ApplyLine();
    }
}