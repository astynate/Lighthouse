using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yd.Generators.Yd.Generators;
using Yd.Logger;

namespace Yd.Generators
{
    public class GeneratorsController : MonoBehaviour
    {
        public List<BasicGenerator> Generators;
        public List<BasicGenerator> BrokenGenerators = new List<BasicGenerator>();
        public int ActiveGenerators = 0;
        public void GeneratorWasRepaired(BasicGenerator generator)=>BrokenGenerators.Remove(generator);
        public void BreakSomeGenerators(){
            if(BrokenGenerators.Count < ActiveGenerators && BrokenGenerators.Count < 2){
                BasicGenerator generatorToBreak = Generators[Random.Range(0,ActiveGenerators)];
                if(!BrokenGenerators.Contains(generatorToBreak)) BrokenGenerators.Add(generatorToBreak);
            }
            foreach(BasicGenerator generator in BrokenGenerators){
                generator.TryBreak();
            }
        }
        public void RefreshGenerators(int add)
        {
            for (int i = ActiveGenerators; i < ActiveGenerators+add; i++)
            {
                if (!Generators[i].IsActiveOnThisNight)
                {
                    Generators[i].IsActiveOnThisNight = true;
                    Generators[i].IsWorking = true;
                    Generators[i].RepairEvent +=GeneratorWasRepaired;
                    Generators[i].RemoveWall();
                }
            }
            ActiveGenerators += add;
        }
        void Awake()
        {
            Generators = FindObjectsByType<BasicGenerator>(FindObjectsSortMode.None).OrderBy(generator => -generator.Floor).ToList();
            foreach (var generator in Generators)
            {
                OnlyDebugLogger.Log("Найден генератор: " + generator.Floor, generator);
            }
        }
        void Update()
        {
            BreakSomeGenerators();
        }
    }
}