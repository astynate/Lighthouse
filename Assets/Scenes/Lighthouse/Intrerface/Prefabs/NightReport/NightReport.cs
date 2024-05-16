using Assets.Scenes.Lighthouse;
using UnityEngine;
using UnityEngine.UI;

public class NightReport : MonoBehaviour
{
    public GameObject ScrollGenerator;
    private Generators[] Generators;

    public Generators[] ChangeGeneratosArray {
        set => Generators = value;
    }

    public void ShowNightReport()
    {
        Debug.Log("вызвается метод показа канвасв");

        Configuration.ReportCanvas.enabled = true;

        GameObject instance = Instantiate(ScrollGenerator);

        instance.transform.SetParent(Configuration.ReportCanvas.transform);
        instance.tag = "ReportItem";

        Transform child1 = instance.transform.GetChild(0);
        Transform child2 = instance.transform.GetChild(1);




        Button childButton = child2.GetComponent<Button>();
        childButton.onClick.AddListener(() => buttonClicked());


        Debug.Log(child1);
    }


    public void buttonClicked()
    {
        Debug.Log("кнопка нажат");
    }


    public void HideNightReport()
    {
        Configuration.ReportCanvas.enabled = false;
    }
}
