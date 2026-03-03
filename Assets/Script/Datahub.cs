using System.Threading;
using Unity.Collections;
using UnityEngine;
 namespace Myproject 

 { 
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

    public class color
    { 
        public struct  RGB
        {
            public int R;
            public int G;
            public int B;
        }

        public NativeArray<RGB> colorarray; //宣告顏色陣列
        public void colorcoordinate(int size)
        { 
            colorarray = new NativeArray<RGB>(size, Allocator.Persistent); //宣告顏色陣列大小 不回收
        }

   
    }

    public class cell
    {
        public struct cellstruct
        {
            public int id; //細胞ID          4byte
       
        }
        public NativeArray<cellstruct> cellarray; //宣告細胞陣列
        public void cellcoordinate()
        { 
            cellarray = new NativeArray<cellstruct>(2, Allocator.Persistent); //宣告細胞陣列大小 不回收
        }

    }

    public class pos
    { 
        public struct posstruct
        {
            public int x;
            public int y;
        }

    }



 }
