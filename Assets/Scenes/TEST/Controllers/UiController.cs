using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yd.Ui
{
    using UnityEngine.UI;
    using Yd.Generators;
    using Yd.Time;
    public class UiController : MonoBehaviour
    {
        public UnityEngine.UI.Image TimeLeftFill;
        public Text CurrentNight;

        GeneratorsController generatorsController;
        TimeController timeController;
        void Start()
        {
            generatorsController = GetComponent<GeneratorsController>();
            timeController = GetComponent<TimeController>();
        }
        void Update()
        {
            TimeLeftFill.fillAmount = Mathf.InverseLerp(timeController.nightStartTime + timeController.CurrentNight.Duration, timeController.nightStartTime, UnityEngine.Time.time);
            CurrentNight.text = timeController.CurrentNight.NightName + " Night";

        }
    }
}
