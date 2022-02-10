using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private Transform standPoint;
    [SerializeField] private float spacing; 
    [SerializeField] private int numberOfRows;
    [SerializeField] private int numberOfColumns;
    [SerializeField] private GameObject[] numberOfMinions;

    private float newXPosition;
    private float newZPosition;
    private int rowCapacity;

    public void GenerateRandomPositions(GameObject[] minions)
    {
        numberOfMinions = minions;
        numberOfRows = numberOfMinions.Length / rowCapacity;
        newXPosition = standPoint.position.x;
        newZPosition = standPoint.position.z;
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                Vector3 newPos = new Vector3(newXPosition, transform.position.y, newZPosition);
                newXPosition += spacing;
            }       
            newXPosition = transform.position.x + spacing / 2f;
            newZPosition += spacing;
        }
    }
}
