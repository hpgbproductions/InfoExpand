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
public class TextDisplayAdvanced : Jundroo.SimplePlanes.ModTools.Parts.PartModifier
{
    [SerializeField]
    [DesignerPropertySlider(Label = "Size X", MaxValue = 400, MinValue = 50, NumberOfSteps = 15, Order = 0)]
    private int _sizeX = 200;

    [SerializeField]
    [DesignerPropertySlider(Label = "Size Y", MaxValue = 200, MinValue = 20, NumberOfSteps = 19, Order = 10)]
    private int _sizeY = 50;

    [SerializeField]
    [DesignerPropertyLabel(Header = "String Format", Label = "data0 = {0} | data1 = {1} | data2 = {2} | data3 = {3}", Order = 100)]
    private string _text = "data0 = {0} | data1 = {1} | data2 = {2} | data3 = {3}";

    [SerializeField]
    [DesignerPropertyToggleButton("ICLIBER", "ICVCR", "ICDSEG14", "ICMONAG", "ICMONAPG", "ICPLAY", Header = "Style Options", Label = "Font", Order = 110)]
    private string _fontface = "ICLIBER";

    [SerializeField]
    [DesignerPropertyToggleButton(Label = "Font Style", Order = 120)]
    private FontStyle _fontstyle = FontStyle.Normal;

    [SerializeField]
    [DesignerPropertySlider(Label = "Font Size", MaxValue = 48, MinValue = 12, NumberOfSteps = 37, Order = 130)]
    private int _fontsize = 20;

    [SerializeField]
    [DesignerPropertySlider(Label = "Line Spacing", MaxValue = 2f, MinValue = 0.5f, NumberOfSteps = 16, Order = 140)]
    private float _linespacing = 1f;

    [SerializeField]
    [DesignerPropertyToggleButton(Header = "Paragraphing", Label = "Text Anchor", Order = 200)]
    private TextAnchor _textanchor = TextAnchor.UpperLeft;

    [SerializeField]
    [DesignerPropertyToggleButton(Label = "Best Fit", Order = 210)]
    private bool _bestfit = false;

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

    public FontStyle FontStyle
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

    public float LineSpacing
    {
        get
        {
            return _linespacing;
        }
    }

    public TextAnchor TextAnchor
    {
        get
        {
            return _textanchor;
        }
    }

    public bool BestFit
    {
        get
        {
            return _bestfit;
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
        var behaviour = partRootObject.AddComponent<TextDisplayAdvancedBehaviour>();
        return behaviour;
    }
}