using Assets.Scenes.Lighthouse;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Note : Item
{
    public Sprite noteSprite;

    private Image _image;

    private void Start()
    {
        _image = GameObject.FindWithTag("NoteImage")
            .GetComponent<Image>();
    }

    public override void Interact()
    {
        Configuration.NoteCanvas.enabled = !Configuration.NoteCanvas.enabled; 
        _image.sprite = noteSprite;
        GameObject.FindWithTag("NoteName").GetComponent<TextMeshPro>().text = Name;
        GameObject.FindWithTag("NoteDesc").GetComponent<TextMeshPro>().text = Description;
    }
}