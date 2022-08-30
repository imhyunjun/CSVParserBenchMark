using Sylvan.Data.Csv;
using Sylvan;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Sylvan_Data_Csv : ParserBase
{
    private List<string> headers = new List<string>
    {
        "one","two","three","four","five","six","seven","eight","nine","ten",
        "eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eightteen","nineteen","twenty",
        "twentyone","twentytwo","twentythree","twentyfour","twentyfive"
    };


    public override bool ParseCsv()
    {
        CsvDataReader reader = CsvDataReader.Create(PathString.s_TestData);

        while (reader.Read())
        {
            //TypeParse<string>(reader, stringRecord, (ordinal) => reader.GetString(ordinal));
            //TypeParse<int>(reader, intRecord, (ordinal) => reader.GetInt32(ordinal));
            //TypeParse<bool>(reader, boolRecord, (ordinal) => reader.GetBoolean(ordinal));
            TypeParse<float>(reader, floatRecord, (ordinal) => reader.GetFloat(ordinal));
        }
        return true;
    }

    private void TypeParse<T>(CsvDataReader _reader, List<Record<T>> _list, System.Func<int,T> _GetValueFunc)
    {
        Record<T> record = new Record<T>();
        for (int i = 0; i < _reader.FieldCount; i++)
        {
            string header = headers[i];
            T value = _GetValueFunc(i);
            record.AddValues(header, value);
        }
        _list.Add(record);
    }
}
