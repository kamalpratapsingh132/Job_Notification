using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Notification.Models
{
    public class Add_jobs
    {
        public int ID { get; set; }
        public string job_title {get; set;}

        public int openings { get; set; }

        public string location { get; set; }

        public int salary { get; set; }

        public string must_skills { get; set; }

        public string others_skills { get; set; }

        public string job_description { get; set; }

        public string industry { get; set; }

        public string functional_area { get; set; }
        public string role { get; set; }

        public string employment_type { get; set; }

        public string education { get; set; }

        public string company_name { get; set; }

        public string about_company { get; set; }
    }
}
