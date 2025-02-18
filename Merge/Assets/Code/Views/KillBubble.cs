using Code.Infrostructure;
using UnityEngine;

namespace Code.Views
{
    public class KillBubble: BubbleView
    {
        private int killBubbleCounter = 0;
        public override void MergeBubbles(BubbleView otherBubble)
        {
            _scoreController.AddScore(otherBubble._mergedCount);
            Destroy(otherBubble.gameObject);
            killBubbleCounter++;
            if (killBubbleCounter >= 3)
            {
                Destroy(gameObject);
            }
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
}