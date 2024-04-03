using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private PlayerController _player;

    private Text _stats;

    void Start()
    {
        _player = GameObject.FindWithTag("Player")
            .GetComponent<PlayerController>();

        _stats = GameObject.FindWithTag("Interface")
            .GetComponentsInChildren<Text>()[0];
    }

    void FixedUpdate()
    {
        _stats.text = $"HP: {_player.GetHealthPoints}";
    }
}
