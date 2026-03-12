using UnityEngine;
using Unity.Collections;
using System.Threading;
using Unity.Jobs;
using Myproject;
using JetBrains.Annotations;
using Unity.Mathematics;


public class Gamemanager : MonoBehaviour
{
    const int width = 100; //假設寬度為100   
    public int x;
    public int y;
   // static public ParticleSystem.Particle[] myparticles = new ParticleSystem.Particle[10000]; //宣告粒子陣列大小
  //  static public ParticleSystem.Particle myparticles2 ; //宣告粒子接算出來的數據

    static public NativeHashMap<int,hashmap.inspection> particlepool; //宣告雜湊表 存放粒子位置
    public hashmap myhashmap = new hashmap(); //宣告100*100Grid和拷貝資料到AVL



    // Start is called once before the first execution of Update after the MonoBehaviour is created

   // [SerializeField] private ParticleSystem myParticleSystem; //宣告粒子系統
    void Start()
    {
        datahubmanager(); //宣告資料中心
      
    }

 

    // Update is called once per frame
    void Update()
    {

        myhashmap.UpdatemyGrid(); //更新網格資料 並繪製粒子    
        /*var job = new Manager
            {
            };
            JobHandle handle = job();
            handle.Complete();           */

    }

    public void buffer()
    {
      
    }

    public void hashtable(hashmap.inspection data)
    {
      //particlepool.TryAdd((int)(data.pos.x*73856093)^(int)(data.pos.y*19349663),data); //將粒子資料存入雜湊表 使用位置*大質數作為key
    }
    public void matrix()
    {
      
       // myParticleSystem.SetParticles(myparticles, myparticles.Length);
    }

    public void datahubmanager()
    {

      myhashmap.DrawmyGrid(); //繪製網格 並將細胞資料存入AVL樹

        // matrix(); //計算細胞座標 並將粒子位置設為細胞座標

    }

    public void colormanager()
    {

    }

    public void cellmanager()
    {
    }

    public void OnDestroy()
    {
    }

    public struct Manager:IJobParallelFor
    {
        public NativeArray<int> iscell;
        
        public void Execute(int index)
        {
           
            //在這裡寫細胞的行為
            //例如：iscell[index] = 1; //將細胞狀態設為1
            //colorarray[index] = new color.RGB { R = 255, G = 0, B = 0 }; //將顏色設為紅色
        }
    }
}




/*  0 1 2 3 4 5 6 7 8 910 11 
   0 [][][][][][][][][][][][][][][]     [][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
   1 [][][][][][][][][][][][][][][]    
   2 [][][][][][][][][][][][][][][]     x+y*width    n
   3 [][][][][][][][][][][][][][][]     
   4 [][][][][][][][][][][][][][][]
 
 [] [,] [][]
 
 
    []     
    [][]
    [][][]
    [][][][]
    [][][][][]
    [][][][][][]
 
 
 
 */
