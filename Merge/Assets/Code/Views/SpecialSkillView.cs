using Code.Infrostructure;
using TMPro;
using UnityEngine;

namespace Code.Views
{
    public class SpecialSkillView : MonoBehaviour
    {
        [SerializeField]
        private SpecialSkill _specialSkill;
        [SerializeField]
        private TMP_Text _skillcount;
        [SerializeField]
        private SkillsController _skillsController;
        
        private int _count = 0;

        void Start()
        {
            _skillcount.text = _count.ToString();
        }
        public void AddSlkill()
        {
            _count++;
            _skillcount.text = _count.ToString();
        }

        public void UseSlkill()
        {
            if (_count<=0)
            {
                return;
            }

            _count--;
            _skillcount.text = _count.ToString();
            _skillsController.UseSkill(_specialSkill);
        }
    }
}