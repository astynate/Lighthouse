using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yd.TimeSystem;

namespace Yd.Generators
{
    public class GeneratorsHandler : MonoBehaviour
    {

        public int ActiveGenerators = 0;
        public Night CurrentNight;

        BasicGenerator[] generatorsOnMap;
        private Queue<Night> nights = new Queue<Night>();
        private float TimeNightStarted;

        void Awake()
        {
            nights.Enqueue(new Night("First", 1, 180));
            nights.Enqueue(new Night("Second", 2, 180));
            nights.Enqueue(new Night("Third", 2, 180));
            nights.Enqueue(new Night("Fourth", 2, 180));

            generatorsOnMap = FindObjectsByType<BasicGenerator>(FindObjectsSortMode.InstanceID);
        }
        void ChangeNight()
        {
            TimeNightStarted = Time.time;
            CurrentNight = nights.Dequeue();

            for(int i = ActiveGenerators; i < ActiveGenerators+CurrentNight.MaxBrokenGenerators;i++){
                generatorsOnMap[i].IsActive = true;
            }
        }


        void Start()
        {
            ChangeNight();
        }
        void Update()
        {
            if(CurrentNight.Duration - (Time.time - TimeNightStarted) < 0){
                ChangeNight();
            }
        }

        }
    }