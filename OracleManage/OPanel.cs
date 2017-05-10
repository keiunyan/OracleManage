using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OracleManage
{
    class OPanel : System.Windows.Forms.Panel
    {
        public OPanel(string userid, string password, string source)
            : base()
        {
            this.source = source;
            this.userid = userid;
            this.password = password;

            cnnstr = string.Format("User Id={0}; Password={1}; Data Source={2};", userid, password, source);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // TODO: 释放托管状态(托管对象)。
                //
            }

            // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
            // TODO: 将大型字段设置为 null。
            Close();
            System.Windows.Forms.MessageBox.Show("OPanel.Dispose");
            disposed = true;
            base.Dispose(disposing);
        }

        public virtual OracleConnection Open()
        {
            cnn = new OracleConnection(cnnstr);
            try
            {
                cnn.ConnectionString = cnnstr;
                cnn.Open();
                System.Windows.Forms.MessageBox.Show("数据库连接成功");
            }
            catch(OracleException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
            return cnn;
        }

        public virtual void Close()
        {
            System.Windows.Forms.MessageBox.Show("关闭数据库连接");
            if (cnn != null)
            {
                try
                {
                    cnn.Close();
                }
                catch(OracleException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                    
            }

        }

        ~OPanel()
        {
            Dispose(false);
        }

        private bool disposed = false;

        protected string source = "";
        protected string userid = "";
        protected string password = "";
        protected string cnnstr;

        protected OracleConnection cnn = null;
    }
}
