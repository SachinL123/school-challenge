using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolchallenge.Model.Models
{
    public class FileUploadLog
    {
        public FileUploadLog()
        {
            FileRows = new List<FileData>();
        }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public DateTime UploadedAt { get; set; }

        public List<FileData> FileRows { get; set; }
    }
}
