using Assets.Scenes.Lighthouse;
using UnityEngine;

public class ExampleCall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!Configuration.isCall)
        {
            TelephoneScript phone = GameObject.FindGameObjectWithTag("Phone").GetComponent<TelephoneScript>();
            phone.Calling();
            Configuration.isCall = true;
        }
    }
}
