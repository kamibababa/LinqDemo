namespace LinqDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string msg = "this is a book that is a desk";
            //string[] arr = msg.Split(" ");
            //Dictionary<string, int> dic = arr.GroupBy(item => item).OrderByDescending(g => g.Count()).ToDictionary(g => g.Key, g => g.Count()) ;
            //foreach (var item in dic)
            //{
            //    Console.WriteLine($"{item.Key} --- {item.Value}");
            //}

            var deptList = new List<Dept>
            {
                new Dept { DeptNo = 10, DName = "ACCOUNTING", Loc = "NEW YORK" },
                new Dept { DeptNo = 20, DName = "RESEARCH",   Loc = "DALLAS" },
                new Dept { DeptNo = 30, DName = "SALES",      Loc = "CHICAGO" },
                new Dept { DeptNo = 40, DName = "OPERATIONS", Loc = "BOSTON" }
            };

            var empList = new List<Emp>
            {
                new Emp { EmpNo = 7839, EName = "KING",    Job = "PRESIDENT", Mgr = null,    HireDate = new DateTime(1981,11,17), Sal = 5000m, Comm = null, DeptNo = 10 },
                new Emp { EmpNo = 7698, EName = "BLAKE",   Job = "MANAGER",   Mgr = 7839,    HireDate = new DateTime(1981,5,1),   Sal = 2850m, Comm = null, DeptNo = 30 },
                new Emp { EmpNo = 7782, EName = "CLARK",   Job = "MANAGER",   Mgr = 7839,    HireDate = new DateTime(1981,6,9),   Sal = 2450m, Comm = null, DeptNo = 10 },
                new Emp { EmpNo = 7566, EName = "JONES",   Job = "MANAGER",   Mgr = 7839,    HireDate = new DateTime(1981,4,2),   Sal = 2975m, Comm = null, DeptNo = 20 },
                new Emp { EmpNo = 7788, EName = "SCOTT",   Job = "ANALYST",   Mgr = 7566,    HireDate = new DateTime(1982,12,9),  Sal = 3000m, Comm = null, DeptNo = 20 },
                new Emp { EmpNo = 7902, EName = "FORD",    Job = "ANALYST",   Mgr = 7566,    HireDate = new DateTime(1981,12,3),  Sal = 3000m, Comm = null, DeptNo = 20 },
                new Emp { EmpNo = 7844, EName = "TURNER",  Job = "SALESMAN",  Mgr = 7698,    HireDate = new DateTime(1981,9,8),   Sal = 1500m, Comm = 0m,    DeptNo = 30 },
                new Emp { EmpNo = 7900, EName = "JAMES",   Job = "CLERK",     Mgr = 7698,    HireDate = new DateTime(1981,12,3),  Sal = 950m,  Comm = null, DeptNo = 30 },
                new Emp { EmpNo = 7654, EName = "MARTIN",  Job = "SALESMAN",  Mgr = 7698,    HireDate = new DateTime(1981,9,28),  Sal = 1250m, Comm = 1400m, DeptNo = 30 },
                new Emp { EmpNo = 7499, EName = "ALLEN",   Job = "SALESMAN",  Mgr = 7698,    HireDate = new DateTime(1981,2,20),  Sal = 1600m, Comm = 300m,  DeptNo = 30 },
                new Emp { EmpNo = 7521, EName = "WARD",    Job = "SALESMAN",  Mgr = 7698,    HireDate = new DateTime(1981,2,22),  Sal = 1250m, Comm = 500m,  DeptNo = 30 },
                new Emp { EmpNo = 7934, EName = "MILLER",  Job = "CLERK",     Mgr = 7782,    HireDate = new DateTime(1982,1,23),  Sal = 1300m, Comm = null, DeptNo = 10 },
                new Emp { EmpNo = 7876, EName = "ADAMS",   Job = "CLERK",     Mgr = 7788,    HireDate = new DateTime(1983,1,12),  Sal = 1100m, Comm = null, DeptNo = 20 },
                new Emp { EmpNo = 7369, EName = "SMITH",   Job = "CLERK",     Mgr = 7902,    HireDate = new DateTime(1980,12,17), Sal = 800m,  Comm = null, DeptNo = 20 }
            };

            //var lst = empList.Select(e => new {e.EName, e.Sal });
            //var lst = empList.Where(e => e.Sal > 2000);
            //var lst = empList.Where(e => e.HireDate.Year == 1981);
            //var lst = empList.Where(e => e.Comm != null);
            //var lst = empList.OrderByDescending(e => e.Sal);
            //var lst = empList.GroupBy(e => e.DeptNo).Select(g => new { DeptNo = g.Key, avgsal = g.Average(e=>e.Sal) });
            //var lst = empList.GroupBy(e => e.DeptNo).Select(g => new { DeptNo = g.Key, maxsal = g.Max(e => e.Sal) });
            //var lst = empList.GroupBy(e => e.Job).Select(g => new { job = g.Key, count = g.Count() });

            //var lst = empList.Join(deptList,
            //    e => e.DeptNo,
            //    d => d.DeptNo,
            //    (e, d) => new { e.EName, d.DName, d.Loc });

            //var lst = empList.Join(empList,
            //    e => e.Mgr,
            //    m => m.EmpNo,
            //    (e, m) => new { e.EName, MgrName = m.EName });



            //decimal sal = empList.Where(e => e.EName.Equals("ALLEN")).Select(e => e.Sal).FirstOrDefault();
            //var lst = empList.Where(e => e.Sal > sal);

            //列出所有部门的详细信息和部门人数
            var dept_count_lst = empList.GroupBy(e => e.DeptNo).Select(g => new { Deptno = g.Key, count = g.Count() });
            var lst = deptList.Join(dept_count_lst,
                d => d.DeptNo,
                dc => dc.Deptno,
                (d,dc)=> new {d.DeptNo, d.DName, d.Loc, dc.count}
                );


            foreach (var item in lst)
            {
                Console.WriteLine(item.DeptNo + " " + item.DName + " " + item.Loc + " " + item.count);
            }


        }
    }
}
