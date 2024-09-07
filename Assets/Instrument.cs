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
        Material[] originalMaterials = null;
        action.started += ctx =>
        {
            originalMaterials = renderer.materials;
            var newMaterials = renderer.materials;
            newMaterials[2] = pressedMaterial;

            renderer.materials = newMaterials;
        };
        action.canceled += ctx =>
        {
            renderer.materials = originalMaterials;
        };

    }
}
