using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jundroo.SimplePlanes.ModTools.Parts;
using Jundroo.SimplePlanes.ModTools.Parts.Attributes;
using UnityEngine;

/// <summary>
/// A part modifier for SimplePlanes.
/// A part modifier is responsible for attaching a part modifier behaviour script to a game object within a part's hierarchy.
/// </summary>
[Serializable]
public class Histogram : Jundroo.SimplePlanes.ModTools.Parts.PartModifier
{
    [SerializeField]
    [DesignerPropertySlider(Label = "Size X", MaxValue = 400, MinValue = 50, NumberOfSteps = 15, Order = 0)]
    private int _sizeX = 100;

    [SerializeField]
    [DesignerPropertySlider(Label = "Size Y", MaxValue = 200, MinValue = 50, NumberOfSteps = 16, Order = 10)]
    private int _sizeY = 100;

    [SerializeField]
    [DesignerPropertySlider(Header = "Line", Label = "Points", MaxValue = 200, MinValue = 50, NumberOfSteps = 16, Order = 100)]
    private int _points = 100;

    [SerializeField]
    [DesignerPropertySlider(Label = "Frame Interval", MaxValue = 20, MinValue = 1, NumberOfSteps = 20, Order = 110)]
    private int _interval = 1;

    [SerializeField]
    [DesignerPropertySlider(Label = "Thickness", MaxValue = 5f, MinValue = 0.1f, NumberOfSteps = 50, Order = 120)]
    private float _thickness = 2;

    [SerializeField]
    [DesignerPropertyToggleButton(Label = "Clamping", Order = 130)]
    private bool _clamping = true;

    [SerializeField]
    [DesignerPropertySlider(Header = "Color", Label = "Red", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 200)]
    private int _color_r = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Green", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 210)]
    private int _color_g = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Blue", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 220)]
    private int _color_b = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Alpha", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 230)]
    private int _color_a = 255;

    public int SizeX
    {
        get
        {
            return _sizeX;
        }
    }

    public int SizeY
    {
        get
        {
            return _sizeY;
        }
    }

    public int Points
    {
        get
        {
            return _points;
        }
    }

    public int Interval
    {
        get
        {
            return _interval;
        }
    }

    public float Thickness
    {
        get
        {
            return _thickness;
        }
    }

    public bool Clamping
    {
        get
        {
            return _clamping;
        }
    }

    public int ColorR
    {
        get
        {
            return _color_r;
        }
    }

    public int ColorG
    {
        get
        {
            return _color_g;
        }
    }

    public int ColorB
    {
        get
        {
            return _color_b;
        }
    }

    public int ColorA
    {
        get
        {
            return _color_a;
        }
    }

    /// <summary>
    /// Called when this part modifiers is being initialized as the part game object is being created.
    /// </summary>
    /// <param name="partRootObject">The root game object that has been created for the part.</param>
    /// <returns>The created part modifier behaviour, or <c>null</c> if it was not created.</returns>
    public override Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour Initialize(UnityEngine.GameObject partRootObject)
    {
        // Attach the behaviour to the part's root object.
        var behaviour = partRootObject.AddComponent<HistogramBehaviour>();
        return behaviour;
    }
}