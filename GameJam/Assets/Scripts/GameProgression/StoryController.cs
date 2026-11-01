using UnityEngine;
using System;
using System.Collections.Generic;

public class StoryController : MonoBehaviour
{
    public static StoryController Instance { get; private set; }
    public static Dictionary<StoryEvent, bool> StoryEvents { get; private set; }

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
}

public enum StoryEvent
{
    FirstDialog,
    BeforeTennisDialog,
    BeforeCracksDialog,
    BedroomDialog,
    LastDialog,    
}
