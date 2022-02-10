using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform standPoint;
    [SerializeField] private float spacing; 
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private GameObject[] numberOfMinions;

    private float newXPosition;
    private float newZPosition;

    private void OnEnable()
    {
        columns = 10;
    }

    public void GenerateRandomPositions(GameObject[] minions)
    {
        numberOfMinions = minions;
        if (numberOfMinions.Length % columns == 0)
        {
            rows = numberOfMinions.Length / columns;
        }
        else
        {
            rows = numberOfMinions.Length / columns + 1;
        }
        Debug.Log(rows);
        newXPosition = standPoint.position.x;
        newZPosition = standPoint.position.z;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 newPos = new Vector3(newXPosition, standPoint.position.y, newZPosition);
                Instantiate(cube, newPos, Quaternion.identity);
                newXPosition += spacing;
            }
            newXPosition = standPoint.position.x;
            newZPosition -= spacing;
        }
    }
}
