using Cards.Attack;

namespace Cards.Enchantment.Auras
{
    public class HolyLight : Aura
    {
        public override void TriggerAura(Card card)
        {
            if (card == null) return;
            var cardAttack = card.GetComponentInChildren<CardAttack>();
            if (cardAttack == null) return;
            cardAttack.PlusBonusAttack(boost);

        }
        
    }
}
