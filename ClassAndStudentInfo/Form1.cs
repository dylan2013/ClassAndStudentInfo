using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using K12.Data;
using SHSchool.Data;

namespace ClassAndStudentInfo
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //資料收集:
            //取得所有狀態為一般與延修的學生
            //List<SHStudentRecord> StudentList = GetAllStudent();

            //取得班級資訊
            //Dictionary<string, SHClassRecord> ClassDic = GetClassDic();

            //取得科別資料
            //Dictionary<string, SHDepartmentRecord> DepartmentDic = GetDepartment();

            FISCA.Data.QueryHelper _Q = new FISCA.Data.QueryHelper();
            DataTable dt = _Q.Select("select student.id,student.name,student.ref_class_id,student.status,seat_no,gender,class_name,dept.name as dept_name from student join class on student.ref_class_id=class.id join dept on class.ref_dept_id=dept.id");
            List<StudentObj> StudentList = new List<StudentObj>();
            foreach(DataRow row in dt.Rows)
            {
                StudentObj obj = new StudentObj(row);
                StudentList.Add(obj);
            }

            //資料整理
            List<SummaryRow> RowList = new List<SummaryRow>();


            //資料列印








            //資料儲存



        }

        /// <summary>
        /// 取得科別字典
        /// </summary>
        private Dictionary<string, SHDepartmentRecord> GetDepartment()
        {
            Dictionary<string, SHDepartmentRecord> dic = new Dictionary<string, SHDepartmentRecord>();
            foreach (SHDepartmentRecord depa in SHDepartment.SelectAll())
            {
                if (!dic.ContainsKey(depa.ID))
                {
                    dic.Add(depa.ID, depa);
                }
            }
            return dic;

        }

        /// <summary>
        /// 取得全校班級字典
        /// </summary>
        private Dictionary<string, SHClassRecord> GetClassDic()
        {
            Dictionary<string, SHClassRecord> dic = new Dictionary<string, SHClassRecord>();
            foreach (SHClassRecord _class in Class.SelectAll())
            {
                if (!dic.ContainsKey(_class.ID))
                {
                    dic.Add(_class.ID, _class);
                }
            }
            return dic;
        }

        /// <summary>
        /// 取得一般與延修生
        /// </summary>
        private List<SHStudentRecord> GetAllStudent()
        {
            List<SHStudentRecord> list = new List<SHStudentRecord>();
            foreach (SHStudentRecord stud in Student.SelectAll())
            {
                if (stud.Status == SHStudentRecord.StudentStatus.一般 || stud.Status == SHStudentRecord.StudentStatus.延修)
                {
                    list.Add(stud);
                }
            }
            return list;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
