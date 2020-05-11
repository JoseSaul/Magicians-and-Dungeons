using UnityEngine;

namespace Cards
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private byte rarity;
        [SerializeField] private int id;
        [SerializeField] protected TextMesh textMeshCard;
        [SerializeField] protected int manaCost = 0;
        
        protected byte TypeCard = 0;


        public byte GetTypeCard()
        {
            return TypeCard;}

        
        public virtual void PlayCard(){}

        
        public int GetManaCost()
        {
            return manaCost;
        }

        public void UpdateTextCard(string text)
        {
            textMeshCard.text = text;
        }

    }
}
