using TMPro;
using UnityEngine;

namespace Cards
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private byte rarity;
        [SerializeField] private int id;
        [SerializeField] protected TextMeshPro textMeshCard;
        [SerializeField] protected int manaCost;


        public virtual void PlayCard()
        {
            
        }

        
        public int GetManaCost()
        {
            return manaCost;
        }

        public void UpdateTextCard(string text)
        {
            textMeshCard.text = text;
        }
        

        public int GetId()
        {
            return id;
        }


    }
}
