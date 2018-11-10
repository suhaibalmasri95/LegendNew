using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Entities.Other
{
    public class ExportResult
    {
        public MemoryStream Stream;
        public string ContentType;
        public string FileName;

    }
}
