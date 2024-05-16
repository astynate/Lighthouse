using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yd.Generators;
using Yd.Logger;

namespace Yd.Time
{
    public class MainController : MonoBehaviour
    {
        public GeneratorsController generatorsController;
        void EndGame()
        {
            #if UNITY_EDITOR
            OnlyDebugLogger.Log("Игра окончена");
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
        void Awake()
        {
            generatorsController = GetComponent<GeneratorsController>();
        }
        void Start()
        {
            ConnectEndGameEvents();
        }
        void Update()
        {

        }
        void ConnectEndGameEvents(){
            foreach (var generator in generatorsController.Generators)
            {
                generator.GGEvent += EndGame;
                OnlyDebugLogger.Log($"Генератор [{generator.Floor}] подключен",generator);
            }
        }
    }
}
