using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.AI;

public class DummyAii : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 repairPoint;
    public List<Item> Inventory = new();
    public Vector3 Generator= Vector3.zero;
    public void RepairRandomBroken(){
        if(Generator == Vector3.zero || this.transform.position == Generator){
            Generator = GameObject.FindObjectsByType<BasicGenerator>(FindObjectsSortMode.None).First(generator=>generator.IsWorking==false).transform.position;
        }
        agent.SetDestination(Generator);
    }

    public void Start(){
        agent = GetComponent<NavMeshAgent>();
        Inventory.Add(new ToolKit());
    }
    public void Update(){
        RepairRandomBroken();
    }

}
