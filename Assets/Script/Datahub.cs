using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.Android.Gradle;
using System.Runtime.InteropServices;
using System;


namespace Myproject

{
    [System.Serializable]

    public class hashmap
    {
        private AVL_tree avltree = new AVL_tree(10000); //AVL樹
        private int width = 100; //網格寬度
        private int height = 100;//網格高度
        Matrix4x4[] matrices = new Matrix4x4[1023]; //矩陣陣列
        public Mesh Mesh; //網格
        public Material Material; //材質
        public RenderParams rp; 

        public struct inspection
        {
            public float3 pos;
            public byte status; //0:格子 灰色 1:活細胞 紫色 2:新生細胞 粉色
            public float size;
            public float life;



        }
        public void DrawmyGrid()
        {
            for (int i = 0; i<1023; i++)
            {
                matrices[i] =  Matrix4x4.TRS(new Vector3(i % width, i / width, i/(width*height)), Quaternion.identity, Vector3.one);
                inspection cell = new inspection();
                cell.pos = new float3(i % width, i / width, i / (width * height));
                cell.status = 0;
                //avltree.add(cell);

            }
             rp = new RenderParams(Material);

            // 2. 設定渲染邊界 (覆蓋你 100x100 的領土)
            rp.worldBounds = new Bounds(Vector3.zero, new Vector3(100, 100, 10));


           
        }

        public void UpdatemyGrid()
        {
            // 4. 執行 URP 現代化閃擊！！
            Graphics.RenderMeshInstanced(rp, Mesh, 0, matrices, 1023);
        }
    }

        


    

    public unsafe class AVL_tree
    {
        const int isnull = -1; //AVL樹插入位置
        private int root = isnull; //AVL樹根節點位置
        private int nextindex = 0; //AVL樹下一個可用位置
        private int width = 100; //AVL樹寬度 用於計算插入位置
        public struct AVLnode                       //64byte
        {
            public int index;                     //4byte
            public hashmap.inspection value;       //32byte
            public int height;                    //4byte  
            public int left;                      //4byte              
            public int right;                     //4byte
            long   padding;                    //8byte    
            long   padding2;                   //8byte

        }
            

        public NativeArray<AVLnode> avltree; //宣告AVL樹陣列
        public AVL_tree(int size)
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
                AVLnode node = avltree[index];                                                                   //拷貝一份節點資料
                node.left = insert(avltree[index].left, value);
                avltree[index] = node;

            }
            else if (value.pos.x+value.pos.y*width>avltree[index].value.pos.x+avltree[index].value.pos.y*width)  //插右邊
            {
                AVLnode node = avltree[index];                                                                  //拷貝一份節點資料
                node.right = insert(avltree[index].right, value);
                avltree[index] = node;                                                                          //更新節點資料

            }

            else                                                                        //平衡不用插
            {
                return index;
            }

            updateheight(index);                                                          //更新高度
            return index  = rebalance(index);                                                             //平衡因子檢查與旋轉
                                                                           
        }

        private int updateheight(int index)
        {
            if (index == isnull)
            {
                return index;
            }
            AVLnode node = avltree[index];                                                  //拷貝一份節點資料
            int leftheight = (node.left > isnull) ? 0 : avltree[avltree[index].left].height; //左子樹高度
            int rightheight = (node.right > isnull) ? 0 : avltree[avltree[index].right].height; //右子樹高度
            node.height = 1 + (leftheight > rightheight ? leftheight : rightheight); //更新節點高度
            avltree[index] = node;                                                    //更新節點資料
            return index;
        }
        private int rebalance(int index)
        {
            AVLnode node = avltree[index];                                                  //拷貝一份節點資料
            int balance = avltree[node.left].height-avltree[node.right].height;
            switch (balance)
            {
                case 2:

                    if (avltree[avltree[node.left].left].height-avltree[avltree[node.left].right].height>1)
                    { 
                       int temp = node.left;
                        node.right = temp;
                        node.left = node.right;
                                                
                        index = LL(node.index);
                     }
                    else
                    {
                        LL(index);
                    }
                        

                

                    break;
                case -2:
                    if (avltree[avltree[node.right].left].height - avltree[avltree[node.right].right].height > 1)
                    {
                        int temp = node.right;
                        node.left = temp;
                        node.right = node.left;

                        RR(node.index);
                    }
                    else
                    {
                       RR(index);
                    }   

                    break;
                case 1:
                case 0:
                case -1:
                    break;



            }
            return index;                   //回傳地址
        }

        private int LL(int index)
        {
            int temp = avltree[index].right;                //拷貝一份節點資料
            int templeft = avltree[temp].left;
            AVLnode node = avltree[index];
            temp = templeft;
            node.left = temp;
            avltree[index] = node;                           //更新節點資料

            return index;

        }

        private int RR(int index)
        {
            int temp = avltree[index].left;                //拷貝一份節點資料
            int tempright = avltree[temp].right; 
            AVLnode node = avltree[index];
            temp = tempright;
            node.right = temp;
            avltree[index] = node;                           //更新節點資料

            return index;


        }

        
    }

    public class treemanager
    {
        public struct AVLtree
        {
            public AVL_tree tree;
        }

    }
}
