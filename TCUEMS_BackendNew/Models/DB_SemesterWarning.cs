namespace TCUEMS_BackendNew.Models
{
    public class SemesterWarning
    {
        public string w_smtr { get; set; }
        public string? advisor { get; set; }
        public string? w_dept_no { get; set; }
        public string? w_degree { get; set; }
        public string? w_class { get; set; }
        public string? w_std_no { get; set; }
        public string? chi_name { get; set; }
        public string? state { get; set; }
        public string? w_cos_id { get; set; }
        public string? w_cos_class { get; set; }
        public string? cos_cname { get; set; }
        public float? cos_credit { get; set; }
        public string? teacher_name { get; set; }
        public string? cos_year { get; set; }
        public string? tch_dept_no { get; set; }
        public string? cos_sel_type { get; set; }
        public string? w_memo { get; set; }
        public string? ins_user { get; set; }
        public string? ins_time { get; set; }
        public string? ins_ip { get; set; }
        public string? print_time { get; set; }
        public string? address { get; set; }
        public string? parent { get; set; }
        public string? w_std_total_credit { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(w_smtr);
        }
    }
}
