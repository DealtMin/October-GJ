using System;
using UnityEngine;

[RequireComponent(typeof(MonologSOViewer))]
public class StoryTrigger : MonoBehaviour
{
    [SerializeField] StoryEvent storyEvent;
    private MonologSOViewer monolog;
    void Awake()
    {
        monolog = GetComponent<MonologSOViewer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (!StoryController.StoryEvents[storyEvent])
            {
                StoryController.SetStoryEvent(storyEvent);
                DialogsController.Instance.MonologStart(monolog.monologlines);
                gameObject.SetActive(false);
            }
        }
    }
}
