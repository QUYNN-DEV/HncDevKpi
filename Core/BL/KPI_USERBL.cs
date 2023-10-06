using Core.DL;
using Core.Model;
using System.Collections.Generic;

namespace Core.BL
{
    public class KPI_USERBL
    {
        public static List<KPI_USERModel> Search(KPI_USERModel dtoSearch)
        {
            return KPI_USERDL.Search(dtoSearch);
        }

        public static List<KPI_USERModel> GetAll()
        {
            return Search(new KPI_USERModel());
        }
    }
}
