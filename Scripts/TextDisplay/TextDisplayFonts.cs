using System.Collections;
using System.Collections.Generic;
using Jundroo.SimplePlanes.ModTools;
using UnityEngine;
using UnityEngine.UI;

// A program that takes a string input and selects a font accordingly.
// The behavior program takes the selected font and applies it to the Text component.

public class TextDisplayFonts : MonoBehaviour
{
    [SerializeField]
    private Font[] FontList;

    [SerializeField]
    private string[] AliasList;

    private void Start()
    {
        if (FontList.Length != AliasList.Length | FontList.Length == 0 | AliasList.Length == 0)
        {
            Debug.LogError("The lengths of FontList and AliasList are not equal, or either length is zero.");
            return;
        }
    }

    public Font SelectFont(string alias)
    {
        for (int i = 0; i < FontList.Length; i++)
        {
            if (alias == AliasList[i])
            {
                return FontList[i];
            }
        }

        return Font.CreateDynamicFontFromOSFont(alias, 16);
    }
}
