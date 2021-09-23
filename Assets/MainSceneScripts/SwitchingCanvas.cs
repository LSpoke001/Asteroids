using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCanvas : MonoBehaviour
{
    public static void SetCanvasGroup(CanvasGroup group, bool enabled)
    {
        group.alpha = (enabled ? 1.0f : 0.0f);
    }
}
