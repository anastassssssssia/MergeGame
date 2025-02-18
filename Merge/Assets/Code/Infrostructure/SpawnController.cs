using System.Collections;
using System.Collections.Generic;
using Code.Infrostructure;
using Code.Views;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private BubbleView _bubblePrefab;
    [SerializeField] public Transform _spawnPoint;
    [SerializeField] public GameObject _leftBorder;
    [SerializeField] public GameObject _rightBorder;
    
    [SerializeField] public MergingConfig _mergingConfig;
    [SerializeField] public ScoreController _scoreController;

    public BubbleView _currentBubble;
    public bool ActiveGameplay= true;

    private void Start()
    {
        SpawnBubble();
    }

    private void SpawnBubble()
    {
        _currentBubble = Instantiate(_bubblePrefab, _spawnPoint.position, Quaternion.identity);
        var data = _mergingConfig.GetMergingData(Random.Range(1, 3));
        _currentBubble.Setup(_leftBorder, _rightBorder, this, data.newRating, data.newSprite, _scoreController);
    }
    public void ScheduleSpawn()
    {
        StartCoroutine(SpawnBubbleWithDelay(1f));
    }

    private IEnumerator SpawnBubbleWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnBubble();
    }
}