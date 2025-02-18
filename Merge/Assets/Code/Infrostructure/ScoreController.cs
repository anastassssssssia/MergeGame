using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace Code.Infrostructure
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _coinsText;

        private int _score;
        private int _coins;

        public void AddScore(int score)
        {
            _score += score;
            _scoreText.text = _score.ToString();
            _coins += score;
            _coinsText.text = _coins.ToString();
            if (score >= 2048)
            {
                SceneManager.LoadScene(1);
            }
        }

        public bool RemoveCoins(int coins)
        {
            if (_coins <= coins)
            {
                return false;
            }

            _coins -= coins;
            _coinsText.text = _coins.ToString();
            return true;
        }
    }
}