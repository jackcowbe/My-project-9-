using System.Threading;
using Unity.Collections;
using UnityEngine;
using Unity.Mathematics;


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

    public class hashmap
    { 
        public struct inspection
        {
            public float3 pos;
            public Color32 color;
            public float size;
            public float life;
            
            public inspection(float3 pos, Color32 color, float size, float life)
            {
                this.pos = pos;
                this.color = color;
                this.size = size;
                this.life = life;
            }
        }


    }

    public class AVL_tree
    {
        const int isnull = -1; //AVL樹插入位置
        private int root = isnull; //AVL樹根節點位置
        private int nextindex = 0; //AVL樹下一個可用位置
        public struct AVLnode
        { 
            public int index;
            public hashmap.inspection value;
            public int height;
            public int left;
            public int right;

          


        }

        public NativeArray<AVLnode> avltree; //宣告AVL樹陣列
        public void avltreecoordinate(int size)
        { 
            avltree = new NativeArray<AVLnode>(size, Allocator.Persistent); //宣告AVL樹陣列大小 不回收
        }
        public void add(hashmap.inspection value)
        {
            root = insert(root, value);
        } 
        
        private int insert(int index, hashmap.inspection value)
        {
          
        }
        private void updateheight(int index)
        {

        }
        private int rebalance(int index)
        {


        }
        private int getbalance(int index)
        {


        }
        private int rightrotate(int index)
        {


        }

        private int leftrotate(int index)
        {


        }








    }


 }
