using Power.Business;
using Power.Controls.PMS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Power.ISystems.IMessageService.Excel;
using Power.IBaseCore;
using Power.Global;
namespace Power.Control.StdExcel
{
    public class ExcelMergeInfo
    {
        public ExcelMergeInfo()
        {

        }
        public ExcelMergeInfo(ExcelMergeInfo info)
        {
            this.mergeColumn = info.mergeColumn;
            this.mergeField = info.mergeField;
            this.firstRow = info.firstRow;
            this.firstColumn = info.firstColumn;
            this.totalRows = info.totalRows;
            this.totalColumns = info.totalColumns;
        }
        public string mergeColumn { get; set; }
        public string mergeField { get; set; }
        public int firstRow { get; set; }
        public int firstColumn { get; set; }
        public int totalRows { get; set; }
        public int totalColumns { get; set; }
    }
    public class StdExcel : BaseControl
    {
        private string DataTableToExcel(ExcelExportMessageServiceModel messageObject)
        {
            DataTable datatable = messageObject.datatable;
            string fileName = messageObject.fileName;
            string excelColumns = messageObject.excelColumns;
            string menuid = messageObject.menuid;
            string headercolor = messageObject.headcolor;
            string headerfontcolor = messageObject.headfontcolor;
            bool ispdf = messageObject.ispdf;
            string[] mergeColumns = messageObject.mergeColumns;
            List<ExcelMergeInfo> mergeInt = new List<ExcelMergeInfo>();//记录向下合并的列的位置

            string error = "";
            if (datatable == null)
            {
                error = "DataTableToExcel:datatable " + Power.Global.Utility.GetResource("sync_not_null");//不能为空
                return error;
            }
            //表头行数

            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            int rowIndex = 0;
            List<Hashtable> xlsCols = new List<Hashtable>();
            try
            {
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet xslSheet = wb.Worksheets[0];
                Aspose.Cells.Cells xlsCells = xslSheet.Cells;
                //为单元格添加样式    
                Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                //设置居中
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;

                //设置背景颜色

                //如果定义了表头颜色，则用表头的颜色，格式为255,255,255
                if (headercolor != "")
                {
                    string[] rgb = headercolor.Split(',');
                    if (rgb.Length != 3)
                        throw new Exception("非法的表头背景色：" + headercolor + "，需要RGB的颜色设置，如：255,255,255");
                    try
                    {

                        int r = int.Parse(rgb[0]);
                        int g = int.Parse(rgb[1]);
                        int b = int.Parse(rgb[2]);
                        style.ForegroundColor = System.Drawing.Color.FromArgb(r, g, b);
                    }
                    catch (Exception)
                    {
                        throw new Exception("非法的表头背景色：" + headercolor + "，需要RGB的颜色设置，如：255,255,255");
                    }
                }
                else
                    style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = Aspose.Cells.BackgroundType.Solid;
                style.Font.IsBold = true;
                //如果定义了表头字体颜色，则用表头字体颜色
                if (headerfontcolor != "")
                {
                    string[] rgb = headerfontcolor.Split(',');
                    if (rgb.Length != 3)
                        throw new Exception("非法的表头字体色：" + headerfontcolor + "，需要RGB的颜色设置，如：255,255,255");
                    try
                    {

                        int r = int.Parse(rgb[0]);
                        int g = int.Parse(rgb[1]);
                        int b = int.Parse(rgb[2]);
                        style.Font.Color = System.Drawing.Color.FromArgb(r, g, b);
                    }
                    catch (Exception)
                    {
                        throw new Exception("非法的表头字体色：" + headerfontcolor + "，需要RGB的颜色设置，如：255,255,255");
                    }
                }
                int headercount = 1;//表头行数，多表头时，冻结多行
                #region 没有传入 excelColumns，使用 Datatable 列名作为xls列头
                if (string.IsNullOrEmpty(excelColumns))
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        DataColumn col = datatable.Columns[i];
                        string columnName = col.Caption ?? col.ColumnName;
                        if (mergeColumns != null && mergeColumns.Contains(columnName))
                        {
                            ExcelMergeInfo me = new ExcelMergeInfo();
                            me.mergeColumn = columnName;
                            me.mergeField = columnName;
                            me.firstColumn = i;
                            me.firstRow = 1;
                            me.totalColumns = 1;
                            me.totalRows = 1;
                            if (!mergeInt.Contains(me))
                                mergeInt.Add(me);
                        }
                        xlsCells[rowIndex, i].PutValue(columnName);
                        xlsCells[rowIndex, i].SetStyle(style);
                        Hashtable item = new Hashtable();
                        item.Add("field", col.ColumnName);
                        item.Add("colIndex", i);
                        xlsCols.Add(item);
                    }
                }
                #endregion

