using DG.Tweening;
using UnityEngine;

/// <summary>
/// 移动
/// </summary>
[RequireComponent(typeof(GazeTimmer))]
public class Move : MonoBehaviour
{
    /// <summary>
    /// 发生点击
    /// </summary>
    private void OnClicked()
    {
        //目标点
        Vector3 point;

        do
        {
            //获得半径5的球体里随机点
            point = Random.insideUnitSphere * 5;
        }//如果点在脚下则重新获取
        while (point.z > 0
        && point.x > 0.5
        && point.y > 0.5);

        //移动
        transform.DOMove(point, 1.5f);
    }
}
