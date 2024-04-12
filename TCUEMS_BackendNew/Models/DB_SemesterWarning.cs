namespace TCUEMS_BackendNew.Models
{
    public class SemesterWarning
    {
        //public  string w_smtr { get; set; }
        //public string? w_std_no { get; set; }
        //public string? chi_name { get; set; }
        //public string? st_state { get; set; }
        //public  string dept_name_s { get; set; }
        //public string? degree { get; set; }
        //public string? sw_class { get; set; }

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
        public string? cos_type { get; set; }
        public string? w_memo { get; set; }
        public string? ins_user { get; set; }
        public string? ins_time { get; set; }   //datetime
        public string? ins_ip { get; set; }
        public string? print_time { get; set; }  //datetime
        public string? address { get; set; }
        public string? parent { get; set; }
        public string? w_std_total_credit { get; set; }

    //public bool IsValid()
    //{
    //    // 在這裡添加你的檢查邏輯，檢查是否包含不正確的數據
    //    // 如果數據有效，返回 true；否則返回 false
    //    return !string.IsNullOrEmpty(dept_name_s) && !string.IsNullOrEmpty(w_smtr);
    //}

    public bool IsValid()
        {
            // 在这里添加你的检查逻辑，检查是否包含不正确的数据
            // 如果数据有效，返回 true；否则返回 false
            return !string.IsNullOrEmpty(w_smtr);
                   //!string.IsNullOrEmpty(advisor) &&
                   //!string.IsNullOrEmpty(w_dept_no) &&
                   //!string.IsNullOrEmpty(w_degree) &&
                   //!string.IsNullOrEmpty(w_std_no) &&
                   //!string.IsNullOrEmpty(chi_name) &&
                   //!string.IsNullOrEmpty(w_cos_id) &&
                   //!string.IsNullOrEmpty(w_cos_class) &&
                   //!string.IsNullOrEmpty(cos_cname) &&
                   //cos_credit > 0; //&& // 课程学分应大于0
                   //!string.IsNullOrEmpty(teacher_name) &&
                   //!string.IsNullOrEmpty(cos_year) &&
                   //!string.IsNullOrEmpty(tch_dept_no) &&
                   //!string.IsNullOrEmpty(cos_type) &&
                   //!string.IsNullOrEmpty(w_memo) &&
                   //!string.IsNullOrEmpty(ins_user) &&
                   //!string.IsNullOrEmpty(ins_time) &&
                   //!string.IsNullOrEmpty(ins_ip); //&&
                   //!string.IsNullOrEmpty(print_time) &&
                   //!string.IsNullOrEmpty(address) &&
                   //!string.IsNullOrEmpty(parent);
        }
    }
}
