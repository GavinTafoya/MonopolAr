using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int position, nextPosition;
    [SerializeField] Transform[] positions;
    private GameObject currentPiece = new();

    private void Awake()
    {
        position = nextPosition = 0;
    }

    private void Update()
    {
        currentPiece.transform.position = Vector3.MoveTowards(currentPiece.transform.position, positions[nextPosition].position, .1f);
    }

    public void MovePiece(int numSpaces, GameObject piece)
    {
        for (int i = 0; i < numSpaces; i++)
        {
            nextPosition = position + 1;
            if (nextPosition == 40) nextPosition = 0;

            while(piece.transform.position.x != positions[nextPosition].position.x && piece.transform.position.x != positions[nextPosition].position.x)
            {

            }

            position = nextPosition;
        }
    }
}
