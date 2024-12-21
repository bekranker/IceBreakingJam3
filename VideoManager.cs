using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    List<DialogueSo> dialogueSos = new List<DialogueSo>();

    [SerializeField] VideoPlayer videoPlayer;

    bool isVideoPlaying;
    bool isCutScenePlaying;

    [SerializeField] TextMeshProUGUI _firstDialogueText;
    [SerializeField] TextMeshProUGUI _secondDialogueText;

    DialogueSo _currentDialogue;

    int _balanceMeter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartNextDialogue();
    }

    void OnEnable()
    {
        ButtonEventTrigger.OnButtonClicked += OnDialogueSelected;
    }

    void OnDisable()
    {
        ButtonEventTrigger.OnButtonClicked -= OnDialogueSelected;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVideoPlaying && !videoPlayer.isPlaying)
        {
            ShowDialogueSelection();
        }

        if (isCutScenePlaying && !videoPlayer.isPlaying)
        {
            StartNextDialogue();
        }
    }

    void StartNextDialogue()
    {
        _currentDialogue = dialogueSos[0];
        dialogueSos.Remove(_currentDialogue);

        videoPlayer.clip = _currentDialogue.DialogueVideo;
        videoPlayer.Play();
        isVideoPlaying = true;
    }

    void ShowDialogueSelection()
    {
        isVideoPlaying = false;

        _firstDialogueText.text = _currentDialogue.FirstOption.DialogueText;
        _secondDialogueText.text = _currentDialogue.SecondOption.DialogueText;

        _firstDialogueText.transform.parent.gameObject.SetActive(true);
        _secondDialogueText.transform.parent.gameObject.SetActive(true);
    }

    void OnDialogueSelected(int index)
    {
        _firstDialogueText.transform.parent.gameObject.SetActive(false);
        _secondDialogueText.transform.parent.gameObject.SetActive(false);

        if (index == 1)
        {
            _balanceMeter += _currentDialogue.FirstOption.BalanceChange;
            PlayCutScene(_currentDialogue.FirstOption.NextCutscene);
        }
        else
        {
            _balanceMeter += _currentDialogue.SecondOption.BalanceChange;
            PlayCutScene(_currentDialogue.SecondOption.NextCutscene);
        }
    }

    void PlayCutScene(VideoClip videoClip)
    {
        isCutScenePlaying = true;
        videoPlayer.clip = videoClip;
    }
}
