using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using KBCsv;
using System.IO;
using System.Threading.Tasks;

public class KB_Csv : ParserBase
{
    public override bool ParseCsv()
    {
        using (TextReader streamReader = new StreamReader(PathString.s_TestData))
        using (var csvReader = new CsvReader(streamReader))
        {
            csvReader.ReadHeaderRecord();
            int index = 1;
 
            while (csvReader.HasMoreRecords)
            {
                DataRecord record = csvReader.ReadDataRecord();
                //TypeParse<string>(record, stringRecord);
                //TypeParse<int>(record, intRecord);
                //TypeParse<bool>(record, boolRecord);
                TypeParse<float>(record, floatRecord);
                index++;
            }
            return true;
        }
    }

    private void TypeParse<T>(DataRecord _record, List<Record<T>> _list)
    {
        Record<T> record = new Record<T>();
        for (int i = 0; i < _record.HeaderRecord.Count; i++)
        {
            string header = _record.HeaderRecord[i];
            T value = (T)Convert.ChangeType(_record[header], typeof(T));
            record.AddValues(header, value);
        }
        _list.Add(record);
    }
}
