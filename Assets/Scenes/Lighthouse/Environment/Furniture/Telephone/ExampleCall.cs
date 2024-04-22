using Assets.Scenes.Lighthouse;
using UnityEngine;

public class ExampleCall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!Configuration.isCall)
        {
            //TelephoneScript phone = GameObject.FindGameObjectWithTag("Telephone").GetComponent<TelephoneScript>();
            //phone.Calling();
            //Configuration.isCall = true;
        }
    }
}
