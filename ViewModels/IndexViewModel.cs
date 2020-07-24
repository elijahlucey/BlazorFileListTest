using System.Collections.Generic;

namespace BlazorFileListTest.ViewModel {
    public class IndexViewModel {
        public IList<UploadViewModel> Uploads { get; set; }

        public IndexViewModel() {
            Uploads = new List<UploadViewModel>();
        }
    }
}