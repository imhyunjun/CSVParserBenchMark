using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParserBase : MonoBehaviour
{


    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    public bool runTest;
    protected string parserName;
    protected int testCount;
    protected const int MaxTestCount = 100;
    protected float averageTime;

    [SerializeField] protected List<Record<string>> stringRecord;
    [SerializeField] protected List<Record<int>> intRecord;
    [SerializeField] protected List<Record<bool>> boolRecord;
    [SerializeField] protected List<Record<float>> floatRecord;

    public abstract bool ParseCsv();
    protected virtual void Awake()
    {
        parserName = this.GetType().Name;
    }

    protected void Start()
    {
        if (runTest)
            RunTest();
    }

    public void RunTest()
    {
        testCount = 0;
        long testResult = 0;
        long startTime = 0;
        while (testCount < MaxTestCount)
        {
            testCount++;

            startTime = sw.ElapsedMilliseconds;
            sw.Start();

            InitializeList();
            ParseCsv();

            sw.Stop();

            testResult = sw.ElapsedMilliseconds - startTime;
            averageTime = (averageTime * (testCount - 1) + testResult) / testCount;
        }

        Debug.Log($"{parserName} : {averageTime} ¹Ð¸®ÃÊ");
    }

    private void InitializeList()
    {
        stringRecord = new List<Record<string>>();
        intRecord = new List<Record<int>>();
        boolRecord = new List<Record<bool>>();
        floatRecord = new List<Record<float>>();
    }
}

[System.Serializable]
public class Record<T>
{
    Dictionary<string, T> dictionary = new();

    public void AddValues(string _header, T _value)
    {
        if(dictionary.ContainsKey(_header))
        {
            dictionary[_header] = _value;
            return;
        }

        dictionary.Add(_header, _value);
    }
}
