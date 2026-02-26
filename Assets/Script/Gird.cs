using System;
using System.Data.SqlTypes;
using UnityEngine;

public class Gird : MonoBehaviour
{
    
    public GameObject square;
    private int n = 0;

    static public Action<GameObject,int,int> ready;
    static public Action<GameObject> OK;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i<100; i++)
        {
            for (int j = 0; j<100; j++)
            {
                Instantiate(square,new Vector3(i*Datahub.squareSizew,j*Datahub.squareSizeh,0),Quaternion.identity);
                ready?.Invoke(square,i,j);
                OK?.Invoke(square);
                Datahub.x[n] = i;
                Datahub.y[n] = j;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private class  coordinate:MonoBehaviour
    {
        public int row = 0, column = 0;
        public int[,] gird = new int[100, 100];
        
        private void Start()
        {
             ready += coorsystem;
        }

        public void coorsystem(GameObject square,int row, int column)
        {
            
            this.row = row;
            this.column = column;
        }
    }
}
