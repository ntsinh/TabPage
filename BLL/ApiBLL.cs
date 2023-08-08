using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ApiBLL
    {
        public object getDataForGUI()
        {
            ApiDAL apiDAL = new ApiDAL();
            object data = apiDAL.getData();
            return data;
        }
    }
}
