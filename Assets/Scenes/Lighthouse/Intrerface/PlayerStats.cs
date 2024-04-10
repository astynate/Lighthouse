using Assets.Scenes.Lighthouse;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private Text _stats;

    void Start()
    {
        _stats = GameObject.FindWithTag("Interface")
            .GetComponentsInChildren<Text>()[0];
    }

    void Update()
    {
        _stats.text = $"HP: {Configuration.PlayerController.GetHealthPoints}";
    }
}