using Code.Infrostructure;
using Code.Views;
using TMPro;
using UnityEngine;

public class StoreItemView : MonoBehaviour
{
    [SerializeField]
    private SpecialSkill _specialSkill;
    [SerializeField] 
    private SpecialSkillView _specialSkillView;

    [SerializeField] private int _price;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private ScoreController _scoreController;

    void Start()
    {
        _priceText.text = _price.ToString();
    }

    public void BuySkill()
    {
        if (_scoreController.RemoveCoins(_price))
        {
            _specialSkillView.AddSlkill();
        }
    }
}
