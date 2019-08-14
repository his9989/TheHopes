using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEMServer.Models
{
    public class User
    {
        public string ObjName { get; set; }
        public string ObjKorName { get; set; }
        public int Edit { get; set; }
        public int CluNo { get; set; }
        public User(string ObjName, string ObjKorName, int Edit, int CluNo)
        {
            this.ObjName = ObjName;
            this.ObjKorName = ObjKorName;
            this.Edit = Edit;
            this.CluNo = CluNo;
        }
    }
}
