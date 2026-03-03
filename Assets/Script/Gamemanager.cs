using UnityEngine;
using Unity.Collections;
using System.Threading;
using Unity.Jobs;
using Myproject;
using JetBrains.Annotations;


public class Gamemanager : MonoBehaviour
{
    public Datahub Mygame;
    public color Mycolor;
    public cell Mycell;
    public pos Mypos;
    const int width = 100; //假設寬度為100   
    public int x;
    public int y;
    static public ParticleSystem.Particle[] myparticles = new ParticleSystem.Particle[10000]; //宣告粒子陣列大小
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private ParticleSystem myParticleSystem; //宣告粒子系統
    void Start()
    {
        Mygame = new Datahub();
         Mygame.coordinate(10000); //宣告細胞陣列大小 不回收
        Mycolor = new color();
            Mycolor.colorcoordinate(2); //宣告顏色陣列大小 不回收
        Mycell = new cell();
        Mypos = new pos();

          matrix(); //計算細胞座標 並將粒子位置設為細胞座標

    }

 

    // Update is called once per frame
    void Update()
    {
        var job = new Manager
            {
                iscell = Mygame.iscell,
                colorarray = Mycolor.colorarray
            };
            JobHandle handle = job.Schedule(Mygame.iscell.Length, 64);
            handle.Complete();

    }

    public void matrix()
    {
        for (int i = 0; i<Mygame.iscell.Length; i++)
        { 
          x = i% width; //計算x座標
          y = i/ width; //計算y座標
          myparticles[i].position = new Vector3(x, y, 0); //將粒子位置設為(x,y,0)
          myparticles[i].startColor =  new Color32(191, 64, 255, 255); //將粒子顏色設為紫色
          myparticles[i].startSize = 0.1f; //將粒子大小設為0.1
          myparticles[i].remainingLifetime = Mathf.Infinity; //將粒子生命週期設為無限
        }
        myParticleSystem.SetParticles(myparticles, myparticles.Length);
    }

    public void datahubmanager()
    { 
        
    }

    public void colormanager()
    {

    }

    public void cellmanager()
    {
    }

    public void OnDestroy()
    {
        Mygame.iscell.Dispose(); //回收細胞陣列
        Mycolor.colorarray.Dispose(); //回收顏色陣列
    }

    public struct Manager:IJobParallelFor
    {
        public NativeArray<int> iscell;
        public NativeArray<color.RGB> colorarray;
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
