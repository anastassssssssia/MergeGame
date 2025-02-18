using Code.Infrostructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Views
{
    public class BubbleView : MonoBehaviour
    {
        private Camera _mainCamera;
        private bool _isDragging = true;
        private Rigidbody2D _rigidbody;

        protected float _leftLimit = -4;
        protected float _rightLimit = 4;
        public int deathCount = 0;

        protected SpawnController _spawnController;
        protected ScoreController _scoreController;

        public int _mergedCount;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] protected MergingConfig _mergingConfig;

        public virtual void Setup(GameObject leftBorder, GameObject rightBorder, SpawnController spawnController,
            int mergedCount, Sprite sprite, ScoreController scoreController)
        {
            _leftLimit = leftBorder.transform.position.x;
            _rightLimit = rightBorder.transform.position.x;
            _spawnController = spawnController;
            _mergedCount = mergedCount;
            _spriteRenderer.sprite = sprite;
            _scoreController = scoreController;
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();

            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = Vector2.zero;
        }

        private void Update()
        {
            
            if (_isDragging)
            {
                Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                float clampedX = Mathf.Clamp(mousePosition.x, _leftLimit, _rightLimit);

                transform.position = new Vector3(clampedX, transform.position.y, 0);
                if (Input.GetMouseButtonDown(0)&&_spawnController.ActiveGameplay)
                {
                    StartFalling();
                    _spawnController.ScheduleSpawn();
                }
            }
        }

        private void StartFalling()
        {
            _isDragging = false;
            _rigidbody.gravityScale = 1;
        }

        public virtual void OnCollisionEnter2D(Collision2D collision)
        {
            BubbleView otherBubble = collision.gameObject.GetComponent<BubbleView>();
            if (otherBubble != null && otherBubble._mergedCount == _mergedCount)
            {
                MergeBubbles(otherBubble);
            }
        }

        public virtual void MergeBubbles(BubbleView otherBubble)
        {
            _scoreController.AddScore(otherBubble._mergedCount);
            
            _mergedCount += otherBubble._mergedCount;

            Sprite newSprite = _mergingConfig.GetMergingData(_mergedCount).newSprite;

            if (newSprite != null)
            {
                _spriteRenderer.sprite = newSprite;
            }

            if (otherBubble != null)
            {
                Destroy(otherBubble.gameObject);
            }
        }
    }
}