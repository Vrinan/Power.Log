using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Power.Controls.Action;
using System.IO;
using Power.WorkFlows.Core.Events;

namespace Power.PMS.WorkFlows
{
    public partial class SetDebugging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";
             
            Power.WorkFlows.Actions.CodesAction codeAction = new Power.WorkFlows.Actions.CodesAction();

            string IsAllCompile = Request["IsAllCompile"];
            bool blnIsAllCompile = IsAllCompile == "true"; 

            codeAction.ProgressSetting += new Power.WorkFlows.Core.Events.ProgressEventHandler(debugAction_DebugSetting);
            beginProgress();

            try
            {
                codeAction.SetIsAllCompile(blnIsAllCompile);

                string sSourcePath = AppDomain.CurrentDomain.BaseDirectory + "/Projects/" + Power.Configure.PowerConfig.CurrentAssemblyCode;
                System.IO.PathHelper.CreatePath(sSourcePath);
                codeAction.SetSourceCodePath(sSourcePath); 
                result = codeAction.CreateCodes();

            }
            catch (XCode.Exceptions.XCodeException ex)
            {
                result = ex.Message.ToString();
                finishProgress(result);
                return;
            }
            finishProgress(result);

        }



        private void debugAction_DebugSetting(object sender, ProgressEventArgs e)
        {
            setProgress(e.Progress, e.MessageInfo);
        }
        private void beginProgress()
        {
            //根据ProgressBar.htm显示进度条界面
            string templateFileName = Path.Combine(Server.MapPath("."), "../Commons/ProgressBar.htm");
            StreamReader reader = new StreamReader(@templateFileName, System.Text.Encoding.GetEncoding("GB2312"));
            string html = reader.ReadToEnd();
            reader.Close();
            Response.Write(html);
            Response.Flush();
        }

        private void setProgress(int percent, string sMessageInfo)
        {
            string jsBlock = "<script>SetPorgressBar('" + percent.ToString() + "','" + sMessageInfo + "'); </script>";
            //  Response.Clear();
            Response.Write(jsBlock);
            Response.Flush();
        }

        private void finishProgress(string result)
        {
            var tmpObj = new { Text = result };
            string sTmp = Newtonsoft.Json.JsonConvert.SerializeObject(tmpObj);
            string jsBlock = "<script> var testobj=" + sTmp + ";SetCompleted();</script>";
            Response.Write(jsBlock);
            Response.Flush();
        }
    }
}