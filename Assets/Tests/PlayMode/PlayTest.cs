using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayTest
{
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        var gameObject = new GameObject();
        KB_Csv kB_Csv = gameObject.AddComponent<KB_Csv>();
        CSV csv = gameObject.AddComponent<CSV>();
        Sylvan_Data_Csv sylvan = gameObject.AddComponent<Sylvan_Data_Csv>();
        Txt_Csv_Helper txt = gameObject.AddComponent<Txt_Csv_Helper>();

        kB_Csv.RunTest();
        csv.RunTest();
        txt.RunTest();
        sylvan.RunTest();
        yield return null;
    }
}
