using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int position, nextPosition;
    private float pieceSpeed = 0.5f;

    [SerializeField] Transform[] positions;
    [SerializeField] private GameObject currentPiece;

    private bool placed = false;

    private void Awake()
    {
        position = nextPosition = 0;
    }

    private void Update()
    {
        Vector3 movement = Vector3.MoveTowards(currentPiece.transform.position, positions[nextPosition].position, Time.deltaTime * pieceSpeed);
        currentPiece.transform.position = new Vector3(movement.x, currentPiece.transform.position.y, movement.z);
    }

    public void MovePiece(int numSpaces, GameObject piece)
    {
        currentPiece = piece;
        StartCoroutine(move(numSpaces));
    }

    private IEnumerator move(int numSpaces)
    {
        for (int i = 0; i < numSpaces; i++)
        {
            nextPosition = position + 1;
            if (nextPosition == 40) nextPosition = 0;

            Debug.Log(Placed());
            yield return new WaitUntil(Placed);
            yield return new WaitForSeconds(1);
            position = nextPosition;
        }
    }

    private bool Placed()
    {
        if (Vector3.Distance(currentPiece.transform.position, positions[nextPosition].position) <= currentPiece.transform.position.y) return true;
        return false;
    }
}
