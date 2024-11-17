using UnityEngine;

[RequireComponent(typeof(CardPlacer))]
public class DumbInteractor : MonoBehaviour
{
    [SerializeField]
    private Card[] _cards;
    private CardPlacer _cardPlacer;

    private void Awake()
    {
        _cardPlacer = GetComponent<CardPlacer>();
        _cardPlacer.AddCards(_cards);
        PlaceAllToBase();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _cardPlacer.ShuffleCards();
            PlaceAllToBase();
        }
    }

    private void PlaceAllToBase()
    {
        foreach (var card in _cards)
        {
            card.PlaceToBase();
        }
    }
}
