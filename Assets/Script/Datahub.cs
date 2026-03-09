using System.Threading;
using Unity.Collections;
using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;


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
        private int width = 100; //AVL樹寬度 用於計算插入位置
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
            if (index == isnull)
            {
                int newindex = nextindex++;                           //取得下一個可用位置
                avltree[newindex] = new AVLnode
                {
                    index = newindex,
                    value = value,
                    height = 1,
                    left = isnull,
                    right = isnull
                };
                 return nextindex;
            }

            else if (value.pos.x+value.pos.y*width<avltree[index].value.pos.x+avltree[index].value.pos.y*width)  //插左邊
            {
                AVLnode node = avltree[index];
                node.left = insert(avltree[index].left, value);
                avltree[index] = node;

            }
            else if (value.pos.x+value.pos.y*width>avltree[index].value.pos.x+avltree[index].value.pos.y*width)  //插右邊
            {
                AVLnode node = avltree[index];
                node.right = insert(avltree[index].right, value);
                avltree[index] = node;

            }

            else                                                                        //平衡不用插
            {
                return index;
            }

            updateheight(index);                                                          //更新高度
            rebalance(index);                                                             //平衡因子檢查與旋轉
        }
            
        private void updateheight(int index)
        {
            if
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
