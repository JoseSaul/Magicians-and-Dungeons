﻿using Character.UI;
using UnityEngine;

namespace Stats
{
    public class Life
    {
        private UiController _uiController;
        
        private int _maxLife = 10, _life;
        
        
        public void InitLife(UiController ui)
        {
            _uiController = ui;
            _life = _maxLife;
        }

        public int GetMaxLife()
        {
            return _maxLife;
        }

        public bool IsDeath(int damage)
        {
            _life -= damage;
            _uiController.SetHealth(_life);

            return _life <= 0;
        }

        public void Cure(int health)
        {
            if (health + _life > _maxLife)
            {
                _life = _maxLife;
            }
            else
            {
                _life += health;
            }
            _uiController.SetHealth(_life);
        } 
        
        
    }
}
