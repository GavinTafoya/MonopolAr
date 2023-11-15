using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card : IComparable
{
    public string Name { get; }
    public int Price { get; }

    public Card(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public int CompareTo(object obj)
    {
        Card other = (Card)obj;
        return Name.CompareTo(other.Name);
    }
}

public class CardController : MonoBehaviour
{
    private List<Card> cards;

    // Start is called before the first frame update
    void Start()
    {
        // Time to add every single card to the list
        cards.Add(new Card("Mediterranean Avenue", 60));
        cards.Add(new Card("Baltic Avenue", 60));
        cards.Add(new Card("Reading Railroad", 200));
        cards.Add(new Card("Oriental Avenue", 100));
        cards.Add(new Card("Vermont Avenue", 100));
        cards.Add(new Card("Connecticut Avenue", 120));
        cards.Add(new Card("St. Charles Place", 140));
        cards.Add(new Card("Electric Company", 150));
        cards.Add(new Card("States Avenue", 140));
        cards.Add(new Card("Virginia Avenue", 160));
        cards.Add(new Card("Pennsylvania Railroad", 200));
        cards.Add(new Card("St. James Place", 180));
        cards.Add(new Card("Tennessee Avenue", 180));
        cards.Add(new Card("New York Avenue", 200));
        cards.Add(new Card("Kentucky Avenue", 220));
        cards.Add(new Card("Indiana Avenue", 220));
        cards.Add(new Card("Illinois Avenue", 240));
        cards.Add(new Card("B & O Railroad", 200));
        cards.Add(new Card("Atlantic Avenue", 260));
        cards.Add(new Card("Vetnor Avenue", 260));
        cards.Add(new Card("Water Works", 150));
        cards.Add(new Card("Marvin Gardens", 280));
        cards.Add(new Card("Pacific Avenue", 300));
        cards.Add(new Card("North Carolina Avenue", 300));
        cards.Add(new Card("Pennsylvania Avenue", 320));
        cards.Add(new Card("Short Line", 200));
        cards.Add(new Card("Park Place", 350));
        cards.Add(new Card("Boardwalk", 400));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card GetCard(string name)
    {
        foreach(Card card in cards) if (card.Name == name) return card;
        return new Card("None", 0);
    }

    public List<Card> GetCardList()
    {
        return cards;
    }

    public Card TakeCard(string name)
    {
        Card choice = new Card("", 0);
        foreach (Card card in cards)
        {
            if (card.Name == name)
            {
                choice = card;
                break;
            }
        }
        cards.Remove(choice);
        return choice;
    }
}
