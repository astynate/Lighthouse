using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public string Name;

    [SerializeField] public string Description;

    [SerializeField] public Sprite Image;

    [SerializeField] public Sprite Preview;

    [SerializeField] public bool inInvenory = false;

    [SerializeField] public Material glowMaterial;

    private List<Material> originalMaterial;

    private Renderer objectRenderer;

    private bool _prevState = true;

    private ParticleSystem FX;

    void Awake()
    {
        objectRenderer = GetComponentInChildren<Renderer>();
        originalMaterial = objectRenderer.materials.ToList();
        FX = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (inInvenory != _prevState && inInvenory == false)
        {
            EnableGlow();
            _prevState = inInvenory;
        }
        else if (inInvenory != _prevState && inInvenory == true)
        {
            DisableGlow();
            _prevState = inInvenory;
        }
    }

    void EnableGlow()
    {
        List<Material> materials = objectRenderer.materials.ToList();
        materials[0] = glowMaterial;

        objectRenderer.SetMaterials(materials);
        FX.gameObject.SetActive(true);
    }

    void DisableGlow()
    {
        objectRenderer.SetMaterials(originalMaterial);
        FX.gameObject.SetActive(false);
    }

    /// <summary>
    /// Вызывается при нажатии на конопку R
    /// Если объект выделен и только один раз
    /// </summary>
    public abstract void Interact();

    /// <summary>
    /// Вызывается каждый кадр если
    /// объект выделен
    /// </summary>
    public virtual void Selected() { }

    /// <summary>
    /// Вызывается один раз при выделении
    /// объекта
    /// </summary>
    public virtual void OnSelect() { }

    /// <summary>
    /// Вызывается один раз при снятии
    /// выделения с объекта
    /// </summary>
    public virtual void UnSelect() { }
}