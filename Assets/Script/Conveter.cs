using System;
using UnityEngine;

public class Conveter : MonoBehaviour
{
    static public Action<Vector3> MBD;
    public Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MBD += Convert;
        Synchronizer.sync += Convert;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    { 
        Input.GetMouseButtonDown(0);
        mousePos = Input.mousePosition;
        mousePos.z = 10f; // 设置一个固定的Z轴距离，以便将屏幕坐标转换为世界坐标
        MBD?.Invoke(mousePos);
    }

    public void Convert(Vector3 MC)
    { 
        MC = Camera.main.ScreenToWorldPoint(MC);
        Datahub.mouseX[0] =(int)MC.x; // 上傳向量到Datahub
        Datahub.mouseY[0] =(int)MC.y;


    }

    
}
