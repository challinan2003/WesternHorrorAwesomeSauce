using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.VersionControl;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueItems", menuName = "Scriptable Objects/DialogueItems")]
public class DialogueItems : ScriptableObject
{
    public Object Item;
    public Object itemModel;

    
}
