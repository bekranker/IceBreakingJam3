using System;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "DialogueSo", menuName = "Scriptable Objects/DialogueSo")]
public class DialogueSo : ScriptableObject
{
  public VideoClip DialogueVideo;
  public DialogueOption FirstOption;
  public DialogueOption SecondOption;
}

[Serializable]
public class DialogueOption
{
  public string DialogueText;
  public int BalanceChange;
  public VideoClip NextCutscene;
}