                #region 解析excelColumns生成xls列头
                if (!string.IsNullOrEmpty(excelColumns))
                {
                    //补充列样式,上、下、左、右 边框线
                    style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;

                    List<Hashtable> json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hashtable>>(excelColumns);

                    #region tree转换成list(顺序从上到下，从左到右), level 从0开始
                    Func<Hashtable, int, int> FnTreeToList = null;
                    FnTreeToList = delegate (Hashtable item, int level)
                    {
                        item.Add("level", level);
                        xlsCols.Add(item);
                        //记录最大表头高度
                        if (rowIndex < level) rowIndex = level;
                        int colwidth = 1;
                        if (item["children"] != null)
                        {
                            List<Hashtable> child = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hashtable>>(item["children"].ToString());
                            if (child != null && child.Count > 0)
                            {
                                colwidth = 0;
                                for (int i = 0; i < child.Count; i++)
                                    colwidth += FnTreeToList(child[i], level + 1);
                            }
                            else
                                item.Remove("children"); //没有子节点,将其移除,方便后面判断,一般不会出现这种情况
                        }
                        item.Add("width", colwidth);
                        return colwidth;
                    };
                    foreach (Hashtable item in json)
                        FnTreeToList(item, 0);
                    #endregion

                    #region 创建表头
                    List<int> iStart = new List<int>();
                    for (int i = 0; i < rowIndex + 1; i++)
                        iStart.Add(0);
                    foreach (Hashtable item in xlsCols)
                    {
                        int ridx = (int)item["level"]; //开始行
                        if (ridx >= headercount)
                            headercount = ridx + 1;
                        int cidx = iStart[ridx]; //开始列
                        int ccount = (int)item["width"]; //占用几列
                        iStart[ridx] += ccount;
                        int rcount = 1;  //默认占用1行高度
                        //如果没有子节点,且还不是最后表头行,则剩余表头行都被合并进来
                        if (item["children"] == null && ridx < rowIndex)
                        {
                            rcount = rowIndex - ridx + 1;
                            for (int i = ridx + 1; i < iStart.Count; i++)
                                iStart[i] += ccount;//合并行占用的列被同时增加
                        }
                        if (item["field"] != null) //记录下字段对应的列index
                            item.Add("colIndex", cidx);
                        xlsCells.Merge(ridx, cidx, rcount, ccount);//合并单元格
                        xlsCells[ridx, cidx].PutValue(item["Name"]);
                        xlsCells[ridx, cidx].SetStyle(style);
                        if (mergeColumns != null && mergeColumns.Contains(item["field"]))
                        {
                            ExcelMergeInfo me = new ExcelMergeInfo();
                            me.mergeColumn = item["Name"].ToString();
                            me.mergeField = item["field"].ToString();
                            me.firstColumn = cidx;
                            me.firstRow = 1;
                            me.totalColumns = 1;
                            me.totalRows = 1;
                            if (!mergeInt.Contains(me))
                                mergeInt.Add(me);
                        }
                        //xslSheet.AutoFitColumn(cidx);
                        if (item["Width"] != null && item["Width"].ToString() != "")
                            xlsCells.SetColumnWidthPixel(cidx, int.Parse(item["Width"].ToString().Replace("px", "").Replace("%", "")));
                        if (rcount > 1)
                            for (int i = ridx + 1; i < ridx + rcount; i++)
                                xlsCells[i, cidx].SetStyle(style);
                        if (ccount > 1)
                            for (int i = cidx + 1; i < cidx + ccount; i++)
                                xlsCells[ridx, i].SetStyle(style);
                    }
                    #endregion

                    #region 预处理 xlsCols, 提高数据填充时的效率
                    for (int i = xlsCols.Count - 1; i > -1; i--)
                    {
                        Hashtable item = xlsCols[i];
                        if (item["field"] == null || datatable.Columns.IndexOf(item["field"].ToString()) == -1)
                        {
                            if (item["Name"] == null || datatable.Columns.IndexOf(item["Name"].ToString()) == -1)
                            {
                                xlsCols.Remove(item);
                                continue;
                            }
                            item["field"] = item["Name"];
                        }
                        if (item["comboboxdata"] != null)
                        {
                            List<Hashtable> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hashtable>>(item["comboboxdata"].ToString());
                            Hashtable tmp = new Hashtable();
                            foreach (Hashtable node in list)
                                tmp.Add(node["id"].ToString(), node["text"] == null ? "" : node["text"].ToString());
                            item["comboboxdata"] = tmp;
                        }
                    }
                    #endregion
                }
                #endregion


