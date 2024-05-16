
namespace Yd.Time
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Yd.Generators;
    using Yd.Logger;

    public class TimeController : MonoBehaviour
    {
        public GeneratorsController generatorsController;
        public Night CurrentNight;
        public float nightStartTime;
        public event Action<Night> EndCall;
        private Queue<Night> nights = new Queue<Night>();
        void Awake()
        {
            generatorsController = GetComponent<GeneratorsController>();
            nights.Enqueue(new Night("first", 1, 100));
            nights.Enqueue(new Night("second", 2, 120));
            nights.Enqueue(new Night("third", 2, 180));
        }
        void Start()
        {
            ChangeNight();
        }
        void Update()
        {
            if ((nightStartTime + CurrentNight.Duration) - Time.time < 0)
            {
                ChangeNight();
            }

        }
        void ChangeNight()
        {
            if (nights.Count < 1) return;
            if (CurrentNight != null)
            {
                OnlyDebugLogger.Log("Звонок");
                //EndCall.Invoke(CurrentNight);
            }
            this.CurrentNight = nights.Dequeue();
            nightStartTime = Time.time;
            generatorsController.RefreshGenerators(CurrentNight.AddedHeneratorsCount);
            OnlyDebugLogger.Log($"Количество генераторов: {generatorsController.ActiveGenerators}");
        }
    }
}