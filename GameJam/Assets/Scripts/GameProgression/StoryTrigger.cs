using System;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    [SerializeField] StoryEvent storyEvent;
    [SerializeField] string dialog;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (!StoryController.StoryEvents[storyEvent])
            {
                StoryController.SetStoryEvent(storyEvent);
                Debug.Log("ЗАГЛУШКА ДИАЛОГА "+dialog);
                gameObject.SetActive(false);
            }
        }
    }
}
