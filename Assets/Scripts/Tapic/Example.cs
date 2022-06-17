using UnityEngine;
public class Example : MonoBehaviour
{
    public void TriggerTaptic(string type)
    {
#if !UNITY_EDITOR
        if (type == "warning")
        {
            AndroidTaptic.Haptic(HapticTypes.Warning);
        }
        else if (type == "failure")
        {
            AndroidTaptic.Haptic(HapticTypes.Failure);
        }
        else if (type == "success")
        {
            AndroidTaptic.Haptic(HapticTypes.Success);
        }
        else if (type == "light")
        {
            AndroidTaptic.Haptic(HapticTypes.LightImpact);
        }
        else if (type == "medium")
        {
            AndroidTaptic.Haptic(HapticTypes.MediumImpact);
        }
        else if (type == "heavy")
        {
            AndroidTaptic.Haptic(HapticTypes.HeavyImpact);
        }
        else if (type == "default")
        {
            Handheld.Vibrate();
        }
        else if (type == "vibrate")
        {
            AndroidTaptic.Vibrate();
        }
        else if (type == "selection")
        {
            AndroidTaptic.Haptic(HapticTypes.Selection);
        }
#endif
    }
}