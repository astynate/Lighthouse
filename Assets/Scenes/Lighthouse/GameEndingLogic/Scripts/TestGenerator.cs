using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerator : MonoBehaviour
{
    public float TimeBeforeEnd = 30;
    public float MinDelayBeforeBreakdowns = 100;
    public ParticleSystem particleSystem;
    public UnityEngine.Canvas workingMessage;
    public UnityEngine.Canvas notWorkingMessage;
    public event Action EndGame;
    private bool _isPlayerInside = false;
    private System.Random random= new System.Random();
    private bool _isWorking = true;
    private bool _breakdownEventGoing = false;
    private float _breakdownTime = 0 ;
    private float _breakdownTimeStart;


    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") | _isPlayerInside) return;
        _isPlayerInside = true;
        Debug.Log("Игрок внутри");

    }
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        _isPlayerInside = false;
    }
    private void HandleStateMessage(){
        if(_isWorking && !workingMessage.gameObject.activeSelf ){
            notWorkingMessage.gameObject.SetActive(false);
            particleSystem.gameObject.SetActive(false);
            workingMessage.gameObject.SetActive(true);
        }
        else if(!_isWorking && !notWorkingMessage.gameObject.activeSelf ){
            workingMessage.gameObject.SetActive(false);
            notWorkingMessage.gameObject.SetActive(true);
            particleSystem.gameObject.SetActive(true);
        }
        if(workingMessage.gameObject.activeSelf){
            workingMessage.transform.LookAt(transform.position + workingMessage.worldCamera.transform.rotation * Vector3.forward, workingMessage.worldCamera.transform.rotation * Vector3.up);
        }
        else if(notWorkingMessage.gameObject.activeSelf){
            notWorkingMessage.transform.LookAt(transform.position + workingMessage.worldCamera.transform.rotation * Vector3.forward, workingMessage.worldCamera.transform.rotation * Vector3.up);
        }
    }
    private void HandleBreakdownEvent(){
        if(!_isWorking){

            if(_breakdownEventGoing){
                if(_breakdownTime > TimeBeforeEnd ){
                    Debug.Log("Конец");
                    EndGame.Invoke();
                }
            }
            else{
                _breakdownEventGoing = true;
                _breakdownTimeStart = Time.time;
            }
            _breakdownTime = Time.time-_breakdownTimeStart;
            Debug.Log(_breakdownTime);
        }
        else{_breakdownEventGoing = false;}
    }
    private void HandleRepair(){
        if(_isPlayerInside){
            _isWorking = true;
        }
    }
    void Update()
    {
        if(Time.time-_breakdownTimeStart > MinDelayBeforeBreakdowns && !_breakdownEventGoing){
            _isWorking = 90 < random.Next(100) ;
        }


        HandleStateMessage();
        HandleBreakdownEvent();
        HandleRepair();

    }
}
