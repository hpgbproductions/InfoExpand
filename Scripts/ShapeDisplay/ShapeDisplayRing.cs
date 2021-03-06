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
public class ShapeDisplayRing : Jundroo.SimplePlanes.ModTools.Parts.PartModifier
{
    [SerializeField]
    [DesignerPropertySlider(Label = "Inner Radius", MaxValue = 0.99f, MinValue = 0.75f, NumberOfSteps = 25, Order = 10)]
    private float _inradius = 0.8f;

    [SerializeField]
    [DesignerPropertySlider(Label = "Sorting Order", MaxValue = 9, MinValue = 0, NumberOfSteps = 10, Order = 20)]
    private int _sortorder = 0;

    [SerializeField]
    [DesignerPropertySlider(Label = "Red", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 100)]
    private int _color_r = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Green", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 110)]
    private int _color_g = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Blue", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 120)]
    private int _color_b = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Alpha", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 130)]
    private int _color_a = 255;

    public float InRadius
    {
        get
        {
            return _inradius;
        }
    }

    public int SortOrder
    {
        get
        {
            return _sortorder;
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
        var behaviour = partRootObject.AddComponent<ShapeDisplayRingBehaviour>();
        return behaviour;
    }
}