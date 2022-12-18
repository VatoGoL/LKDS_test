using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKDS_test.Model
{
    public class ModelLoggingClass
    {
        private string __file_log_save;
        public ModelLoggingClass(string file_log_save)
        {
            __file_log_save = file_log_save;
        }

        public void Log(string active_object, string method, string status, string message)
        {
            StreamWriter file_stream = new StreamWriter(__file_log_save, true);
            message = "[" + DateTime.Now + "]" + 
                " Object: [" + active_object + "]" +
                " Method: [" + method + "]" +
                " Status: [" + status + "]" +
                " Message: [" + message + "]";
            file_stream.WriteLine(message);
            file_stream.Close();
        }
    }
}
