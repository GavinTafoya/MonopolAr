using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

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

    public int Owner { get; set; } // The player # of who owns this card

    public string Color { get; }   // Color set of this card

    // Makes a new card
    public Card(string name, int price, int rent, int house1, int house2, int house3, int house4, int hotel, int mortgage, string color, int owner)
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
        Owner = owner;
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

    [SerializeField] private GameObject buyPrompt;

    // Start is called before the first frame update
    void Start()
    {
        cards = new List<Card>
        {
            // Time to add every single card to the list
            new Card("Mediterranean Avenue", 60, 2, 10, 30, 90, 160, 250, 30, "Purple", 0),
            new Card("Baltic Avenue", 60, 4, 20, 60, 180, 320, 450, 30, "Purple", 0),
            new Card("Reading Railroad", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad", 0),
            new Card("Oriental Avenue", 100, 6, 30, 90, 270, 400, 550, 50, "Light Blue", 0),
            new Card("Vermont Avenue", 100, 6, 30, 90, 270, 400, 550, 50, "Light Blue", 0),
            new Card("Connecticut Avenue", 120, 8, 40, 100, 300, 450, 600, 60, "Light Blue", 0),
            new Card("St. Charles Place", 140, 10, 50, 150, 450, 625, 750, 70, "Magenta", 0),
            new Card("Electric Company", 150, 4, 10, 0, 0, 0, 0, 75, "Utility", 0),
            new Card("States Avenue", 140, 10, 50, 150, 450, 625, 750, 70, "Magenta", 0),
            new Card("Virginia Avenue", 160, 12, 60, 180, 500, 700, 900, 80, "Magenta", 0),
            new Card("Pennsylvania Railroad", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad", 0),
            new Card("St. James Place", 180, 14, 70, 200, 550, 750, 950, 90, "Orange", 0),
            new Card("Tennessee Avenue", 180, 14, 70, 200, 550, 750, 950, 90, "Orange", 0),
            new Card("New York Avenue", 200, 16, 80, 220, 600, 800, 1000, 100, "Orange", 0),
            new Card("Kentucky Avenue", 220, 18, 90, 250, 700, 875, 1050, 110, "Red", 0),
            new Card("Indiana Avenue", 220, 18, 90, 250, 700, 875, 1050, 110, "Red", 0),
            new Card("Illinois Avenue", 240, 20, 100, 300, 750, 925, 1100, 120, "Red", 0),
            new Card("Short Line", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad", 0),
            new Card("Atlantic Avenue", 260, 22, 110, 330, 800, 975, 1150, 130, "Yellow", 0),
            new Card("Vetnor Avenue", 260, 22, 110, 330, 800, 975, 1150, 130, "Yellow", 0),
            new Card("Water Works", 150, 4, 10, 0, 0, 0, 0, 75, "Utility", 0),
            new Card("Marvin Gardens", 280, 24, 120, 360, 850, 1025, 1200, 140, "Yellow", 0),
            new Card("Pacific Avenue", 300, 26, 130, 390, 900, 1100, 1275, 150, "Green", 0),
            new Card("North Carolina Avenue", 300, 26, 130, 390, 900, 1100, 1275, 150, "Green", 0),
            new Card("Pennsylvania Avenue", 320, 28, 150, 450, 1000, 1200, 1400, 160, "Green", 0),
            new Card("B & O Railroad", 200, 25, 50, 100, 200, 0, 0, 100, "Railroad", 0),
            new Card("Park Place", 350, 35, 175, 500, 1100, 1300, 1500, 175, "Blue", 0),
            new Card("Boardwalk", 400, 50, 200, 600, 1400, 1700, 2000, 200, "Blue", 0)
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Gets a card by name, unless no cards of that name exists, then you get a blank card
    public Card GetCard(string name)
    {
        foreach (Card card in cards) if (card.Name == name) return card;
        return new Card("None",0,0,0,0,0,0,0,0,"", 0);
    }

    // Gets the full list of cards (probably shouldn't do that)
    public List<Card> GetCardList()
    {
        return cards;
    }

    // Takes a card out of the available list of cards
    public Card TakeCard(string name, int playerNum)
    {
        Card choice = new Card("None",0,0,0,0,0,0,0,0,"",0);
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

        if (cardFound) choice.Owner = playerNum;
        return choice;
    }

    // Makes a prompt for the player to buy/do something else on the space they landed on
    // This is so cancerous right now but I really can't think of a better way to start this off
    // I don't have the time to fix this until after the break so...

    public void Prompt(Transform position)
    {
        string name = position.gameObject.name;

        // gotta handle special cases
        if (name.StartsWith("Community"))
        {

        }
        else if (name.StartsWith("Chance"))
        {

        }
        else if (name.StartsWith("Tax"))
        {

        }
        else if (name.Equals("GO"))
        {

        }
        else if (name.Equals("Jail") || name.Equals("Free"))
        {

        }
        else if (name.Equals("Police"))
        {

        }
        else
        {
            Card property = GetCard(position.gameObject.tag);

            if (property.Owner == 0) // property is not owned
            {
                List<GameObject> buttons = new List<GameObject>(); 
                buyPrompt.GetChildGameObjects(buttons);
                buttons[1].GetComponent<Button>().onClick.AddListener(delegate { BuyProperty(property.Name, 1); });
            }
            else // rent is due
            {
                // TODO: renting
            }
        }
    }

    public void BuyProperty(string name, int playerNum)
    {
        GameObject.Find("Canvas").GetComponent<PlayerData>().GiveCard(TakeCard(name, playerNum));
        GameObject.Find("Canvas").GetComponent<PlayerData>().RemoveMoney(GetCard(name).Price);
    }
}
