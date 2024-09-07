using UnityEngine;
using UnityEngine.InputSystem;

public class Instrument : MonoBehaviour
{
    public Material pressedMaterial;
    public InputActionAsset inputAction;
    public int actionMapIndex;
    public int actionIndex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var playerMap = inputAction.actionMaps[actionMapIndex];
        playerMap.Enable();

        var action = playerMap.actions[actionIndex];

        var renderer = GetComponent<MeshRenderer>();
        Material originalMaterial = null;
        action.started += ctx =>
        {
            originalMaterial = renderer.material;
            renderer.material = pressedMaterial;
        };
        action.canceled += ctx =>
        {
            renderer.material = originalMaterial;
        };

    }
}
