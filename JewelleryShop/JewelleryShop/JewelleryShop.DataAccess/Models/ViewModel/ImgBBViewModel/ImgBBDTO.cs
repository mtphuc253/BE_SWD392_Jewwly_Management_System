using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.ImgBBViewModel
{
    public class ImageUploadResponse
    {
        public Data Data { get; set; }
        public bool Success { get; set; }
        public int Status { get; set; }
    }

    public class Data
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string UrlViewer { get; set; }
        public string Url { get; set; }
        public string DisplayUrl { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }
        public string Expiration { get; set; }
        public Image Image { get; set; }
        public Thumb Thumb { get; set; }
        public Medium Medium { get; set; }
        public Delete Delete { get; set; }
    }

    public class Image
    {
        public string Filename { get; set; }
        public string Name { get; set; }
        public string Mime { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
    }

    public class Thumb
    {
        public string Filename { get; set; }
        public string Name { get; set; }
        public string Mime { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
    }

    public class Medium
    {
        public string Filename { get; set; }
        public string Name { get; set; }
        public string Mime { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
    }

    public class Delete
    {
        public string Url { get; set; }
    }

}
