using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class Emp
    {
        public int EmpNo { get; set; }         // 员工编号，主键
        public string EName { get; set; }      // 员工姓名
        public string Job { get; set; }        // 职位
        public int? Mgr { get; set; }          // 上级编号（可空）
        public DateTime HireDate { get; set; } // 入职时间
        public decimal Sal { get; set; }       // 工资
        public decimal? Comm { get; set; }     // 奖金（可空）
        public int DeptNo { get; set; }        // 部门编号，外键
    }
}
