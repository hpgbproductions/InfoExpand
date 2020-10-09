using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jundroo.SimplePlanes.ModTools.Parts;
using Jundroo.SimplePlanes.ModTools.Parts.Attributes;
using UnityEngine;
using TMPro;

/// <summary>
/// A part modifier for SimplePlanes.
/// A part modifier is responsible for attaching a part modifier behaviour script to a game object within a part's hierarchy.
/// </summary>
[Serializable]
public class TMPDisplay : Jundroo.SimplePlanes.ModTools.Parts.PartModifier
{
    [SerializeField]
    [DesignerPropertySlider(Label = "Size X", MaxValue = 5f, MinValue = 0.5f, NumberOfSteps = 19, Order = 0)]
    private float _sizeX = 2f;

    [SerializeField]
    [DesignerPropertySlider(Label = "Size Y", MaxValue = 2f, MinValue = 0.2f, NumberOfSteps = 19, Order = 10)]
    private float _sizeY = 0.5f;

    [SerializeField]
    [DesignerPropertyLabel(Header = "Text", Label = "Text", Order = 100)]
    private string _text = "New Text";

    [SerializeField]
    [DesignerPropertyToggleButton("ICLIBER", "ICVCR", "ICDSEG14", "ICMONAG", "ICMONAPG", "ICPLAY", Header = "Main Settings", Label = "Font", Order = 110)]
    private string _fontface = "ICLIBER";

    [SerializeField]
    [DesignerPropertyToggleButton(Label = "Font Style", Order = 120)]
    private FontStyles _fontstyle = FontStyles.Normal;

    [SerializeField]
    [DesignerPropertySlider(Label = "Font Size", MaxValue = 48, MinValue = 12, NumberOfSteps = 37, Order = 130)]
    private int _fontsize = 20;

    [SerializeField]
    [DesignerPropertyToggleButton(Label = "Auto Size", Order = 140)]
    private bool _autosize = false;
    /*
    [SerializeField]
    [DesignerPropertyToggleButton(Label = "Horizontal Alignment", Order = 150)]
    private HorizontalAlignmentOptions _horizontalalignment = HorizontalAlignmentOptions.Left;

    [SerializeField]
    [DesignerPropertyToggleButton(Label = "Vertical Alignment", Order = 160)]
    private VerticalAlignmentOptions _verticalalignment = VerticalAlignmentOptions.Top;
    */
    [SerializeField]
    [DesignerPropertySlider(Header = "Text Color", Label = "Red", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 300)]
    private int _color_r = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Green", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 310)]
    private int _color_g = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Blue", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 320)]
    private int _color_b = 255;

    [SerializeField]
    [DesignerPropertySlider(Label = "Alpha", MaxValue = 255, MinValue = 0, NumberOfSteps = 256, Order = 330)]
    private int _color_a = 255;

    public float SizeX
    {
        get
        {
            return _sizeX;
        }
    }

    public float SizeY
    {
        get
        {
            return _sizeY;
        }
    }

    public string Text
    {
        get
        {
            return _text;
        }
    }

    public string FontFace
    {
        get
        {
            return _fontface;
        }
    }

    public FontStyles FontStyle
    {
        get
        {
            return _fontstyle;
        }
    }

    public int FontSize
    {
        get
        {
            return _fontsize;
        }
    }

    public bool AutoSize
    {
        get
        {
            return _autosize;
        }
    }
    /*
    public HorizontalAlignmentOptions HorizontalAlignment
    {
        get
        {
            return _horizontalalignment;
        }
    }

    public VerticalAlignmentOptions VerticalAlignment
    {
        get
        {
            return _verticalalignment;
        }
    }
    */
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
        var behaviour = partRootObject.AddComponent<TMPDisplayBehaviour>();
        return behaviour;
    }
}