using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryTable
{
    public class WordHelper
    {
        private DocumentBuilder oWordApplic; 
        private Aspose.Words.Document oDoc; 
        //判断文件是否存在
        public void OpenWord(string strFileName)
        {
            if (File.Exists(strFileName))
            {
                oDoc = new Document(strFileName);
            }
            else
            {
                oDoc = new Document();
            }
        }
        public string getWordContent()
        {
            string content = oDoc.GetText();
            return content;
        }
    }
}
