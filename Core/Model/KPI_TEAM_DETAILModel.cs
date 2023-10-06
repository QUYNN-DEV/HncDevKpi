using System;

namespace Core.Model
{
    public partial class KPI_TEAM_DETAILModel
    {
        public Int32 ID { get; set; }

        public String EMPLOYER_CODE { get; set; }

        public DateTime NGAY_THUC_HIEN { get; set; }

        public String CONG_VIEC { get; set; }

        public Int32 GIO_THUC_HIEN { get; set; }

        public String DON_VI_THOI_GIAN { get; set; }

        public Int32 TY_LE_HOAN_THANH { get; set; }

        public String LY_DO { get; set; }

        public String DANH_GIA { get; set; }

        public String GHI_CHU { get; set; }

        public DateTime INSERT_DATE { get; set; }

        public DateTime INSERT_TIME { get; set; }

        public String INSERT_USER { get; set; }

        public DateTime UPDATE_DATE { get; set; }

        public DateTime UPDATE_TIME { get; set; }

        public String UPDATE_USER { get; set; }

        public bool SELECT { get; set; }

        public string GIO_THUC_HIEN_STRING { get; set; }

        public string EMPLOYER_NAME { get; set; }

        public string TEAM { get; set; }

        public string TY_LE_PHAN_TRAM { get; set; }
    }
}
