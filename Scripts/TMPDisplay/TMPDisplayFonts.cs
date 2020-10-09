using System.Collections;
using System.Collections.Generic;
using Jundroo.SimplePlanes.ModTools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// A program that takes a string input and selects a font accordingly.
// The behavior program takes the selected font and applies it to the Text component.

public class TMPDisplayFonts : MonoBehaviour
{
    [SerializeField]
    private TMP_FontAsset[] FontList;

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

    public TMP_FontAsset SelectFont(string alias)
    {
        for (int i = 0; i < FontList.Length; i++)
        {
            if (alias == AliasList[i])
            {
                return FontList[i];
            }
        }

        Debug.LogError("The selected font \"" + alias + "\" does not exist!");
        return FontList[0];
    }
}
