using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PEMServer.Models;

namespace PEMServer.IRepository
{
    public interface IRawDataRepository
    {
        List<RawData> GetRawDatas(string ObjName);
        List<RawData> GetRawDatas(string ObjName, string Time);
        int GetRawDatasCount(string ObjName);

        string InsertRawDatas(string ObjName, RawData rawData);     //경수형의 Insert
    }
}
