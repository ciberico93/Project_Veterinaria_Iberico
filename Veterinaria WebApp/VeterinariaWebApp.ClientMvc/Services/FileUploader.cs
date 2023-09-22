namespace VeterinariaWebApp.ClientMvc.Services
{
    public class FileUploader : IFileUploader
    {
        private const int MaxFileSize = 4 * 1024 * 1024;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileUploader> _logger;
        public FileUploader(IWebHostEnvironment webHostEnvironment, ILogger<FileUploader> logger)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<(string Url, string MensajeError)> UploadFileAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length <= 0)
                {
                    throw new InvalidOperationException("Por favor, seleccione una imagen");
                }

                if (file.Length > MaxFileSize) // 4MB
                {
                    throw new InvalidOperationException("La imagen no puede ser mayor a 4MB");
                }

                // Ruta donde se guardara la imagen en el servidor
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if(!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var archivoUnico = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                var archivo = Path.Combine(uploadPath, archivoUnico);

                await using (var stream = new FileStream(archivo, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return ($"/uploads/{archivoUnico}", string.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al subir la imagen {FileName} {Message}", file.FileName, ex.Message);

                return (string.Empty, ex.Message);
            }
        }
    }
}