                if (menuid != "")
                {
                    //如果有menuid，则通过报表找类型为列表的数据

                    string epss = Power.Global.PowerGlobal.RightProxy.GetEPSProjParentTreeToString(session.BizAreaId, session.EpsProjId);
                    StringBuilder sbwhere = new StringBuilder("MenuId='" + menuid + "' and ImpType='列表' and Actived=1");
                    if (!string.IsNullOrEmpty(epss))
                        sbwhere.Append(" and EpsProjId in (" + epss + ")");
                    IBusinessOperate bop = Business.BusinessFactory.CreateBusinessOperate("Report");
                    string fds = "Id,Name,ExpType,AddDate,IsFlow,FormKey";
                    IBusinessList list = bop.FindAll(sbwhere.ToString(), "Sequ", fds, 0, 0, SearchFlag.IgnoreRight);
                    if (list.Count > 0)
                    {
                        //如果有列表形式的报表，则用该报表的附件作为模板进行导出
                        //导出前，先将datatable中的下拉框处理一下
                        datatable.TableName = "dt";
                        foreach (Hashtable item in xlsCols)
                        {
                            string field = item["field"].ToString();
                            if (item["comboboxdata"] != null)
                            {
                                datatable.Columns.Add(new DataColumn(field + "string", typeof(string)));
                            }
                        }
                        foreach (DataRow row in datatable.Rows)
                        {
                            foreach (Hashtable item in xlsCols)
                            {
                                string field = item["field"].ToString();
                                if (item["comboboxdata"] != null)
                                {
                                    string value = row[field].ToString();
                                    Hashtable tmp = (Hashtable)item["comboboxdata"];
                                    row[field + "string"] = tmp[value];
                                }
                            }
                        }
                        foreach (Hashtable item in xlsCols)
                        {
                            string field = item["field"].ToString();
                            if (item["comboboxdata"] != null)
                            {
                                datatable.Columns.Remove(field);
                                datatable.Columns[field + "string"].ColumnName = field;

                            }
                        }
                        //再通过和报表类似的将excel下载、覆盖
                        Power.Business.IBusinessOperate ioRD = BusinessFactory.CreateBusinessOperate("DocFile");
                        DataTable docFile = ioRD.FindAllByTable(" FolderId='" + list[0]["Id"].ToString() + "'", "", "Id,Name,ServerUrl", 0, 0, SearchFlag.IgnoreRight);
                        string expType = list[0]["ExpType"].ToString();
                        string FileType = expType.Replace("(office)", "");
                        Random Rdm = new Random();
                        int iRdm = Rdm.Next(0, 1000);//产生0到100的随机数
                        string TempName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + iRdm.ToString() + "." + FileType;
                        string Name = docFile.Rows[0]["Name"].ToString() + "." + FileType;
                        string ServerUrl = docFile.Rows[0]["ServerUrl"].ToString();
                        string Ip = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "Ip");
                        string Port = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "Port");
                        string UserId = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "UserId");
                        string UserPwd = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "UserPwd");//UserPwd
                        string filePath = "ftp://" + Ip + ":" + Port + ServerUrl;
                        byte[] fileData = Power.Global.FtpHelper.FtpfileDownLoad(filePath, UserId, UserPwd).GetBuffer();
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(fileData);
                        Aspose.Cells.SaveFormat xlsType = Aspose.Cells.SaveFormat.Excel97To2003;
                        if (expType == "xlsx" || expType == "xlsx(office)")
                            xlsType = Aspose.Cells.SaveFormat.Xlsx;
                        Aspose.Cells.WorkbookDesigner designer = new Aspose.Cells.WorkbookDesigner();
                        DataSet ds = new DataSet();
                        ds.Tables.Add(datatable.Copy());
                        designer.SetDataSource(ds);
                        //designer.Open(ms);
                        designer.Process();//全自动赋值
                        designer.Workbook.CalculateFormula();//把xls内的公式变量转化为定量（如果不做这步，公式计算涉及到&=dt.aa的值在pdf都不显示）

                        designer.Workbook.Save(Response, HttpUtility.UrlEncode(Name, Encoding.UTF8).ToString(), Aspose.Cells.ContentDisposition.Inline, new Aspose.Cells.XlsSaveOptions(xlsType));
                        ms.Close();
                        return "";
                    }
                }
                rowIndex++;
                #region 填充数据
                List<ExcelMergeInfo> mergeHt = new List<ExcelMergeInfo>();//合并的各个位置 
                for (int k = 0; k < datatable.Rows.Count; k++)
                {
                    DataRow row = datatable.Rows[k];
                    foreach (Hashtable item in xlsCols)
                    {
                        string field = item["field"].ToString();
                        if (row[field] == DBNull.Value) continue;
                        int cidx = (int)item["colIndex"];
                        if (item["comboboxdata"] == null)
                        {
                            if (item["dateformat"] == null)
                            {
                                if (item["datatype"] != null && item["datatype"].ToString() == "currency")
                                {
                                    //如果是前台列是datatype="currency" currencyunit="$"
                                    //导出为$1,233.33
                                    string currency_fh = item["currencyunit"] == null ? "" : item["currencyunit"].ToString();
                                    string custom_currency = string.Format("{0}#,##0.00;{1}-#,##0.00", currency_fh, currency_fh);
                                    Aspose.Cells.Style styleCurrency = wb.Styles[wb.Styles.Add()];
                                    styleCurrency.Custom = custom_currency;
                                    if (ispdf)
                                    {
                                        //pdf时，需要设置边框线
                                        styleCurrency.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleCurrency.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleCurrency.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleCurrency.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    }
                                    xlsCells[rowIndex, cidx].PutValue(row[field]);
                                    xlsCells[rowIndex, cidx].SetStyle(styleCurrency);
                                }
                                else if (item["numberformat"] != null)
                                {
                                    string num = item["numberformat"].ToString();
                                    Aspose.Cells.Style styleNum = wb.Styles[wb.Styles.Add()];
                                    string custom_num = "";
                                    if (num.IndexOf('n') > -1)
                                    {
                                        //numberformat="n",默认为1,111.00;如果是n3,则是1,111.000
                                        custom_num = "#,##0.00";
                                        string num_num = num.Replace("n", "");
                                        int n = 0;
                                        int.TryParse(num_num, out n);
                                        for (int i = 0; i < n - 2; i++)
                                        {
                                            custom_num += "0";
                                        }
                                    }
                                    if (num.IndexOf('c') > -1)
                                    {
                                        string z = "￥#,##0.00";
                                        string num_num = num.Replace("c", "");
                                        int n = 0;
                                        int.TryParse(num_num, out n);
                                        for (int i = 0; i < n - 2; i++)
                                        {
                                            z += "0";
                                        }
                                        custom_num = z + ";-" + z;
                                    }
                                    if (num.IndexOf('p') > -1)
                                    {
                                        string z = "0.00";
                                        string num_num = num.Replace("p", "");
                                        int n = 0;
                                        int.TryParse(num_num, out n);
                                        for (int i = 0; i < n - 2; i++)
                                        {
                                            z += "0";
                                        }
                                        custom_num = z + "%";
                                    }
                                    styleNum.Custom = custom_num;

                                    if (ispdf)
                                    {
                                        //pdf时，需要设置边框线
                                        styleNum.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleNum.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleNum.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleNum.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    }
                                    xlsCells[rowIndex, cidx].PutValue(row[field]);
                                    xlsCells[rowIndex, cidx].SetStyle(styleNum);
                                }
                                else
                                {

                                    Aspose.Cells.Style styleNum = wb.Styles[wb.Styles.Add()];

                                    if (ispdf)
                                    {
                                        //pdf时，需要设置边框线
                                        styleNum.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleNum.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleNum.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        styleNum.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    }
                                    xlsCells[rowIndex, cidx].PutValue(row[field]);
                                    xlsCells[rowIndex, cidx].SetStyle(styleNum);
                                }
                            }
                            else
                            {
                                Aspose.Cells.Style styleDate = wb.Styles[wb.Styles.Add()];
                                styleDate.Custom = item["dateformat"].ToString();
                                if (ispdf)
                                {
                                    //pdf时，需要设置边框线
                                    styleDate.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    styleDate.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    styleDate.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    styleDate.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                }
                                xlsCells[rowIndex, cidx].PutValue(row[field]);
                                xlsCells[rowIndex, cidx].SetStyle(styleDate);
                            }
                        }
                        else
                        {
                            string value = row[field].ToString();
                            Hashtable tmp = (Hashtable)item["comboboxdata"];

                            Aspose.Cells.Style styleDate = wb.Styles[wb.Styles.Add()];
                            if (ispdf)
                            {
                                //pdf时，需要设置边框线
                                styleDate.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                styleDate.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                styleDate.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                styleDate.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                            }
                            xlsCells[rowIndex, cidx].PutValue(tmp[value]);
                            xlsCells[rowIndex, cidx].SetStyle(styleDate);
                        }
                    }
                    //第一行的时候，所以的合并都不管
                    if (k > 0)
                    {
                        foreach (ExcelMergeInfo item in mergeInt)
                        {
                            if (datatable.Columns.Contains(item.mergeColumn)&& row[item.mergeColumn].ToString() == datatable.Rows[k - 1][item.mergeColumn].ToString())
                            {
                                item.totalRows++;
                            }
                            else if (datatable.Columns.Contains(item.mergeField) && row[item.mergeField].ToString() == datatable.Rows[k - 1][item.mergeField].ToString())
                            {
                                item.totalRows++;
                            }
                            else
                            {
                                //if(k == datatable.Rows.Count - 1)
                                //    item.totalRows++;
                                ExcelMergeInfo m = new ExcelMergeInfo(item);
                                mergeHt.Add(m);
                                item.totalRows = 1;
                                item.firstRow = k + 1;
                            }
                            //最后一行的时候，可能既满足合并又需要加入
                            if (k == datatable.Rows.Count - 1&& item.totalRows > 1)
                            {
                                ExcelMergeInfo m = new ExcelMergeInfo(item);
                                mergeHt.Add(m);
                            }
                        }
                    }

                    rowIndex++;
                }
                #endregion
                foreach (ExcelMergeInfo item in mergeHt)
                {
                    if (item.totalRows == 1 && item.totalColumns == 1)
                        continue;
                    xlsCells.Merge(item.firstRow, item.firstColumn, item.totalRows, item.totalColumns, true, true);
                    xlsCells[item.firstRow, item.firstColumn].SetStyle(new Aspose.Cells.Style() {VerticalAlignment=Aspose.Cells.TextAlignmentType.Center}); //设置单元格合并后垂直居中显示
                }
                //xlsCells.Merge(1, 0, 3, 1);
                // xlsCells.Merge(7, 0, 7, 1);
                xslSheet.FreezePanes(headercount, 0, headercount, datatable.Columns.Count);//冻结标题行
                if (!ispdf)
                    wb.Save(Response, HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + ".xlsx", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Xlsx));
                else
                {
                    //转为pdf打开
                    Aspose.Cells.PdfSaveOptions pdfopt = new Aspose.Cells.PdfSaveOptions(Aspose.Cells.SaveFormat.Pdf);
                    pdfopt.AllColumnsInOnePagePerSheet = true;

                    wb.Save(Response, HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + ".pdf", Aspose.Cells.ContentDisposition.Inline, pdfopt);
                    // Response.Redirect(fileUrl + (HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8)) + ".pdf");
                }
                return "";
            }
            catch (Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return error;
            }
        }
        [Power.Business.Attributes.BindMessage(MessageKey = "Power.Control.StdExcel.DataTableToExcel")]
        public static void DataTableToExcel(Power.Message.MessageArg<ExcelExportMessageServiceModel, string> message)
        {

            ExcelExportMessageServiceModel messageObject = message.DataObject;

            StdExcel excel = new StdExcel();
            message.DataResultObject = excel.DataTableToExcel(messageObject);

        }

        /// <summary>
        /// 将树形结构树形导出excel
        /// </summary>
        /// <param name="messageObject"></param>
        /// <returns></returns>
        //树形
        private string TreeDataTableToExcel(ExcelExportMessageServiceModel messageObject)
        {
            DataTable datatable = messageObject.datatable;
            string fileName = messageObject.fileName;
            string excelColumns = messageObject.excelColumns;
            string menuid = messageObject.menuid;
            string headercolor = messageObject.headcolor;
            string headerfontcolor = messageObject.headfontcolor;
            bool ispdf = messageObject.ispdf;
            string treefield = messageObject.treefield;
            string levelcolor = messageObject.levelcolor;
            string fieldcolor = messageObject.fieldcolor;

            Hashtable levelcolorjson = null;
            List<Hashtable> fieldcolorjson = null;
            string error = "";

            if (datatable == null)
            {
                error = "DataTableToExcel:datatable " + Power.Global.Utility.GetResource("sync_not_null");//不能为空
                return error;
            }
            //表头行数

            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            int rowIndex = 0;
            List<Hashtable> xlsCols = new List<Hashtable>();
            try
            {
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet xslSheet = wb.Worksheets[0];
                Aspose.Cells.Cells xlsCells = xslSheet.Cells;
                //为单元格添加样式    
                Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                //设置居中
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;

                //设置背景颜色

                //如果定义了表头颜色，则用表头的颜色，格式为255,255,255
                if (headercolor != "")
                {
                    string[] rgb = headercolor.Split(',');
                    if (rgb.Length != 3)
                        throw new Exception("非法的表头背景色：" + headercolor + "，需要RGB的颜色设置，如：255,255,255");
                    try
                    {

                        int r = int.Parse(rgb[0]);
                        int g = int.Parse(rgb[1]);
                        int b = int.Parse(rgb[2]);
                        style.ForegroundColor = System.Drawing.Color.FromArgb(r, g, b);
                    }
                    catch (Exception)
                    {
                        throw new Exception("非法的表头背景色：" + headercolor + "，需要RGB的颜色设置，如：255,255,255");
                    }
                }
                else
                    style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = Aspose.Cells.BackgroundType.Solid;
                style.Font.IsBold = true;
                //如果定义了表头字体颜色，则用表头字体颜色
                if (headerfontcolor != "")
                {
                    string[] rgb = headerfontcolor.Split(',');
                    if (rgb.Length != 3)
                        throw new Exception("非法的表头字体色：" + headerfontcolor + "，需要RGB的颜色设置，如：255,255,255");
                    try
                    {

                        int r = int.Parse(rgb[0]);
                        int g = int.Parse(rgb[1]);
                        int b = int.Parse(rgb[2]);
                        style.Font.Color = System.Drawing.Color.FromArgb(r, g, b);
                    }
                    catch (Exception)
                    {
                        throw new Exception("非法的表头字体色：" + headerfontcolor + "，需要RGB的颜色设置，如：255,255,255");
                    }
                }
                int headercount = 1;//表头行数，多表头时，冻结多行
                #region 没有传入 excelColumns，使用 Datatable 列名作为xls列头
                if (string.IsNullOrEmpty(excelColumns))
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        DataColumn col = datatable.Columns[i];
                        string columnName = col.Caption ?? col.ColumnName;
                        xlsCells[rowIndex, i].PutValue(columnName);
                        xlsCells[rowIndex, i].SetStyle(style);
                        Hashtable item = new Hashtable();
                        item.Add("field", col.ColumnName);
                        item.Add("colIndex", i);
                        xlsCols.Add(item);
                    }
                }
                #endregion

                #region 解析excelColumns生成xls列头
                if (!string.IsNullOrEmpty(excelColumns))
                {
                    //补充列样式,上、下、左、右 边框线
                    style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;

                    List<Hashtable> json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hashtable>>(excelColumns);

                    #region tree转换成list(顺序从上到下，从左到右), level 从0开始
                    Func<Hashtable, int, int> FnTreeToList = null;
                    FnTreeToList = delegate (Hashtable item, int level)
                    {
                        item.Add("level", level);
                        xlsCols.Add(item);
                        //记录最大表头高度
                        if (rowIndex < level) rowIndex = level;
                        int colwidth = 1;
                        if (item["children"] != null)
                        {
                            List<Hashtable> child = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hashtable>>(item["children"].ToString());
                            if (child != null && child.Count > 0)
                            {
                                colwidth = 0;
                                for (int i = 0; i < child.Count; i++)
                                    colwidth += FnTreeToList(child[i], level + 1);
                            }
                            else
                                item.Remove("children"); //没有子节点,将其移除,方便后面判断,一般不会出现这种情况
                        }
                        item.Add("width", colwidth);
                        return colwidth;
                    };
                    foreach (Hashtable item in json)
                        FnTreeToList(item, 0);
                    #endregion

                    #region 创建表头
                    List<int> iStart = new List<int>();
                    for (int i = 0; i < rowIndex + 1; i++)
                        iStart.Add(0);
                    foreach (Hashtable item in xlsCols)
                    {
                        int ridx = (int)item["level"]; //开始行
                        if (ridx >= headercount)
                            headercount = ridx + 1;
                        int cidx = iStart[ridx]; //开始列
                        int ccount = (int)item["width"]; //占用几列
                        iStart[ridx] += ccount;
                        int rcount = 1;  //默认占用1行高度
                        //如果没有子节点,且还不是最后表头行,则剩余表头行都被合并进来
                        if (item["children"] == null && ridx < rowIndex)
                        {
                            rcount = rowIndex - ridx + 1;
                            for (int i = ridx + 1; i < iStart.Count; i++)
                                iStart[i] += ccount;//合并行占用的列被同时增加
                        }
                        if (item["field"] != null) //记录下字段对应的列index
                            item.Add("colIndex", cidx);
                        xlsCells.Merge(ridx, cidx, rcount, ccount);//合并单元格
                        xlsCells[ridx, cidx].PutValue(item["Name"]);
                        xlsCells[ridx, cidx].SetStyle(style);
                        //xslSheet.AutoFitColumn(cidx);
                        if (item["Width"] != null && item["Width"].ToString() != "")
                            xlsCells.SetColumnWidthPixel(cidx, int.Parse(item["Width"].ToString().Replace("px", "").Replace("%", "")));
                        if (rcount > 1)
                            for (int i = ridx + 1; i < ridx + rcount; i++)
                                xlsCells[i, cidx].SetStyle(style);
                        if (ccount > 1)
                            for (int i = cidx + 1; i < cidx + ccount; i++)
                                xlsCells[ridx, i].SetStyle(style);
                    }
                    #endregion

                    #region 预处理 xlsCols, 提高数据填充时的效率
                    for (int i = xlsCols.Count - 1; i > -1; i--)
                    {
                        Hashtable item = xlsCols[i];
                        if (item["field"] == null || datatable.Columns.IndexOf(item["field"].ToString()) == -1)
                        {
                            if (item["Name"] == null || datatable.Columns.IndexOf(item["Name"].ToString()) == -1)
                            {
                                xlsCols.Remove(item);
                                continue;
                            }
                            item["field"] = item["Name"];
                        }
                        if (item["comboboxdata"] != null)
                        {
                            List<Hashtable> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hashtable>>(item["comboboxdata"].ToString());
                            Hashtable tmp = new Hashtable();
                            foreach (Hashtable node in list)
                                tmp.Add(node["id"].ToString(), node["text"] == null ? "" : node["text"].ToString());
                            item["comboboxdata"] = tmp;
                        }
                    }
                    #endregion
                }
                #endregion

                #region 处理树的层级颜色和字段颜色
                try
                {
                    levelcolorjson = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(levelcolor);
                }
                catch (Exception ex)
                {
                    throw new Exception("非法的层级颜色：" + levelcolor + "，需要设置，如：{ 0: '149, 202, 252', 1: '206, 255, 206' }");
                }
                try
                {
                    fieldcolorjson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hashtable>>(fieldcolor);
                }
                catch (Exception ex)
                {
                    throw new Exception("非法的字段颜色：" + fieldcolor + "，需要设置，如：{'sum': { matchingtype: 'like', color: { 5: 'yellow', 10: 'red' } }");
                }
                #endregion

                if (menuid != "")
                {
                    //如果有menuid，则通过报表找类型为列表的数据

                    string epss = Power.Global.PowerGlobal.RightProxy.GetEPSProjParentTreeToString(session.BizAreaId, session.EpsProjId);
                    StringBuilder sbwhere = new StringBuilder("MenuId='" + menuid + "' and ImpType='列表' and Actived=1");
                    if (!string.IsNullOrEmpty(epss))
                        sbwhere.Append(" and EpsProjId in (" + epss + ")");
                    IBusinessOperate bop = Business.BusinessFactory.CreateBusinessOperate("Report");
                    string fds = "Id,Name,ExpType,AddDate,IsFlow,FormKey";
                    IBusinessList list = bop.FindAll(sbwhere.ToString(), "Sequ", fds, 0, 0, SearchFlag.IgnoreRight);
                    if (list.Count > 0)
                    {
                        //如果有列表形式的报表，则用该报表的附件作为模板进行导出
                        //导出前，先将datatable中的下拉框处理一下
                        datatable.TableName = "dt";
                        foreach (Hashtable item in xlsCols)
                        {
                            string field = item["field"].ToString();
                            if (item["comboboxdata"] != null)
                            {
                                datatable.Columns.Add(new DataColumn(field + "string", typeof(string)));
                            }
                        }
                        foreach (DataRow row in datatable.Rows)
                        {
                            foreach (Hashtable item in xlsCols)
                            {
                                string field = item["field"].ToString();
                                if (item["comboboxdata"] != null)
                                {
                                    string value = row[field].ToString();
                                    Hashtable tmp = (Hashtable)item["comboboxdata"];
                                    row[field + "string"] = tmp[value];
                                }
                            }
                        }
                        foreach (Hashtable item in xlsCols)
                        {
                            string field = item["field"].ToString();
                            if (item["comboboxdata"] != null)
                            {
                                datatable.Columns.Remove(field);
                                datatable.Columns[field + "string"].ColumnName = field;

                            }
                        }
                        //再通过和报表类似的将excel下载、覆盖
                        Power.Business.IBusinessOperate ioRD = BusinessFactory.CreateBusinessOperate("DocFile");
                        DataTable docFile = ioRD.FindAllByTable(" FolderId='" + list[0]["Id"].ToString() + "'", "", "Id,Name,ServerUrl", 0, 0, SearchFlag.IgnoreRight);
                        string expType = list[0]["ExpType"].ToString();
                        string FileType = expType.Replace("(office)", "");
                        Random Rdm = new Random();
                        int iRdm = Rdm.Next(0, 1000);//产生0到100的随机数
                        string TempName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + iRdm.ToString() + "." + FileType;
                        string Name = docFile.Rows[0]["Name"].ToString() + "." + FileType;
                        string ServerUrl = docFile.Rows[0]["ServerUrl"].ToString();
                        string Ip = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "Ip");
                        string Port = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "Port");
                        string UserId = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "UserId");
                        string UserPwd = Power.Global.PowerGlobal.GetConfigRunTimeValue("FtpConfig", "UserPwd");//UserPwd
                        string filePath = "ftp://" + Ip + ":" + Port + ServerUrl;
                        byte[] fileData = Power.Global.FtpHelper.FtpfileDownLoad(filePath, UserId, UserPwd).GetBuffer();
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(fileData);
                        Aspose.Cells.SaveFormat xlsType = Aspose.Cells.SaveFormat.Excel97To2003;
                        if (expType == "xlsx" || expType == "xlsx(office)")
                            xlsType = Aspose.Cells.SaveFormat.Xlsx;
                        Aspose.Cells.WorkbookDesigner designer = new Aspose.Cells.WorkbookDesigner();
                        DataSet ds = new DataSet();
                        ds.Tables.Add(datatable.Copy());
                        designer.SetDataSource(ds);
                        //designer.Open(ms);
                        designer.Process();//全自动赋值
                        designer.Workbook.CalculateFormula();//把xls内的公式变量转化为定量（如果不做这步，公式计算涉及到&=dt.aa的值在pdf都不显示）

                        designer.Workbook.Save(Response, HttpUtility.UrlEncode(Name, Encoding.UTF8).ToString(), Aspose.Cells.ContentDisposition.Inline, new Aspose.Cells.XlsSaveOptions(xlsType));
                        ms.Close();
                        return "";
                    }
                }
                rowIndex++;
                #region 填充数据

                //为单元格添加样式    
                Aspose.Cells.Style bodystyle = wb.Styles[wb.Styles.Add()];
                //设置背景颜色
                bodystyle.Pattern = Aspose.Cells.BackgroundType.Solid;
                bodystyle.Font.IsBold = true;
                //补充列样式,上、下、左、右 边框线
                bodystyle.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                bodystyle.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                bodystyle.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                bodystyle.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;

                foreach (DataRow row in datatable.Rows)
                {
                    foreach (Hashtable item in xlsCols)
                    {
                        bodystyle.ForegroundColor = System.Drawing.Color.FromArgb(255, 255, 255);

                        string field = item["field"].ToString();
                        int level = row["_level"] == null || row["_level"].ToString() == "" ? 0 : Convert.ToInt32(row["_level"]);
                        //level = level + 1;//加1取层级颜色  层级从0开始

                        #region 设置当前层级颜色
                        string currlevelcolor = levelcolorjson == null || levelcolorjson[level.ToString()] == null ? "" : levelcolorjson[level.ToString()].ToString();
                        bodystyle.ForegroundColor = GetColor(currlevelcolor);
                        #endregion

                        level = level + 1;
                        string str = "";
                        if (field == treefield)
                        {
                            for (int i = 1; i < level; i++)
                            {
                                str += "    ";
                            }
                        }

                        if (row[field] == DBNull.Value) continue;

                        Hashtable fieldcolorhs = null;
                        string direction = "left";
                        #region 设置字段单元格的颜色
                        //if(field)
                        foreach (var hs in fieldcolorjson)
                        {
                            if (hs["matchingtype"] == null || hs["matchingtype"] == null || hs["matchingtype"] == null) continue;

                            string machingtype = hs["matchingtype"].ToString();
                            string machingfield = hs["field"].ToString();
                            direction = hs["direction"] == null || hs["direction"].ToString() == "" ? direction : hs["direction"].ToString();
                            Hashtable machingfieldcolor = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(hs["color"].ToString());
                            //相等的权限级别
                            if (machingtype == "equal" && field == machingfield)
                            {
                                fieldcolorhs = machingfieldcolor;
                                break;
                            }
                            if (machingtype == "like" && field.IndexOf(machingfield) > -1)
                            {
                                fieldcolorhs = machingfieldcolor;
                                break;
                            }
                        }

                        #endregion

                        int cidx = (int)item["colIndex"];
                        if (item["comboboxdata"] == null)
                        {
                            if (item["dateformat"] == null)
                            {
                                if (item["datatype"] != null && item["datatype"].ToString() == "currency")
                                {
                                    //如果是前台列是datatype="currency" currencyunit="$"
                                    //导出为$1,233.33
                                    string currency_fh = item["currencyunit"] == null ? "" : item["currencyunit"].ToString();
                                    string custom_currency = string.Format("{0}#,##0.00;{1}-#,##0.00", currency_fh, currency_fh);
                                    //Aspose.Cells.Style styleCurrency = wb.Styles[wb.Styles.Add()];
                                    bodystyle.Custom = custom_currency;
                                    if (ispdf)
                                    {
                                        //pdf时，需要设置边框线
                                        bodystyle.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    }

                                    if (fieldcolorhs != null)
                                    {
                                        bodystyle.ForegroundColor = GetCellBackGroundColor(fieldcolorhs, row[field], direction);
                                    }
                                    xlsCells[rowIndex, cidx].PutValue(row[field]);
                                    xlsCells[rowIndex, cidx].SetStyle(bodystyle);
                                }
                                else if (item["numberformat"] != null)
                                {
                                    string num = item["numberformat"].ToString();
                                    //Aspose.Cells.Style styleNum = wb.Styles[wb.Styles.Add()];
                                    string custom_num = "";
                                    if (num.IndexOf('n') > -1)
                                    {
                                        //numberformat="n",默认为1,111.00;如果是n3,则是1,111.000
                                        custom_num = "#,##0.00";
                                        string num_num = num.Replace("n", "");
                                        int n = 0;
                                        int.TryParse(num_num, out n);
                                        for (int i = 0; i < n - 2; i++)
                                        {
                                            custom_num += "0";
                                        }
                                    }
                                    if (num.IndexOf('c') > -1)
                                    {
                                        string z = "￥#,##0.00";
                                        string num_num = num.Replace("c", "");
                                        int n = 0;
                                        int.TryParse(num_num, out n);
                                        for (int i = 0; i < n - 2; i++)
                                        {
                                            z += "0";
                                        }
                                        custom_num = z + ";-" + z;
                                    }
                                    if (num.IndexOf('p') > -1)
                                    {
                                        string z = "0.00";
                                        string num_num = num.Replace("p", "");
                                        int n = 0;
                                        int.TryParse(num_num, out n);
                                        for (int i = 0; i < n - 2; i++)
                                        {
                                            z += "0";
                                        }
                                        custom_num = z + "%";
                                    }
                                    bodystyle.Custom = custom_num;

                                    if (ispdf)
                                    {
                                        //pdf时，需要设置边框线
                                        bodystyle.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    }
                                    if (fieldcolorhs != null)
                                    {
                                        bodystyle.ForegroundColor = GetCellBackGroundColor(fieldcolorhs, row[field], direction);
                                    }
                                    xlsCells[rowIndex, cidx].PutValue(row[field]);
                                    xlsCells[rowIndex, cidx].SetStyle(bodystyle);
                                }
                                else
                                {

                                    //Aspose.Cells.Style styleNum = wb.Styles[wb.Styles.Add()];

                                    if (ispdf)
                                    {
                                        //pdf时，需要设置边框线
                                        bodystyle.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                        bodystyle.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    }
                                    if (fieldcolorhs != null)
                                    {
                                        bodystyle.ForegroundColor = GetCellBackGroundColor(fieldcolorhs, row[field], direction);
                                    }
                                    xlsCells[rowIndex, cidx].PutValue(str + row[field]);
                                    xlsCells[rowIndex, cidx].SetStyle(bodystyle);
                                }
                            }
                            else
                            {
                                //Aspose.Cells.Style styleDate = wb.Styles[wb.Styles.Add()];
                                bodystyle.Custom = item["dateformat"].ToString();
                                if (ispdf)
                                {
                                    //pdf时，需要设置边框线
                                    bodystyle.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    bodystyle.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    bodystyle.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                    bodystyle.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                }
                                if (fieldcolorhs != null)
                                {
                                    bodystyle.ForegroundColor = GetCellBackGroundColor(fieldcolorhs, row[field], direction);
                                }
                                xlsCells[rowIndex, cidx].PutValue(row[field]);
                                xlsCells[rowIndex, cidx].SetStyle(bodystyle);
                            }
                        }
                        else
                        {
                            string value = row[field].ToString();
                            Hashtable tmp = (Hashtable)item["comboboxdata"];

                            //Aspose.Cells.Style styleDate = wb.Styles[wb.Styles.Add()];
                            if (ispdf)
                            {
                                //pdf时，需要设置边框线
                                bodystyle.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                bodystyle.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                bodystyle.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                                bodystyle.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Hair;
                            }
                            if (fieldcolorhs != null)
                            {
                                bodystyle.ForegroundColor = GetCellBackGroundColor(fieldcolorhs, tmp[value], direction);
                            }
                            xlsCells[rowIndex, cidx].PutValue(tmp[value]);
                            xlsCells[rowIndex, cidx].SetStyle(bodystyle);
                        }
                    }
                    rowIndex++;
                }
                #endregion

                xslSheet.FreezePanes(headercount, 0, headercount, datatable.Columns.Count);//冻结标题行
                if (!ispdf)
                    wb.Save(Response, HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + ".xlsx", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Xlsx));
                else
                {
                    //转为pdf打开
                    Aspose.Cells.PdfSaveOptions pdfopt = new Aspose.Cells.PdfSaveOptions(Aspose.Cells.SaveFormat.Pdf);
                    pdfopt.AllColumnsInOnePagePerSheet = true;

                    wb.Save(Response, HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + ".pdf", Aspose.Cells.ContentDisposition.Inline, pdfopt);
                    // Response.Redirect(fileUrl + (HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8)) + ".pdf");
                }
                return "";
            }
            catch (Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return error;
            }
        }

        /// <summary>
        /// 获取单元格的背景色
        /// </summary>
        /// <param name="fieldcolorhs"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private System.Drawing.Color GetCellBackGroundColor(Hashtable fieldcolorhs, object value, string direction)
        {
            System.Drawing.Color color = System.Drawing.Color.FromArgb(255, 255, 255);
            try
            {
                #region 获取单元格颜色
                if (fieldcolorhs != null)
                {
                    //对颜色值进行排序
                    ArrayList arraylist = new ArrayList();
                    foreach (DictionaryEntry ky in fieldcolorhs)
                    {
                        if (ky.Key == null && ky.Key.ToString() == "") continue;
                        decimal key = Convert.ToDecimal(ky.Key);
                        arraylist.Add(key);
                    }
                    arraylist.Sort();
                    decimal fieldvalue = value == null || value.ToString() == "" ? 0 : Convert.ToDecimal(value);
                    int j = 0;
                    decimal prevalue = 0;
                    for (int i = 0, len = arraylist.Count; i < len; i++)
                    {
                        decimal key = Convert.ToDecimal(arraylist[i]);
                        if (fieldcolorhs[key.ToString()] == null || fieldcolorhs[key.ToString()].ToString() == "") continue;
                        string currcolor = fieldcolorhs[key.ToString()].ToString();

                        if (direction == "left")
                        {
                            if (i == 0 && fieldvalue <= key)
                            {
                                color = GetColor(currcolor);
                                break;
                            }
                            if (prevalue < fieldvalue && key >= fieldvalue)
                            {
                                color = GetColor(currcolor);
                                break;
                            }
                            if (i == len - 1 && fieldvalue > key)
                            {
                                break;
                            }
                            prevalue = Convert.ToDecimal(arraylist[i]);
                        }
                        else if (direction == "right")
                        {
                            if (i == 0 && fieldvalue < key)
                            {
                                break;
                            }
                            if (prevalue <= fieldvalue && key > fieldvalue)
                            {
                                j = i - 1;
                                if (j > len || j < 0) continue;
                                currcolor = fieldcolorhs[arraylist[j].ToString()].ToString();
                                color = GetColor(currcolor);
                                break;
                            }
                            if (i == len - 1 && fieldvalue >= key)
                            {
                                currcolor = fieldcolorhs[arraylist[i].ToString()].ToString();
                                color = GetColor(currcolor);
                                break;
                            }
                            prevalue = Convert.ToDecimal(arraylist[i]);
                        }
                    }

                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return color;
        }

        /// <summary>
        /// 获取颜色rgb值
        /// </summary>
        /// <param name="currcolor"></param>
        /// <returns></returns>
        private System.Drawing.Color GetColor(string currcolor)
        {
            System.Drawing.Color color = System.Drawing.Color.FromArgb(255, 255, 255);
            string[] fieldrgb = currcolor.Replace(" ", "").Split(',');
            if (fieldrgb.Length == 3)
            {
                try
                {
                    int r = int.Parse(fieldrgb[0]);
                    int g = int.Parse(fieldrgb[1]);
                    int b = int.Parse(fieldrgb[2]);
                    color = System.Drawing.Color.FromArgb(r, g, b);
                }
                catch (Exception)
                {
                    color = System.Drawing.Color.FromArgb(255, 255, 255);
                }
            }
            return color;
        }

        [Power.Business.Attributes.BindMessage(MessageKey = "Power.Control.StdExcel.TreeDataTableToExcel")]
        public static void TreeDataTableToExcel(Power.Message.MessageArg<ExcelExportMessageServiceModel, string> message)
        {

            ExcelExportMessageServiceModel messageObject = message.DataObject;

            StdExcel excel = new StdExcel();
            message.DataResultObject = excel.TreeDataTableToExcel(messageObject);

        }
    }
}
