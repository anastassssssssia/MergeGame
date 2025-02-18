using Code.Infrostructure;
using Code.Views;
using UnityEngine;

public class UniversalBubble : BubbleView
{
    public override void MergeBubbles(BubbleView otherBubble)
    {
        _mergedCount = otherBubble._mergedCount;
        otherBubble.MergeBubbles(this);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        BubbleView otherBubble = collision.gameObject.GetComponent<BubbleView>();
        if (otherBubble != null)
        {
            MergeBubbles(otherBubble);
        }
    }

    public override void Setup(GameObject leftBorder, GameObject rightBorder, SpawnController spawnController, int mergedCount,
        Sprite sprite, ScoreController scoreController)
    {
        _leftLimit = leftBorder.transform.position.x;
        _rightLimit = rightBorder.transform.position.x;
        _spawnController = spawnController;
        _mergedCount = mergedCount;
        _scoreController = scoreController;
    }
}

