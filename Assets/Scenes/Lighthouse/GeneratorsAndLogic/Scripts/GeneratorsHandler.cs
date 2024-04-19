using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorHandler : MonoBehaviour
{
    public Text Working;
    public Text NotWorking;
    public int MaxBrokenCount;
    private BasicGenerator[] _inGameGenerators;
    private List<BasicGenerator> _workingGenerators = new();
    private List<BasicGenerator> _brokenGenerators = new();
    public void RepairGenerator(BasicGenerator generator){
        _brokenGenerators.Remove(generator);
        _workingGenerators.Add(generator);
        Debug.Log($"Генератор починен {generator.GetType()} + {generator.GetHashCode()}");
    }
    public void EndGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void Start(){
        _inGameGenerators = GameObject.FindObjectsByType<BasicGenerator>(FindObjectsSortMode.None).ToArray();
        Debug.Log(_inGameGenerators.Length);
        RefreshGenerators();
    }
    private void RefreshGenerators(){
        _workingGenerators = _inGameGenerators.Where(x => x.gameObject.activeSelf).ToList();
        foreach (BasicGenerator generator in _workingGenerators){
        generator.EndGame += EndGame;
        generator.RepairGenerator += RepairGenerator;
        }
        }
    
    private void HandleBreakdowns(){
        if(_brokenGenerators.Count()<MaxBrokenCount && _workingGenerators.Count()>0){
            BasicGenerator broken = _workingGenerators.ElementAt(new System.Random().Next(_workingGenerators.Count()));
            broken.BreakGenerator();
            _brokenGenerators.Add(broken);
            _workingGenerators.Remove(broken);
            Debug.Log($"Генератор сломан {broken.GetType()} + {broken.GetHashCode()}");
        }
    }
    public void Update(){
        HandleBreakdowns();
        Working.text = _workingGenerators.Count().ToString();
        NotWorking.text = _brokenGenerators.Count().ToString();
    }
}