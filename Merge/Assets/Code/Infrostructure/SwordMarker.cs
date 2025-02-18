using Code.Infrostructure;
using Code.Views;
using UnityEngine;

public class SwordMarker : MonoBehaviour
{
    [SerializeField]
    private ScoreController _scoreController;
    public void OnTriggerEnter2D(Collider2D other)
    {
        BubbleView otherBubble = other.gameObject.GetComponent<BubbleView>();
        if (otherBubble != null)
        {
            _scoreController.AddScore(otherBubble._mergedCount);
            Destroy(otherBubble.gameObject);
        }
    }
}
