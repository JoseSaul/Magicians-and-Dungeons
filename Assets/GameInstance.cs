using Boo.Lang;
using Cards;
using Stats;
using Character.UI;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance Instance { get; set; }
    private UiController _uiController;
    
    [SerializeField] private Deck deck;
    [SerializeField] private Card[] allCards;
    private CardCollection[] _collectionCard;
    private Life _life;
    private Mana _mana;
    private Lv _lv;
    private float _rechargeCard = 3;
    private bool _onGame;
    

    private void Start()
    {
        _life = new Life();
        _mana = new Mana();
        _lv = new Lv();

        InitCollection();
    }

    public void OnStartGame()
    {
        _onGame = true;
        _uiController = FindObjectOfType<UiController>();
        _life.InitLife(_uiController);
        _mana.InitMana(_uiController);
        _uiController.SetMaxHealth(_life.GetMaxLife());
        _uiController.SetMaxMana(_mana.GetMaxMana());
        _uiController.SetMaxExp(_lv.GetMaxExp());
        _uiController.SetExp(_lv.GetExp());
        _uiController.SetLv(_lv.GetLV());
    }

    public void ExitGame()
    {
        _onGame = false;
    }

    private void Update()
    {
        if (_onGame)
        {
            _mana.CheckMana();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        if (_life.IsDeath(damage))
        {
            print("Esta muerto");
        }
    }
    

    //GetStats
    public Deck GetDeck()
    {
        return deck;
    }
    

    public Life GetLife()
    {
        return _life;
    }

    public Mana GetMana()
    {
        return _mana;
    }

    
    //Settings
    private bool _eng = true;
    
    public string Language(string eng, string spa)
    {
        return _eng ? eng : spa;
    }
    

    //Deck
    public float GetRechargeCard()
    {
        return _rechargeCard;
    }
    

    public List<CardCollection> GetObtainedCard()
    {
        var collectionList = new List<CardCollection>();
        foreach (var cardCollected in _collectionCard)
        {
            collectionList.Add(cardCollected);
        }
        
        return collectionList;
    }
    
    public List<CardCollection> GetDeckAsCollection()
    {
        var deckCollection = new List<CardCollection>();
        var auxDeck = deck.GetDeck();
        foreach (var card in auxDeck)
        {
            if (card != null)
            {
                var selectedCard = card;
                var count = 0;

                for (var i = 0; i < auxDeck.Length; i++)
                {
                    if (auxDeck[i] == selectedCard)
                    {
                        count++;
                        auxDeck[i] = null;
                    }
                }

                deckCollection.Add(new CardCollection(selectedCard, count));
            }
        }
        return deckCollection;
    }

    public void SetDeck(CardCollection[] cardCollections)
    {
        var deckList = new List<Card>();
        foreach (var collection in cardCollections)
        {
            for (var i = 0; i < collection.GetQuantity(); i++)
            {
                deckList.Add(collection.GetCard());
            }
        }
        deck.SetDeck(deckList.ToArray());
    }

    public void SetCollection(CardCollection[] collectionCard)
    {
        _collectionCard = collectionCard;
    }

        private void InitCollection()
    {
        _collectionCard = new CardCollection[allCards.Length];
        
        for (var i = 0; i < _collectionCard.Length; i++)
        {
            // ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
            _collectionCard[i] = new CardCollection(allCards[i],0);
        }
        
        //Cambiar por las que quieras.......................................................
        _collectionCard[0].SetQuantity(4);
        _collectionCard[1].SetQuantity(2);
        _collectionCard[2].SetQuantity(1);
        _collectionCard[3].SetQuantity(1);
        _collectionCard[4].SetQuantity(1);
        _collectionCard[5].SetQuantity(1);
    }
    
    
}
