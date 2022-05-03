using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFileCL.Models;
using static MFileCL.DA.MFDA;

namespace MFileCL.BL
{
    public static class MFLogic
    {
        public static int AddFile(String FN,String FL,int FS)
        {
            PDFFile f = new PDFFile { Name = FN, Location = FL, Filesize = FS};
            return SaveData(@"insert into dbo.PDFFile (Name,Location,Filesize)values(@Name,@Location,@Filesize)",f);
        }

        public static List<PDFFile> ListFile()
        {
            String sql = "Select ID,Name,Location,Filesize from dbo.PDFFile";
            return LoadData<PDFFile>(sql);
        }

        public static PDFFile GetPDFFile(int id)
        {
            String sql = "select ID,Name,Location,Filesize from dbo.PDFFile where ID = " + id.ToString();
            return LoadData<PDFFile>(sql).FirstOrDefault();
        }

        public static int EditFile(int vid,string fn, string fl, int fs)
        {
            PDFFile f = new PDFFile { ID = vid, Name = fn, Location = fl, Filesize = fs};
            return SaveData("update dbo.PDFFile set Name = @Name, Location=@Location,FileSize = @FileSize where ID = @ID",f);
        }

        public static int DeleteFile(int id)
        {
            PDFFile pdf = new PDFFile
            { ID = id, Name = "", Location = "", Filesize = 0 };
            return SaveData(@"delete from dbo.PDFFile where id = @id", pdf);


        }
    }
}
