using System;
using Microsoft.AspNetCore.Components;
using Tewr.Blazor.FileReader;

namespace BlazorFileListTest.ViewModel {
    public class UploadViewModel {
        private IFileReference _imageFile;
        public IFileReference ImageFile {
            get { return _imageFile; }
            set { 
                _imageFile = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public ElementReference Input { get; set; }

        public event EventHandler<EventArgs> Remove = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public UploadViewModel() { }

        public void RemoveSelf() {
            Remove?.Invoke(this, EventArgs.Empty);
        }
    }
}