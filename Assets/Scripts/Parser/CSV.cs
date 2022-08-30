using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Csv;

public class CSV : ParserBase
{
    public override bool ParseCsv()
    {
        var csv = File.ReadAllText(PathString.s_TestData);

        foreach (var line in CsvReader.ReadFromText(csv))
        {
            //TypeParse<string>(line, stringRecord);
            //TypeParse<int>(line, intRecord);
            //TypeParse<bool>(line, boolRecord);
            TypeParse<float>(line, floatRecord);
        }

        return true;
    }

    private void TypeParse<T>(ICsvLine _line, List<Record<T>> _list)
    {
        Record<T> record = new Record<T>();
        for (int i = 0; i < _line.Headers.Length; i++)
        {
            string header = _line.Headers[i];
            T value = (T)Convert.ChangeType(_line[header], typeof(T));
            record.AddValues(header, value);
        }
        _list.Add(record);
    }
}
