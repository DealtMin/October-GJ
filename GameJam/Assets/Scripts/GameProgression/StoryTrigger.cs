using System;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    [SerializeField] StoryEvent storyEvent;
    [SerializeField] string dialog;
    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            if (!StoryController.StoryEvents[storyEvent])
            {
                StoryController.SetStoryEvent(storyEvent);
                player.StartDialog();
                gameObject.SetActive(false);
            }
        }
    }
}
