using System;
using System.Collections.Generic;
using UnityEngine;
// Span<int> sliceX = x.AsSpan().Slice(int,int); // 創建一個切片來訪問X座標的一部分
public class Datahub 
{
    public const float squareSizew = 1.1f;  //寬度
    public const float squareSizeh = 1.1f;  //高度
    public const int z = 10; // 相機高度
    static public readonly int[] x = new int[10000]; // 10000个格子，每个格子一个x坐标
    static public readonly int[] y = new int[10000]; // 10000个格子，每个格子一个y坐标
   

    static public int[] mouseX = new int[1]; // 鼠标点击位置的X坐标
    static public int[] mouseY = new int[1]; // 鼠标点击位置的Y坐标
    



}


                    