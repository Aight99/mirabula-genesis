using System.Collections.Generic;
using UnityEngine;

// TODO: Стратегии размещения (равномерное распределение баз, выкладка как есть)
public class CardPlacer : MonoBehaviour
{
    [SerializeField]
    private Transform[] _availableBaseTransforms;
    private readonly List<Card> cards = new();

    public int CardsLimit => _availableBaseTransforms.Length;

    public void AddCard(Card card, bool recalculateBases = true)
    {
        if (cards.Count == CardsLimit)
        {
            Debug.LogWarning("CardPlacer already at Card Limit!");
            return;
        }
        cards.Add(card);
        if (recalculateBases)
        {
            RecalculateBasesForCards();
        }
    }

    public void AddCards(Card[] cards)
    {
        foreach (var card in cards)
        {
            AddCard(card, false);
        }
        RecalculateBasesForCards();
    }

    public void ShuffleCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var randomIndex = Random.Range(i, cards.Count);
            (cards[randomIndex], cards[i]) = (cards[i], cards[randomIndex]);
        }
        RecalculateBasesForCards();
    }

    private void RecalculateBasesForCards()
    {
        var baseIndex = 0;
        foreach (var card in cards)
        {
            card.basePointTransform = _availableBaseTransforms[baseIndex];
            baseIndex++;
        }
    }
}
