using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TxtCsvHelper;
using System.IO;
using System.Linq;

public class Txt_Csv_Helper : ParserBase
{
    int index = 1;
    List<string> headers = new List<string>();
    public override bool ParseCsv()
    {
        index = 1;

        using (var reader = new StreamReader(PathString.s_TestData))
        using (var txt = new Parser(delimiter:",", hasHeader: true))
        {           
            while (reader.Peek() >= 0)
            {
                List<string> strings = txt.SplitLine(reader.ReadLine()).ToList();
                //헤더 라인
                if (index == 1)
                {
                    headers = strings;
                    index++;
                    continue;
                }

                //TypeParse<string>(strings, stringRecord);
                //TypeParse<int>(strings, intRecord);
                //TypeParse<bool>(strings, boolRecord);
                TypeParse<float>(strings, floatRecord);
                index++;
            }
            return true;
        }
    }

    private void TypeParse<T>(List<string> _strings, List<Record<T>> _list)
    {
        Record<T> record = new Record<T>();
        List<T> values = _strings.ConvertAll(x => (T)System.Convert.ChangeType(x, typeof(T)));
        for(int i = 0; i < values.Count; i++)
        {
            record.AddValues(headers[i], values[i]);
        }
        _list.Add(record);
    }
}
