using DemoAttendenceFeature.Helper;
using DemoAttendenceFeature.Utility.Interface;
using Firebase.Auth;
using Firebase.Storage;
using System.IO;
using System.Net.Sockets;

namespace DemoAttendenceFeature.Utility
{
    public class ImgaeTransaction : IImageTransaction
    {
        public string api, email,password,bucket,rootFolder;
        public IConfiguration _configuration { get; set; }
        public IHostEnvironment _hostEnvironment { get; set; }
        public ImgaeTransaction(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
            api = _configuration.GetSection("FirebaseAdmin:APIKEY").Value;
            email = _configuration.GetSection("FirebaseAdmin:EMAIL").Value;
            password = _configuration.GetSection("FirebaseAdmin:PASSWORD").Value;
            bucket = _configuration.GetSection("FirebaseAdmin:BUCKET").Value;
            rootFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot");
        }
        public async Task<string> UploadImage(IFormFile imageFile, string subFolder, string id)
        {
            string imageUrl = null;
            var auth = new FirebaseAuthProvider(new FirebaseConfig(api));
            var firebaseAuth = await auth.SignInWithEmailAndPasswordAsync(email, password);
            var storage = new FirebaseStorage(
            bucket,
            new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuth.FirebaseToken),
                ThrowOnCancel = true,
            });

            var uniqueFileName = id + "_" + imageFile.FileName;

           

            using (var fileStream = imageFile.OpenReadStream())
            {
                imageUrl = await storage.Child("images")
                                        .Child(subFolder)
                                        .Child(uniqueFileName)
                                        .PutAsync(fileStream);
            }
            return imageUrl;
        }
    }
}
