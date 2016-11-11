using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcheManager : MonoBehaviour {

    public Material closedMaterial;
    public Material openMaterial;
    public Material archColorMaterial;

    public Color archColor = Color.white;

    public bool isOppen = false;

    [System.NonSerialized] private MeshRenderer[] meshRenderers;
    [System.NonSerialized] private BoxCollider doorCollider;
    [System.NonSerialized] private MeshRenderer doorMeshRenderer;

    private void OnValidate() {
        if (meshRenderers == null) {
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }
        ColorizeArch();
    }

    private void Awake() {
        if(meshRenderers == null) {
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }
        ColorizeArch();
        doorCollider = GetComponentInChildren<BoxCollider>();
        doorMeshRenderer = doorCollider.GetComponent<MeshRenderer>();
    }

    private void Start() {
        Close();
    }

    private void Update() {
        CheckOpenClose();
    }

    private void ColorizeArch() {
        // Colorize material with arch color
        for (int i = 0; i < meshRenderers.Length; i++) {
            MeshRenderer meshRenderer = meshRenderers[i];

            // Retrieve materials
#if UNITY_EDITOR
            Material[] materials = meshRenderer.sharedMaterials;
#else
            Material[] materials = meshRenderer.materials;
#endif

            // Edit second material
            if (materials.Length < 2) continue;
            Material material = new Material(archColorMaterial);
            material.color = archColor;
            material.SetColor("_EmissionColor", archColor);
            materials[1] = material;

            // Apply changes
#if UNITY_EDITOR
            meshRenderer.sharedMaterials = materials;
#else
            meshRenderer.materials = materials;
#endif
        }
    }

    public void CheckOpenClose() {
        // Check if avreage color matches arch color
        HSVColor averageColorHsv = RoomManager.averageColor;
        HSVColor archColorHsv = archColor;

        // Compare HSV colors
        const float toleranceH = 0.1f;
        const float toleranceS = 0.25f;
        const float toleranceV = 0.25f;
        bool match = true;
        match &= Mathf.Abs(averageColorHsv.h - archColorHsv.h) < toleranceH;
        match &= Mathf.Abs(averageColorHsv.s - archColorHsv.s) < toleranceS;
        match &= Mathf.Abs(averageColorHsv.v - archColorHsv.v) < toleranceV;

        // Refrash door state
        if (match != isOppen) {
            if (match) {
                Open();
            } else {
                Close();
            }
        }
    }

    public void Open() {
        isOppen = true;
        doorCollider.isTrigger = true;
#if UNITY_EDITOR
        doorMeshRenderer.sharedMaterial = openMaterial;
#else
        doorMeshRenderer.material = openMaterial;
#endif
    }

    public void Close() {
        isOppen = false;
        doorCollider.isTrigger = false;
#if UNITY_EDITOR
        doorMeshRenderer.sharedMaterial = closedMaterial;
#else
        doorMeshRenderer.material = closedMaterial;
#endif
    }

}
