using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    Stack<DialogueSo> dialogueSos = new Stack<DialogueSo>();

    [SerializeField] VideoPlayer videoPlayer;

    bool isVideoPlaying;

    [SerializeField] TextMeshProUGUI _firstDialogueText;
    [SerializeField] TextMeshProUGUI _secondDialogueText;

    DialogueSo _currentDialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartNextDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVideoPlaying && !videoPlayer.isPlaying)
        {
            ShowDialogueSelection();
        }
    }

    void StartNextDialogue()
    {
        _currentDialogue = dialogueSos.Pop();

        videoPlayer.clip = _currentDialogue.DialogueVideo;
        videoPlayer.Play();
        isVideoPlaying = true;
    }

    void ShowDialogueSelection()
    {
        _firstDialogueText.text = _currentDialogue.FirstOption.DialogueText;
        _secondDialogueText.text = _currentDialogue.SecondOption.DialogueText;

        _firstDialogueText.transform.parent.gameObject.SetActive(true);
        _secondDialogueText.transform.parent.gameObject.SetActive(true);
    }

    void OnDialogueSelected(int index)
    {

    }
}
