using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OA.DataAccess;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Responces;
using OA.Domin.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Upload
{
    public class UploadService
    {
        private readonly AppDbContext dbContext;

        public UploadService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<string>> UploadProfilePic(ProfilePicRequest profilePicReq)
        {
            var result = new Response<string>();

            var File = profilePicReq.ImgFile;

            var validation = ValidateFile(File);
            if(validation.Errors.Count > 0)
            {
                result.HasErrors = true;
                result.ValidationErrors = new List<ValidationResult>() { validation };

                return result;
            }

            var folderName = CombinePathes(new List<string> { "StaticFiles", "Images", "ProfilePics" });
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = $"{Guid.NewGuid()}_{File.Name}";
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);

            await SaveFile(fullPath, File.Data); 

            result.HasErrors = false;
            result.Result = dbPath;

            return result;
        }

        public async Task<Response<string>> UploadFile(RequestFileData fileData, string saveTo = "StaticFiles")
        {
            var result = new Response<string>();            

            var validation = ValidateFile(fileData);
            if (validation.Errors.Count > 0)
            {
                result.HasErrors = true;
                result.ValidationErrors = new List<ValidationResult>() { validation };

                return result;
            }

            var folderName = CombinePathes(saveTo.Split('/').OfType<string>().ToList());
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = $"{Guid.NewGuid()}_{fileData.Name}";
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);

            await SaveFile(fullPath, fileData.Data);

            result.HasErrors = false;
            result.Result = dbPath;

            return result;
        }


        public void DeleteProfilePic(string dbPath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), dbPath);

            DeleteFile(fullPath);
        }

        public void DeleteUploadedFile(string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
                return;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), dbPath);

            DeleteFile(fullPath);
        }


        public ValidationResult ValidateFile(RequestFileData file, FileValidation validation = null)
        {
            var result = new ValidationResult();
            result.Field = "File";

            if (file == null || file.Size == 0 || file.Data.Length == 0)
                result.Errors.Add("Empty File Data");

            return result;
        }

        public void ReduceImgSize()
        {

        }

        public async Task SaveFile(string path, byte[] fileBytes)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await stream.WriteAsync(fileBytes);
            }
        }

        public void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch(Exception)
            {
            }
        }

        public string CombinePathes(List<string> pathParts)
        {
            string path = "";
            foreach (var pathPart in pathParts)
                path = Path.Combine(path, pathPart);

            return path;
        }

    }
}
