using System.Collections;
using Code.Infrostructure;
using Code.Views;
using UnityEngine;

public class SkillsController : MonoBehaviour
{
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private KillBubble _killBubble;
    [SerializeField] private UniversalBubble _universalBubble;
    [SerializeField] private SwordMarker _swordMarker;

    public void UseSkill(SpecialSkill skill)
    {
        switch (skill)
        {
            case SpecialSkill.Knife:
                UseKnife();
                break;
            case SpecialSkill.Sword:
                UseSword();
                break;
            case SpecialSkill.Potion:
                UsePotion();
                break;
            case SpecialSkill.Axe:
                UseAxe();
                break;
        }
    }

    private bool _isWaitingForClick = false;

    public void UseKnife()
    {
        _spawnController.ActiveGameplay = false;
        _isWaitingForClick = true;
    }

    private void Update()
    {
        if (_isWaitingForClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.TryGetComponent(out BubbleView bubbleView))
                {
                    Destroy(hit.collider.gameObject);
                    _spawnController.ActiveGameplay = true;
                    _isWaitingForClick = false;
                }
            }
        }
    }

    private void UseSword()
    {
        StartCoroutine(WaitingForSword());
    }

    private void UsePotion()
    {
        StartCoroutine(WaitingForPotion());
    }

    private void UseAxe()
    {
        StartCoroutine(WaitingForAxe());
    }

    private IEnumerator WaitingForAxe()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(_spawnController._currentBubble.gameObject);
        _spawnController._currentBubble = Instantiate(_killBubble, _spawnController._spawnPoint.transform.position,
            Quaternion.identity);
        _spawnController._currentBubble.Setup(_spawnController._leftBorder, _spawnController._rightBorder,
            _spawnController, 0, null, _spawnController._scoreController);
    }
    private IEnumerator WaitingForPotion()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(_spawnController._currentBubble.gameObject);
        _spawnController._currentBubble = Instantiate(_universalBubble, _spawnController._spawnPoint.transform.position,
            Quaternion.identity);
        _spawnController._currentBubble.Setup(_spawnController._leftBorder, _spawnController._rightBorder,
            _spawnController, 0, null, _spawnController._scoreController);
    }
    private IEnumerator WaitingForSword()
    {
        _swordMarker.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _swordMarker.gameObject.SetActive(false);
    }
}