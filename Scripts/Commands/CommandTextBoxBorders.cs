using System;
using System.Collections;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.Events;
using UnityEngine;

// Debug text box hitboxes.

public class CommandTextBoxBorders : MonoBehaviour
{
    public bool DebugBordersEnabled = false;

    private void Awake()
    {
        ServiceProvider.Instance.DevConsole.RegisterCommand("DebugCanvasHitboxes", ToggleTextBoxBorders);
    }

    private void OnDestroy()
    {
        ServiceProvider.Instance.DevConsole.UnregisterCommand("DebugCanvasHitboxes");
    }

    private void ToggleTextBoxBorders()
    {
        DebugBordersEnabled = !DebugBordersEnabled;
        Debug.Log("DebugBordersEnabled set to " + (DebugBordersEnabled ? "true" : "false"));
        ApplyTextBoxBorders();
    }

    private void ApplyTextBoxBorders()
    {
        TextDisplayHitboxController[] HitboxControllers = FindObjectsOfType<TextDisplayHitboxController>();

        Debug.Log("HitboxControllers.Length = " + HitboxControllers.Length);

        if (HitboxControllers.Length == 0)
        {
            return;
        }

        for (int i = 0; i < HitboxControllers.Length; i++)
        {
            HitboxControllers[i].BorderEnabled = DebugBordersEnabled;
        }

        return;
    }
}
