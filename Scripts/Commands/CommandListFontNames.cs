using System.Collections;
using System.Collections.Generic;
using Jundroo.SimplePlanes.ModTools;
using UnityEngine;

// Dev console command that lists the names of all installed fonts.

public class CommandListFontNames : MonoBehaviour
{
    private void Awake()
    {
        ServiceProvider.Instance.DevConsole.RegisterCommand("ListFontNames", ListFontNames);
    }

    private void OnDestroy()
    {
        ServiceProvider.Instance.DevConsole.UnregisterCommand("ListFontNames");
    }

    private static void ListFontNames()
    {
        Debug.Log("Detected installed fonts: \"" + string.Join("\", \"", Font.GetOSInstalledFontNames()) + "\"");
    }
}
