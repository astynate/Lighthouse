using Assets.Scenes.Lighthouse;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    private Slider _siler;

    void Start()
    {
        _siler = GetComponent<Slider>();
    }

    void Update()
    {
        _siler.value = Configuration.PlayerController.GetHealthPoints;
    }
}