using examBaraaDb.Common.Exceptions;
using System;
using System.IO;

namespace examBaraaDb.Common.Helpers 
{
    public static class Helper
    {
        public static string SaveImage(string nbase64img,string baseFolder)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(baseFolder))
                {
                    throw new ServiceValidationException();
                }
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), baseFolder);
                if (!Directory.Exists(baseFolder))
                {
                    Directory.CreateDirectory(baseFolder);
                }
                var base64Array = nbase64img.Split(";base64,"); 
                if (base64Array.Length < 1)
                {
                    return "";
                }
                nbase64img = base64Array[1]; 
                var filename = $"{Guid.NewGuid()}{"Logo.png"}".Replace("-", "", StringComparison.InvariantCultureIgnoreCase);
                if (!string.IsNullOrWhiteSpace(baseFolder))   
                { 
                    var url = $@"{baseFolder}\{filename}";
                    filename = $@"{folderPath}\{filename}";
                    File.WriteAllBytes(filename,Convert.FromBase64String(nbase64img));
                    return url;
                }
                return "";
            
            }
            catch (Exception ex)
            {
                throw new ServiceValidationException(ex.Message);
            }
        }




    }
}
