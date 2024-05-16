using Yd.Logger;
namespace Yd.Generators
{
    using System;
    using Unity.Mathematics;
    using UnityEngine;

    namespace Yd.Generators
    {
        public abstract class BasicGenerator : MonoBehaviour
        {
            public Transform wall;


            public int MinDelayBetweenBreakdowns =30;
            public bool IsActiveOnThisNight = false;
            public int Floor;
            public bool IsWorking = false;
            public float MaxTimeBroken = 60;
            public float TimeBeforeEnd;
            public event Action GGEvent;
            public event Action<BasicGenerator> RepairEvent;
            public float TimeItWasBroken = 0;
            public bool ItsAboutToBlow = false;
            private float breakdownDelay = 0;


            protected bool isBroken = false;
            protected bool isPLayerInside = false;
            protected void InvokeRepair()
            {
                this.IsWorking = true;
                this.isBroken = false;
                ItsAboutToBlow = false;
                OnlyDebugLogger.Log("генератор был починен", this);
                RepairEvent.Invoke(this);
            }
            public void RemoveWall(){
                this.wall.gameObject.SetActive(false);
            }
            public void TryBreak()
            {
                if (!ItsAboutToBlow)
                {
                    breakdownDelay = UnityEngine.Random.Range(MinDelayBetweenBreakdowns, MinDelayBetweenBreakdowns*2);
                    OnlyDebugLogger.Log($"Генератор был выбран для поломки. Возможная задержка {breakdownDelay}", this);
                    ItsAboutToBlow = true;
                }
                if (Time.time - TimeItWasBroken < breakdownDelay) return;
                this.BreakGenerator();
            }
            private void OnTriggerEnter(Collider other)
            {
                if (other.tag == "Player") isPLayerInside = true;
                OnlyDebugLogger.Log("Игрок внутри", this);
            }
            private void OnTriggerExit(Collider other)
            {
                if (other.tag == "Player") isPLayerInside = false;
                OnlyDebugLogger.Log("Игрок покинул генератор", this);
            }
            public void BreakGenerator()
            {
                TimeItWasBroken = Time.time;
                IsWorking = false;
                OnlyDebugLogger.Log("Генератор сломан", this);
            }
            public abstract void RepairGenerator();
            void Update()
            {
                if (!IsActiveOnThisNight) return;
                if (!IsWorking)
                {
                    RepairGenerator();
                    if (isBroken)
                    {
                        TimeBeforeEnd = (TimeItWasBroken + MaxTimeBroken) - Time.time;
                        if (TimeBeforeEnd < 0) GGEvent.Invoke();
                    }
                    else
                    {
                        TimeItWasBroken = Time.time;
                        isBroken = true;
                    }
                }
            }
        }
    }
}
