using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public static StoryController Instance { get; private set; }
    public static Dictionary<StoryEvent, bool> StoryEvents { get; private set; }
    public static Action ItemCollected;
    [SerializeField] private GameObject coridor;
    [SerializeField] private GameObject coridorWall;
    [SerializeField] private MonologSO finalmonolog;
    [SerializeField] private MonologSO bedroommonolog;
    [SerializeField] private GameObject particles1;
    [SerializeField] private GameObject particles2;

    [SerializeField] private AudioClip horrorTheme;
    IAudioService _audioService;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        StoryEvents = new Dictionary<StoryEvent, bool>();

        foreach (StoryEvent evt in Enum.GetValues(typeof(StoryEvent)))
        {
            StoryEvents[evt] = false;
        }
        ItemCollected += CheckCount;
        _audioService = ServiceLocator.Get<IAudioService>();
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public static void SetStoryEvent(StoryEvent storyEvent)
    {
        StoryEvents[storyEvent] = true;
    }

    private void CheckCount()
    {
        int count = CollectableController.CollectedCount();
        Debug.Log("collected "+count);
        if (count == (int)StoryEvent.BedroomDialog)
        {
            BedroomDialog();
        }
        if (count == (int)StoryEvent.LastDialog)
        {
            LastDialog();
        }        
    }

    private void LastDialog()
    {
        DialogsController.Instance.MonologStart(finalmonolog.monologlines);
        DialogsController.Instance.dialogEnds += NextScene;
    }

    void OnDisable()
    {
        DialogsController.Instance.dialogEnds -= NextScene;
    }

    void NextScene()
    {
        SceneManager.LoadScene("FinalScene");
        Invoke("NextScene", 10f);        
    }
    
    private void BedroomDialog()
    {
        //DialogsController.Instance.MonologStart(bedroommonolog.monologlines);
        coridor.SetActive(true);
        coridorWall.SetActive(false);
        _audioService.PlayMusic(horrorTheme);
        particles1.SetActive(true);
        particles2.SetActive(false);
    }
}

public enum StoryEvent
{
    FirstDialog,
    BeforeTennisDialog,
    BeforeCracksDialog,
    BedroomDialog = 6,
    LastDialog = 1,    
}

