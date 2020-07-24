using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorFileListTest.ViewModel;
using Microsoft.AspNetCore.Components;
using Tewr.Blazor.FileReader;

namespace BlazorFileListTest.Pages {
    public class UploadEditorRowBase : ComponentBase {
        [Parameter]
        public UploadViewModel Vm { get; set; }
        [Inject]
        protected IFileReaderService _fileReader { get; set; }

        protected string _uploadedFile = String.Empty;

        protected async Task OnUploadChange(ChangeEventArgs e) {
            // store the file
            var files = await _fileReader.CreateReference(Vm.Input).EnumerateFilesAsync();
            var file = files.First();
            Vm.ImageFile = file;

            // render preview
            var fileInfo = await file.ReadFileInfoAsync();
            using(MemoryStream memoryStream = await file.CreateMemoryStreamAsync()) {
                byte[] bytes = memoryStream.ToArray();
                _uploadedFile = $"data:{fileInfo.Type};base64,{Convert.ToBase64String(bytes)}";
            }
        }

        private string GetFileType(string filename) {
            string ext = Path.GetExtension(filename).ToLower();
            if(ext.Contains("jpg") || ext.Contains("jpeg")) {
                return "jpeg";
            } else if(ext.Contains("png")) {
                return "png";
            } else if(ext.Contains("gif")) {
                return "gif";
            } else {
                return String.Empty;
            }
        }
    }
}