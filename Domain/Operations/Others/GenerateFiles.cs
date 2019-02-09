using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Operations.Others
{
    public  static class GenerateFiles
    {
      
        public  static async System.Threading.Tasks.Task<string> InsertFileAsync(IFormFile File, string path , string documentID)
        {
          
          
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    path = path+ "/" + documentID + "/";
                    if (Directory.Exists(path))
                    {
                        string ext = Path.GetExtension(File.FileName);
                        string imagepath = Path.GetFileNameWithoutExtension(File.FileName) + ext.ToString();
                        imagepath =Guid.NewGuid().ToString() + imagepath.Trim();
                        var fileToSave = Path.Combine(path,
                               imagepath);

                        using (var stream = new FileStream(fileToSave, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }
                        return path + imagepath;
                    }
                    else
                    {
                        DirectoryInfo dr = Directory.CreateDirectory(path);
                        string ext = Path.GetExtension(File.FileName);
                        string imagepath = Path.GetFileNameWithoutExtension(File.FileName) + ext.ToString();
                        imagepath = Guid.NewGuid().ToString() + imagepath.Trim();
                        var fileToSave = Path.Combine(path,
                               imagepath);

                        using (var stream = new FileStream(fileToSave, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }
                        return path + imagepath;
                    }

                } else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    path = path + "/" + documentID + "/";
                    if (Directory.Exists(path))
                    {
                      
                        string ext = Path.GetExtension(File.FileName);
                        string imagepath = Path.GetFileNameWithoutExtension(File.FileName) + ext.ToString();
                        imagepath = Guid.NewGuid().ToString() + imagepath.Trim();
                        var fileToSave = Path.Combine(path,
                               imagepath);

                        using (var stream = new FileStream(fileToSave, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }
                        return path + imagepath;
                    }
                    else
                    {
                        DirectoryInfo dr = Directory.CreateDirectory(path);
                        string ext = Path.GetExtension(File.FileName);
                        string imagepath = Path.GetFileNameWithoutExtension(File.FileName) + ext.ToString();
                        imagepath = Guid.NewGuid().ToString() + imagepath.Trim();
                        var fileToSave = Path.Combine(path,
                               imagepath);

                        using (var stream = new FileStream(fileToSave, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }
                        return path + imagepath;
                    }
                }

                // Try to create the directory.
              
                    
            }
            catch (Exception e)
            {
                return "";
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            
        }

        public static string FilePath(string path , string attachmentType)
        {


            string FilePath = path + "Documents/";
          
            if(attachmentType == "Policy")
            {
                FilePath = FilePath + "Policies";
            }
            else if (attachmentType == "Quotation")
            {
                FilePath = FilePath + "Quotations";
            }
            else if (attachmentType == "Risk")
            {
                FilePath = FilePath +  "Risks";
            }
            else if (attachmentType == "Flag")
            {
                FilePath = FilePath + "Flags";
            }
            else if (attachmentType == "User")
            {
                FilePath = FilePath + "Users";
            }
            else if (attachmentType == "Member")
            {
                FilePath = FilePath + "Members";
            }
            else if (attachmentType == "Claim")
            {
                FilePath = FilePath + "Claims";
            }
            else if (attachmentType == "Company")
            {
                FilePath = FilePath + "Companies";
            }
            return FilePath;
        }
    }
}
