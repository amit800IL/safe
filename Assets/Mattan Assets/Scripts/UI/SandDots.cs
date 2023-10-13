using UnityEngine;

public class SandDots : MonoBehaviour {
    [SerializeField] private Material sandDotsMaterial;
    [SerializeField] private float materialOffset;
    
    /// <summary>
    /// Change the offset of the material according to the variable materialOffset.
    /// The variable is set through the animator of FillingPot
    /// </summary>
    private void Update() {
        Vector2 newOffset = sandDotsMaterial.GetTextureOffset("_MainTex");
        newOffset.y = materialOffset;
        sandDotsMaterial.SetTextureOffset("_MainTex", newOffset);
    }
}