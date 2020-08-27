using Character.UI;
using UnityEngine;

namespace Stats
{
    public class Mana
    {
        private UiController _uiController;
        
        private int _maxMana = 10;
        private int _mana;
        private const float RecoverMana = 4f;
        private float _manaCoolDown;

        public void InitMana(UiController ui)
        {
            _uiController = ui;
            _manaCoolDown = RecoverMana;
            _mana = _maxMana;
        }

        public void SetMana(int mana)
        {
            _mana = mana;
        }

        public void SetMaxMana(int maxMana)
        {
            _maxMana = maxMana;
        }

        public int GetMana()
        {
            return _mana;
        }

        public int GetMaxMana()
        {
            return _maxMana;
        }
        
        
        public void ConsumeMana(int consume)
        {
            _mana -= consume;
            _uiController.SetMana(_mana);
        }

        public void RestoreMana(int mana)
        {
            if (_mana + mana > _maxMana)
            {
                _mana = _maxMana;
            }
            else
            {
                _mana += mana;
            }
            _uiController.SetHealth(_mana);
        }
        
        
        public void CheckMana()
        {
            // ReSharper disable once InvertIf
            if (_maxMana > _mana)
            {
                if (_manaCoolDown > 0)
                {
                    _manaCoolDown -= Time.deltaTime;
                }
                else
                {
                    _mana++;
                    _uiController.SetMana(_mana);
                    _manaCoolDown = RecoverMana;
                }
            }
        }
        
        
    
    }
}
