using System.Threading;
using Unity.Collections;
using UnityEngine;

public class Datahub 
{
    public struct Data
    {
        public int id; //細胞ID          4byte

    }

    public NativeArray<int> iscell;//宣告細胞陣列
    public void coordinate(int size)
    { 
        iscell = new NativeArray<int>(size, Allocator.Persistent); //宣告細胞陣列大小 不回收
    }
}