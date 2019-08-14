using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PEMServer.Models;


namespace PEMServer.IRepository
{
    public interface IClusteredDataRepository
    {
        List<ClusteredData> GetClusteredDatas();
        string InsertClusteredData(ClusteredData clusteredData);    //성용이의 Insert
        string DeleteClusteredData(ClusteredData clusteredData);    //은석이의 Delete
    }
}
