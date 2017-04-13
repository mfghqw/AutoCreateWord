using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using CABISP.Helper.Data;
using System.IO;

namespace CABISP.Helper
{
    public partial class ThisDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            var list = HelperService.GetAllHelper();
            SetPageHeader("金华青鸟");
            InsertText("中非商贸投资服务平台帮助文档",20,Word.WdColor.wdColorBlack,1,Word.WdParagraphAlignment.wdAlignParagraphCenter);
            NewLine();
            NewLine();
            foreach (var item in list)
            {
                InsertText(item.HelperTypeName, 12, Word.WdColor.wdColorBlue, 1, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                NewLine();
                NewLine();
                foreach (var c in item.zf_HelperContent)
                {
                    InsertText(c.HelperTitle, 10, Word.WdColor.wdColorBlack, 1, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                    NewLine();
                    //InsertText("    "+c.Content, 10, Word.WdColor.wdColorBlack, 0, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                    ConvertHelperContent(c.Content);
                    NewLine();
                }
            }
            //InsertPicture(@"C:\Users\admin\Desktop\项目\中非商贸投资服务平台\页面\web20170402\web\images\com\about-bg1.png");
        }
        private void ConvertHelperContent(string content)
        {
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"temp.html", false, Encoding.Default);
            sw.Write("<html><head></head><body>");//temp.html中没有完整的html文件标记不行，没有的话会在word中显示html tag而不是样式，预先写入模版也行  
            content = content.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ").Replace("&#39;", "\\").
                Replace("&quot;", "\"");
            sw.Write(content);
            sw.Write("</body></html>");
            sw.Close();

            object oFalse = false;
            object oTrue = true;
            object oMissing = System.Reflection.Missing.Value;

            this.Application.Selection.InsertFile(AppDomain.CurrentDomain.BaseDirectory + "temp.html", ref oMissing, ref oFalse, ref oTrue, ref oFalse);

        }
        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
           
        }

        /// <summary>
        /// 插入文字
        /// </summary>
        /// <param name="pText"></param>
        /// <param name="pFontSize"></param>
        /// <param name="pFontColor"></param>
        /// <param name="pFontBold"></param>
        /// <param name="ptextAlignment"></param>
        public void InsertText(string pText, int pFontSize=10, Word.WdColor pFontColor= Word.WdColor.wdColorRed, int pFontBold=0, Word.WdParagraphAlignment ptextAlignment= Word.WdParagraphAlignment.wdAlignParagraphLeft)
        {
            //设置字体样式以及方向    
            this.Application.Selection.Font.Size = pFontSize;
            this.Application.Selection.Font.Bold = pFontBold;
            this.Application.Selection.Font.Color = pFontColor;
            this.Application.Selection.ParagraphFormat.Alignment = ptextAlignment;
            this.Application.Selection.TypeText(pText);
        }
        /// <summary>
        /// 换行
        /// </summary>
        public void NewLine()
        {   
            this.Application.Selection.TypeParagraph();
        }
        /// <summary>
        /// 新增图片
        /// </summary>
        /// <param name="pPictureFileName"></param>
        public void InsertPicture(string pPictureFileName)
        {
            object myNothing = System.Reflection.Missing.Value;
            //图片居中显示    
            this.Application.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            this.Application.Selection.InlineShapes.AddPicture(pPictureFileName, ref myNothing, ref myNothing, ref myNothing);
        }
     
        /// <summary>
        /// 设置页眉
        /// </summary>
        /// <param name="pPageHeader"></param>
        public void SetPageHeader(string pPageHeader)
        {
            //添加页眉    
            this.ActiveWindow.View.Type = Word.WdViewType.wdOutlineView;
            this.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekPrimaryHeader;
            this.ActiveWindow.ActivePane.Selection.InsertAfter(pPageHeader);
            //设置中间对齐    
            this.Application.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //跳出页眉设置    
            this.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
        }


        #region VSTO 设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
