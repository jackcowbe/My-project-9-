using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Judger : MonoBehaviour
{
    public List<GameObject> squares = new List<GameObject>(10000);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gird.OK += AddSquare;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void AddSquare(GameObject square)
    {
        squares.Add(square);
    }
}
