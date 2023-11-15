using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int die1;
    [SerializeField] private int die2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Rolling the dice for random 1-6 int
    public void RollDice()
    {
        die1 = Random.Range(0, 6);
        die2 = Random.Range(0, 6);

        Debug.Log("Die 1: " + die1 + ", Die 2: " +  die2);
    }
}
