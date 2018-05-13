using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empBusiness
{
  public  class empBusinessClass
    {
        public static void businessMethod(empModel.empModelClass empMv)
        {
            empData.empDataClass.dataMethod(empMv);
        }
    }
}
