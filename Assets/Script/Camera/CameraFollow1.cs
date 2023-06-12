using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//[Serializable]对结构体进行序列化，才能显示在 Inspector 层次面板上
//结构体  是值类型
public struct MapBound
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

}
public class CameraFollow1 : MonoBehaviour
{
    public static CameraFollow1 Instance;
    public Transform target; // player的位置
    public float smoothTime = 0.4f;
    private float _offsetZ;
    private Vector3 _currentCelocity;
    public MapBound mapBound;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("找不到玩家");
            return;
        }
        _offsetZ = (transform.position - target.position).z;//z轴之间的距离  保持相机的z轴和角色z轴有距离 否则会重和

    }
    private void FixedUpdate()
    {
        //SmoothDamp随时间推移将一个向量逐渐改变为所需目标。向量通过某个类似于弹簧 - 阻尼的函数（它从不超过目标）进行平滑。 最常见的用法是用于平滑跟随摄像机
        if (target == null) return;
        Vector3 targetPosition = target.position + Vector3.forward * _offsetZ;
        //摄像机偏移的位置
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentCelocity, smoothTime);
        newPosition.x = Mathf.Clamp(newPosition.x, mapBound.xMin, mapBound.xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, mapBound.yMin, mapBound.yMax);
        transform.position = newPosition;
        
    }
  
}
