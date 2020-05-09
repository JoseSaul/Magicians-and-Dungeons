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


        public void SetMaxEXP(int maxEXP)
        {
            expSlider.maxValue = maxEXP;
            expSlider.value = maxEXP;
        }

        public void SetEXP(int exp)
        {
            expSlider.value = exp;
        }


        public void SetLV(int lv)
        {
            this.textLV.text = "LV " + lv;
        }
    
    
        public void SetNumberCards(int numberCards)
        {
            this.textNumberCards.text = numberCards + "";
        }
    
    
    }
}
