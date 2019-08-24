using Buffalo.DB.CommBase.BusinessBases;
using Buffalo.DB.DBCheckers;
using Buffalo.DB.DbCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLib.BQLEntity;

namespace DBUpdate
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        List<string> _lstSql = null;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _lstSql = TestDB.GetDBinfo().CheckDataBase();
            txtSQL.AppendText("======" + TestDB.GetDBinfo().Name+ "=========\r\n\r\n");
            foreach (string sql in _lstSql)
            {
                txtSQL.AppendText(sql + ";\r\n");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<string> resault = DBChecker.ExecuteSQL(TestDB.GetDBinfo().DefaultOperate, _lstSql);
            StringBuilder sbRet = new StringBuilder();

            foreach (string res in resault)
            {
                sbRet.AppendLine(res);
            }
            txtOut.Text = sbRet.ToString();
        }
    }
}
