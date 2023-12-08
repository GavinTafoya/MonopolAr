using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Handles player data for both players
public class PlayerData : MonoBehaviour
{
    [SerializeField] private int die1;             // The first dice number
    [SerializeField] private int die2;             // The second dice number
    [SerializeField] private int playerSwitch = 0; // Which player's turn it is
    [SerializeField] private Image blankDieOne;    // The first dice image
    [SerializeField] private Image blankDieTwo;    // The second dice image
    [SerializeField] private Sprite dieOne;        // The number 1
    [SerializeField] private Sprite dieTwo;        // The number 2
    [SerializeField] private Sprite dieThree;      // The number 3
    [SerializeField] private Sprite dieFour;       // The number 4
    [SerializeField] private Sprite dieFive;       // The number 5
    [SerializeField] private Sprite dieSix;        // The number 6

    [SerializeField] private PlayerMovement playerMovement;                 // Reference to the player movement script
    [SerializeField] private GameObject[] playerPieces = new GameObject[2]; // The two pieces for the players

    [SerializeField] private CardController cards; // Reference to the card controller
    [SerializeField] private TMP_Text[] cardLists; // The lists of cards next to the person's money
    private List<Card> playerCards;                // The cards the player has

    [SerializeField] private TMP_Text[] moneyText; // The text showing the player's money
    private int[] money = {1300, 1300};            // How much money the player has - starts at 1300 to counteract a GO bug

    // Start is called before the first frame update
    void Awake()
    {
        playerCards = new List<Card>();
    }

    // Update is called once per frame
    // Fixed update for less lag (doubt there will be any lag to begin with tho)
    void FixedUpdate()
    {
        moneyText[0].text = "Money: " + money[0];
        moneyText[1].text = "Money: " + money[1];

        cardLists[0].text = "";
        cardLists[1].text = "";

        for (int i = 0; i < cards.GetCardList().Length; i++)
        {
            if (cards.GetCard(i).Owner == 1)
            {
                cardLists[0].text += cards.GetCard(i).Name + cards.GetCard(i).Owner + "\n";
            }
            else if (cards.GetCard(i).Owner == 2)
            {
                cardLists[1].text += cards.GetCard(i).Name + cards.GetCard(i).Owner + "\n";
            }
        }
    }

    // Rolling the dice for random 1-6 int
    // i'd really like to make this slightly nicer on the code side but it works so i'll save that for later
    public void RollDice()
    {
        die1 = Random.Range(1, 7);
        die2 = Random.Range(1, 7);

        Debug.Log("Die 1: " + die1 + ", Die 2: " +  die2);

        playerMovement.MovePiece(die1 + die2, playerPieces[playerSwitch]);

        if (die1 == 1)
        {
            blankDieOne.sprite = dieOne;
        }
        else if (die1 == 2)
        {
            blankDieOne.sprite = dieTwo;
        }
        else if (die1 == 3)
        {
            blankDieOne.sprite = dieThree;
        }
        else if (die1 == 4)
        {
            blankDieOne.sprite = dieFour;
        }
        else if (die1 == 5)
        {
            blankDieOne.sprite = dieFive;
        }
        else if (die1 == 6)
        {
            blankDieOne.sprite = dieSix;
        }

        if (die2 == 1)
        {
            blankDieTwo.sprite = dieOne;
        }
        else if (die2 == 2)
        {
            blankDieTwo.sprite = dieTwo;
        }
        else if (die2 == 3)
        {
            blankDieTwo.sprite = dieThree;
        }
        else if (die2 == 4)
        {
            blankDieTwo.sprite = dieFour;
        }
        else if (die2 == 5)
        {
            blankDieTwo.sprite = dieFive;
        }
        else if (die2 == 6)
        {
            blankDieTwo.sprite = dieSix;
        }
    }

    public void SwitchTurn()
    {
        if (die1 != die2)
        {
            playerSwitch = (playerSwitch == 0) ? 1 : 0;
        }
    }

    public void GiveCard(Card card)
    {
        playerCards.Add(card);
    }

    public int GetMoney(int player)
    {
        return money[player];
    }

    public int GetTurn()
    {
        return playerSwitch;
    }

    public bool HasEnoughMoney(int amount, int player)
    {
        return money[player] >= amount;
    }

    public int RemoveMoney(int amount, int player)
    {
        money[player] -= amount;
        return amount;
    }
    
    public int AddMoney(int amount, int player)
    {
        money[player] += amount;
        return amount;
    }
}
