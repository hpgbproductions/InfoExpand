using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TextAdditionalInputBehaviour : Jundroo.SimplePlanes.ModTools.Parts.PartModifierBehaviour, IComparer<TextAdditionalInputBehaviour>
{
    TextAdditionalInput modifier;

    public int Channel = 0;
    public int Order = 0;
    public string InputType = "Float";

    public float Value = 0;

    private bool InDesigner;
    private bool InLevel;

    private void Start()
    {
        InDesigner = ServiceProvider.Instance.GameState.IsInDesigner;
        InLevel = ServiceProvider.Instance.GameState.IsInLevel;

        modifier = (TextAdditionalInput)PartModifier;

        Channel = modifier.Channel;
        Order = modifier.Order;
        InputType = modifier.InputType;
    }

    private void Update()
    {
        if (!InDesigner && InLevel)
        {
            Value = InputController.Value;
        }
    }

    public int Compare(TextAdditionalInputBehaviour x, TextAdditionalInputBehaviour y)
    {
        return x.Order - y.Order;
    }
}