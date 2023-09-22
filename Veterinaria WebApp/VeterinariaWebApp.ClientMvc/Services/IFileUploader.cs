namespace VeterinariaWebApp.ClientMvc.Services
{
    public interface IFileUploader
    {
        Task<(string Url, string MensajeError)> UploadFileAsync(IFormFile file);

    }
}
