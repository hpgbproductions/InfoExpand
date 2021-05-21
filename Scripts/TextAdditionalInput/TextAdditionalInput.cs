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
public class TextAdditionalInput : Jundroo.SimplePlanes.ModTools.Parts.PartModifier
{
    [SerializeField]
    [DesignerPropertySlider(Label = "Channel", MaxValue = 15, MinValue = 0, NumberOfSteps = 16, Order = 0)]
    private int _channel = 0;

    [SerializeField]
    [DesignerPropertySlider(Label = "Format Order", MaxValue = 15, MinValue = 0, NumberOfSteps = 16, Order = 10)]
    private int _order = 0;

    [SerializeField]
    [DesignerPropertyToggleButton("Float", "Integer", Label = "Input Type", Order = 20)]
    private string _inputtype = "Float";

    public int Channel
    {
        get
        {
            return _channel;
        }
    }

    public int Order
    {
        get
        {
            return _order;
        }
    }

    public string InputType
    {
        get
        {
            return _inputtype;
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
        var behaviour = partRootObject.AddComponent<TextAdditionalInputBehaviour>();
        return behaviour;
    }
}