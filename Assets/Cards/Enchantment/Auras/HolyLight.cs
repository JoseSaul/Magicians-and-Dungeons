namespace Cards.Enchantment.Auras
{
    public class HolyLight : Aura
    {
        public override void TriggerAura(Card card)
        {
            if (card.GetTypeCard() == 0)
            {
                print("Ataque sube");
            }
        }
        
    }
}
