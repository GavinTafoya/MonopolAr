using System.Collections;
using UnityEngine;

// Moves the player pieces around the map
public class PlayerMovement : MonoBehaviour
{
    private int position1, position2, nextPosition; // The positions of the two players on the map + position helper variable
    private readonly float pieceSpeed = 0.5f;       // The speed pieces move at

    [SerializeField] private Transform[] positions;         // All the positions of pieces on the board
    [SerializeField] private PlayerData playerData;         // Reference to the player data
    [SerializeField] private GameObject currentPiece;       // The piece for the current player
    [SerializeField] private CardController cardController; // Reference to the card controller

    // Sets position variables
    private void Awake()
    {
        position1 = nextPosition = position2 = 0;
    }

    // Moves pieces
    private void Update()
    {
        Vector3 movement = Vector3.MoveTowards(currentPiece.transform.position, positions[nextPosition].position, Time.deltaTime * pieceSpeed);
        currentPiece.transform.position = new Vector3(movement.x, currentPiece.transform.position.y, movement.z);
    }

    // Starts piece movement
    public void MovePiece(int numSpaces, GameObject piece)
    {
        currentPiece = piece;
        StartCoroutine(Move(numSpaces));
    }

    // Actually moves pieces
    private IEnumerator Move(int numSpaces)
    {
        int position = (currentPiece.name == "Player1") ? position1 : position2;
        for (int i = 0; i < numSpaces; i++)
        {
            nextPosition = position + 1;
            if (nextPosition == 40) nextPosition = 0;
            if (position == 0) playerData.AddMoney(200, currentPiece.name == "Player1" ? 0 : 1);

            Debug.Log(Placed());
            yield return new WaitUntil(Placed);
            yield return new WaitForSeconds(0.2f);
            position = nextPosition;
        }

        if (currentPiece.name == "Player1") position1 = position;
        else position2 = position;

        cardController.Prompt(position);
    }

    // Determines if a piece is placed on the next square yet
    private bool Placed()
    {
        if (Vector3.Distance(currentPiece.transform.position, positions[nextPosition].position) <= currentPiece.transform.position.y) return true;
        return false;
    }
}
