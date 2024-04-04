namespace DemoAttendenceFeature.Utility.Interface
{
    public interface IImageTransaction
    {
        //public string GetImageUrl(IFormFile imageFile, string subFolder, string id);
        public Task<string> UploadImage(IFormFile imageFile, string subFolder, string id);
        //public Task DeleteImage(string imageUrl);
    }
}
