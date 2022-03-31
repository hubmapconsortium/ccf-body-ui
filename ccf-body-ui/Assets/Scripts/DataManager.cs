using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class DataManager : MonoBehaviour
{
    [SerializeField] DataReader dataReader;
    [SerializeField] private NodeArray nodeArray;

    void Start()
    {
        nodeArray = dataReader.nodeArray;
    }
}