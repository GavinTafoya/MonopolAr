using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Card object
public struct Card : IComparable
{
    public string Name { get; }    // Name of the card
    public int Price { get; }      // Price to buy the card
    public int Rent { get; }       // Rent value of the card
    public int OneHouse { get; }   // One house rent
    public int TwoHouse { get; }   // Two house rent
    public int ThreeHouse { get; } // Three house rent
    public int FourHouse { get; }  // Four house rent
    public int Hotel { get; }      // Hotel rent
    public int Mortgage { get; }   // Mortgage value of card (probably wont be implemented, but its here for the sake of completeness)

    public string Color { get; }   // Color set of this card

    // Makes a new card
    public Card(string name, int price, int rent, int house1, int house2, int house3, int house4, int hotel, int mortgage, string color)
    {
        Name = name;
        Price = price;
        Rent = rent;
        OneHouse = house1;
        TwoHouse = house2;
        ThreeHouse = house3;
        FourHouse = house4;
        Hotel = hotel;
        Mortgage = mortgage;
        Color = color;
    }

    // Not sure why I put this in here
    public int CompareTo(object obj)
    {
        Card other = (Card)obj; 
        return Name.CompareTo(other.Name);
    }
}

// Manages the different cards
public class CardController : MonoBehaviour
{
    private List<Card> cards;

    // Start is called before the first frame update
    void Start()
    {
        // Time to add every single card to the list
        cards.Add(new Card("Mediterranean Avenue", 60, 2, 10, 30, 90, 160, 250, 30, "Purple"));
        cards.Add(new Card("Baltic Avenue", 60, 4, 20, 60, 180, 320, 450, 30, "Purple"));
        cards.Add(new Card("Reading Railroad", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad"));
        cards.Add(new Card("Oriental Avenue", 100, 6, 30, 90, 270, 400, 550, 50, "Light Blue"));
        cards.Add(new Card("Vermont Avenue", 100, 6, 30, 90, 270, 400, 550, 50, "Light Blue"));
        cards.Add(new Card("Connecticut Avenue", 120, 8, 40, 100, 300, 450, 600, 60, "Light Blue"));
        cards.Add(new Card("St. Charles Place", 140, 10, 50, 150, 450, 625, 750, 70, "Magenta"));
        cards.Add(new Card("Electric Company", 150, 4, 10, 0, 0, 0, 0, 75, "Utility"));
        cards.Add(new Card("States Avenue", 140, 10, 50, 150, 450, 625, 750, 70, "Magenta"));
        cards.Add(new Card("Virginia Avenue", 160, 12, 60, 180, 500, 700, 900, 80, "Magenta"));
        cards.Add(new Card("Pennsylvania Railroad", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad"));
        cards.Add(new Card("St. James Place", 180, 14, 70, 200, 550, 750, 950, 90, "Orange"));
        cards.Add(new Card("Tennessee Avenue", 180, 14, 70, 200, 550, 750, 950, 90, "Orange"));
        cards.Add(new Card("New York Avenue", 200, 16, 80, 220, 600, 800, 1000, 100, "Orange"));
        cards.Add(new Card("Kentucky Avenue", 220, 18, 90, 250, 700, 875, 1050, 110, "Red"));
        cards.Add(new Card("Indiana Avenue", 220, 18, 90, 250, 700, 875, 1050, 110, "Red"));
        cards.Add(new Card("Illinois Avenue", 240, 20, 100, 300, 750, 925, 1100, 120, "Red"));
        cards.Add(new Card("B & O Railroad", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad"));
        cards.Add(new Card("Atlantic Avenue", 260, 22, 110, 330, 800, 975, 1150, 130, "Yellow"));
        cards.Add(new Card("Vetnor Avenue", 260, 22, 110, 330, 800, 975, 1150, 130, "Yellow"));
        cards.Add(new Card("Water Works", 150, 4, 10, 0, 0, 0, 0, 75, "Utility"));
        cards.Add(new Card("Marvin Gardens", 280, 24, 120, 360, 850, 1025, 1200, 140, "Yellow"));
        cards.Add(new Card("Pacific Avenue", 300, 26, 130, 390, 900, 1100, 1275, 150, "Green"));
        cards.Add(new Card("North Carolina Avenue", 300, 26, 130, 390, 900, 1100, 1275, 150, "Green"));
        cards.Add(new Card("Pennsylvania Avenue", 320, 28, 150, 450, 1000, 1200, 1400, 160, "Green"));
        cards.Add(new Card("Short Line", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad"));
        cards.Add(new Card("Park Place", 350, 35, 175, 500, 1100, 1300, 1500, 175, "Blue"));
        cards.Add(new Card("Boardwalk", 400, 50, 200, 600, 1400, 1700, 2000, 200, "Blue"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Gets a card by name, unless no cards of that name exists, then you get a blank card
    public Card GetCard(string name)
    {
        foreach (Card card in cards) if (card.Name == name) return card;
        return new Card("None",0,0,0,0,0,0,0,0,"");
    }

    // Gets the full list of cards (probably shouldn't do that)
    public List<Card> GetCardList()
    {
        return cards;
    }

    // Takes a card out of the available list of cards
    public Card TakeCard(string name)
    {
        Card choice = new Card("",0,0,0,0,0,0,0,0,"");
        bool cardFound = false;

        foreach (Card card in cards)
        {
            if (card.Name == name)
            {
                choice = card;
                cardFound = true;
                break;
            }
        }

        if (cardFound) cards.Remove(choice);
        return choice;
    }
}
