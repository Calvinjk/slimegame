using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities{
    /// <summary>
    /// Given gravity and desired height, returns the force necessary to apply to that object to reach the desired height
    /// </summary>
    public static float CalculateJumpForce(float gravity, float height) {
        return Mathf.Sqrt(2 * gravity * height);
    }
}
