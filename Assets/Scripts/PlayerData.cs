using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int die1;
    [SerializeField] private int die2;
    [SerializeField] private Image blankDieOne;
    [SerializeField] private Image blankDieTwo;
    [SerializeField] private Sprite dieOne;
    [SerializeField] private Sprite dieTwo;
    [SerializeField] private Sprite dieThree;
    [SerializeField] private Sprite dieFour;
    [SerializeField] private Sprite dieFive;
    [SerializeField] private Sprite dieSix;
    [SerializeField] private PlayerMovement playerMovement;

    public GameObject playerPiece;

    [SerializeField] private CardController cards;
    private List<Card> playerCards; // The cards the player has

    [SerializeField] private TMP_Text moneyText; // (temporary) The text showing the player's money
    private int money;                           // How much money the player has

    // Start is called before the first frame update
    void Awake()
    {
        playerCards = new List<Card>();
        money = 1500;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + money;
    }

    // Rolling the dice for random 1-6 int
    public void RollDice()
    {
        die1 = Random.Range(1, 7);
        die2 = Random.Range(1, 7);

        Debug.Log("Die 1: " + die1 + ", Die 2: " +  die2);

        playerMovement.MovePiece(die1 + die2, playerPiece);

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
}
