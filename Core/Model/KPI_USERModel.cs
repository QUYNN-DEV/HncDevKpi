using System;

namespace Core.Model
{
    public partial class KPI_USERModel
    {
        public Int32 ID { get; set; }

        public String EMPLOYER_CODE { get; set; }

        public String EMPLOYER_NAME { get; set; }

        public String TEAM { get; set; }

        public DateTime INSERT_DATE { get; set; }

        public DateTime INSERT_TIME { get; set; }

        public String INSERT_USER { get; set; }

        public Boolean TEAM_LEAD { get; set; }

        public string ASANA_ID { get; set; }
    }
}
