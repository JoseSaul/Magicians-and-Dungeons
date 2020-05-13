using Character.Hand;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Character.UI
{
    public class UiController : MonoBehaviour
    {
    
        [SerializeField] private Slider lifeSlider;
        [SerializeField] private Slider manaSlider;
        [SerializeField] private Slider expSlider;
        [SerializeField] private Text textNumberCards;
        [SerializeField] private Text textLV;
        [SerializeField] private Canvas canvasPause;
        
        [SerializeField] private Text textMaxLife;
        [SerializeField] private Text textLife;
        [SerializeField] private Text textMana;


        public void SetMaxHealth(int maxHealth)
        {
            lifeSlider.maxValue = maxHealth;
            lifeSlider.value = maxHealth;
        }

        public void SetHealth(int health)
        {
            lifeSlider.value = health;
        }


        public void SetMaxMana(int maxMana)
        {
            manaSlider.maxValue = maxMana;
            manaSlider.value = maxMana;
        }

        public void SetMana(int mana)
        {
            manaSlider.value = mana;
            textMana.text = mana + "";
        }


        public void SetMaxExp(int maxExp)
        {
            expSlider.maxValue = maxExp;
            expSlider.value = maxExp;
        }

        public void SetExp(int exp)
        {
            expSlider.value = exp;
        }


        public void SetLv(int lv)
        {
            this.textLV.text = "LV " + lv;
        }
    
    
        public void SetNumberCards(int numberCards)
        {
            this.textNumberCards.text = numberCards + "";
        }


        public void SetGamePaused()
        {
            canvasPause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    
    
    }
}
