using System;
using Code.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<BubbleView>(out BubbleView bubbleView))
        {
            bubbleView.deathCount++;
            if (bubbleView.deathCount >= 2)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
