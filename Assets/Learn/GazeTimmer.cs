using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

/// <summary>
/// 注视计时
/// </summary>
public class GazeTimmer : MonoBehaviour
{
    /// <summary>
    /// 圆圈的材质
    /// </summary>
    private Material material;
    /// <summary>
    /// DOTween
    /// </summary>
    private Tween tween;

    void Start()
    {
        //添加 Event Trigger
        EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();

        //添加 Point Enter 事件响应
        UnityAction<BaseEventData> enter = new UnityAction<BaseEventData>(PointerEnter);
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener(enter);
        eventTrigger.triggers.Add(pointerEnter);

        //添加 Point Exit 事件响应
        UnityAction<BaseEventData> exit = new UnityAction<BaseEventData>(PointerExit);
        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener(exit);
        eventTrigger.triggers.Add(pointerExit);
    }
    /// <summary>
    /// 退出事件响应
    /// </summary>
    /// <param name="data"></param>
    public void PointerExit(BaseEventData data)
    {
        Debug.Log("Exit");
        tween.Kill();
        GetMaterial();
        material.color = Color.white;
    }
    /// <summary>
    /// 进入事件响应
    /// </summary>
    /// <param name="data"></param>
    public void PointerEnter(BaseEventData data)
    {
        Debug.Log("enter");
        GetMaterial();
        tween = material.DOColor(Color.green, 2)//2秒变成绿色
            .SetDelay(1f)//等待1秒
            .OnComplete(TweenComplete);//完成后执行TweenComplete方法
    }
    /// <summary>
    /// 动画完成
    /// </summary>
    private void TweenComplete()
    {
        SendMessage("OnClicked",SendMessageOptions.DontRequireReceiver);
    }
    /// <summary>
    /// 获取材质对象
    /// </summary>
    private void GetMaterial()
    {
        if (material == null)
        {
            material = FindObjectOfType<GvrReticlePointer>()
                .GetComponent<Renderer>().material;
        }
    }
}
