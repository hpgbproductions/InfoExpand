using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplayHitboxController : MonoBehaviour
{
    public bool BorderEnabled = false;

    private MeshRenderer Border;
    private CommandTextBoxBorders BorderCommand;

    private void Start()
    {
        Border = GetComponent<MeshRenderer>();

        BorderCommand = FindObjectOfType<CommandTextBoxBorders>();
        BorderEnabled = BorderCommand.DebugBordersEnabled;
    }

    private void Update()
    {
        Border.enabled = BorderEnabled;
    }
}
