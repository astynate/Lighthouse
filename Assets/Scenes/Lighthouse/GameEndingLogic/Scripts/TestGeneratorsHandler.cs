using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestGeneratorHandler : MonoBehaviour
{
    private TestGenerator[] _inGameGenerators;
    public  event Action EndEvent;
    public void EndGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void Start(){
        _inGameGenerators = GameObject.FindObjectsByType<TestGenerator>(FindObjectsSortMode.None);
        Camera camera =  GameObject.FindFirstObjectByType<Camera>();
        foreach (TestGenerator generator in _inGameGenerators){
           generator.EndGame += EndGame;
           generator.workingMessage.worldCamera = camera;
           generator.notWorkingMessage.worldCamera = camera;
        }
    }



}
