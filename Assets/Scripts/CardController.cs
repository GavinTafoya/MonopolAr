using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

// Card object
public struct Card
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
}

// Manages the different cards
public class CardController : MonoBehaviour
{
    private Card[] cards; // The list of all the cards

    [SerializeField] private GameObject promptPanel;                     // The prompt menu
    [SerializeField] private TMP_Text promptText, type, question, price; // All the text relating to prompts
    private PlayerData playerData; // Reference to the player data

    // Data for what prompts will say based on each location on the board
    public readonly string[][] locations =
    {
        new string[] {"GO", "Square", "This cost you: "},
        new string[] {"Mediterranean Avenue", "Property", "This cost you: "},
        new string[] {"Community Chest", "Event", "Take A Card, Any Card"},
        new string[] {"Baltic Avenue","Property", "This cost you: "},
        new string[] {"Income Tax", "Tax", "You are making too much money, pay up"},
        new string[] {"Reading Railroad","Railroad", "This cost you: "},
        new string[] {"Oriental Avenue", "Property", "This cost you: "},
        new string[] {"Chance", "Event", "Take a chance on me"},
        new string[] {"Vermont Avenue", "Property", "This cost you: "},
        new string[] {"Connecticut Avenue", "Property", "This cost you: "},
        new string[] {"Jail", "Square", "Get too lucky and they may lock you up in here..."},
        new string[] {"St. Charles Place", "Property", "This cost you: "},
        new string[] {"Electric Company", "Utility", "For a low low price you can administer controlled shocks too"},
        new string[] {"States Avenue", "Property", "This cost you: "},
        new string[] {"Virginia Avenue", "Property", "This cost you: "},
        new string[] {"Pennsylvania Railroad", "Railroad", "Choo Choo! Would you like to purchase this transport?"},
        new string[] {"St. James Place", "Property", "This cost you: "},
        new string[] {"Community Chest", "Event", "Giving back to your community is the best form of charity..."},
        new string[] {"Tennessee Avenue", "Property", "This cost you: "},
        new string[] {"New York Avenue", "Property", "This cost you: "},
        new string[] {"Free Parking", "Square", "A nice place to relax and watch others suffer through your property line"},
        new string[] {"Kentucky Avenue", "Property", "This cost you: "},
        new string[] {"Chance", "Event", "I think we consider too much the good luck of the early bird and not enough the bad luck of the early worm"},
        new string[] {"Indiana Avenue", "Property", "This cost you: "},
        new string[] {"Illinois Avenue", "Property", "This cost you: "},
        new string[] {"Short Line", "Railroad", "The line may be short but there is plenty of choo choo!"},
        new string[] {"Atlantic Avenue", "Property", "This cost you: "},
        new string[] {"Vetnor Avenue", "Property", "This cost you: "},
        new string[] {"Water Works", "Utility", "The water does work, wanna try it?"},
        new string[] {"Marvin Gardens", "Property", "This cost you: "},
        new string[] {"Go to Jail", "Square", "Whoops, looks like thy caught ya"},
        new string[] {"Pacific Avenue", "Property", "This cost you: "},
        new string[] {"North Carolina Avenue", "Property", "This cost you: "},
        new string[] {"Community Chest", "Event", "We live in a society. Sometimes you have to give back."},
        new string[] {"Pennsylvania Avenue", "Property", "This cost you: "},
        new string[] {"B & O Railroad", "Railroad", "B & O Railroad is always the last stop, buy it before there is no more choo choo"},
        new string[] {"Chance", "Event", "Take a chance, roll the dice, you might win once or twice"},
        new string[] {"Park Place", "Property", "This cost you: "},
        new string[] {"Luxury Tax", "Tax", "Livin' the good life I see. Pay up"},
        new string[] {"Boardwalk", "Property", "This cost you: "},
    };

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("Canvas").GetComponent<PlayerData>();
        promptPanel.SetActive(false);

