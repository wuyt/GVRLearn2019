using UnityEngine;

/// <summary>
/// 退出应用
/// </summary>
[RequireComponent(typeof(GazeTimmer))]
public class Exit : MonoBehaviour
{
    /// <summary>
    /// 发生点击
    /// </summary>
    private void OnClicked()
    {
        Application.Quit();
    }
}