        cards = new Card[]
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

    // Gets a card by name, unless no cards of that name exists, then you get a blank card
    public Card GetCard(string name)
    {
        foreach (Card card in cards) if (card.Name == name) return card;
        return new Card("None",0,0,0,0,0,0,0,0,"", 0);
    }

    // Gets the full list of cards (probably shouldn't do that)
    public Card[] GetCardList()
    {
        return cards;
    }

    // Takes a card out of the available list of cards
    public Card TakeCard(string name, int playerNum)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].Name.Equals(name))
            {
                cards[i].Owner = playerNum;
                return cards[i];
            }
        }
        return new("None", 0, 0, 0, 0, 0, 0, 0, 0, "", 0);
    }

    // Makes a prompt for the player to buy/do something else on the space they landed on
    public void Prompt(int position)
    {
        promptText.SetText(locations[position][0]);
        type.SetText(locations[position][1]);

        promptPanel.SetActive(true);

        // gotta handle special cases
        switch (locations[position][1])
        {
            case ("Event"):
                PopUpEvent(position);
                break;
            case ("Tax"):
                PopUpTax(position); 
                break;
            case ("Property"):
            case ("Utility"):
            case ("Railroad"):
                PopUpProperty(position);
                break;
            case ("Square"):
                PopUpSquare(position);
                break;
            default:
                Debug.Log("How did we get here?");
                break;
        }
    }

    // PopUp Functions
    public void PopUpEvent(int position)
    {
        int cost = Random.Range(2, 6) * 50 * ((Random.value > 0.5f) ? 1 : -1);

        // Set Prompt Text
        question.SetText(locations[position][2]);
        price.SetText("$" + cost + ".00");

        if (cost > 0) playerData.AddMoney(cost, playerData.GetTurn()); 
        else playerData.RemoveMoney(-cost, playerData.GetTurn());
    }

    public void PopUpProperty(int position)
    {
        // Card generation
        Card property = GetCard(locations[position][0]);

        // Location Behavior
        if (property.Owner == 0) // property is not owned
        {
            question.SetText(locations[position][2]);
            price.SetText("$" + property.Price.ToString() + ".00" + ((property.Price > playerData.GetMoney(playerData.GetTurn())) ? " - Not Enough" : ""));
            if (!price.text.Contains("Not Enough")) BuyProperty(property.Name, playerData.GetTurn());
        }
        else // rent is due
        {
            question.SetText("You owe player" + property.Owner + ":");
            price.SetText(" $" + property.Rent + ".00");
            PayRent(property.Rent);
        }
    }

    public void PopUpSquare(int position)
    {
        question.SetText(locations[position][2]);
        price.SetText("");
    }

    public void PopUpTax(int position)
    {
        if (locations[position][0] == "Income Tax") playerData.RemoveMoney(playerData.GetMoney(playerData.GetTurn()) / 10, playerData.GetTurn());
        else playerData.RemoveMoney(playerData.GetMoney(playerData.GetTurn()) / 5, playerData.GetTurn());
    }

    // Property Options
    public void BuyProperty(string name, int playerNum)
    {
        TakeCard(name, playerNum);
        playerData.RemoveMoney(GetCard(name).Price, playerNum);
    }

    private void PayRent(int rent)
    {
        if (rent > playerData.GetMoney(playerData.GetTurn()))
        {
            playerData.AddMoney(playerData.GetMoney(playerData.GetTurn()) + 1, (playerData.GetTurn() == 0) ? 1 : 0);
            playerData.RemoveMoney(playerData.GetMoney(playerData.GetTurn()) + 1, playerData.GetTurn());
        }
        else
        {
            playerData.AddMoney(rent, (playerData.GetTurn() == 0) ? 1 : 0);
            playerData.RemoveMoney(rent, playerData.GetTurn());
        }
    }

    // Remove Prompt
    public void PromptButton()
    {
        promptPanel.SetActive(false);
    }
}
