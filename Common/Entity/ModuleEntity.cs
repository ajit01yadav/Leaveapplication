using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ModuleEntity
{
    public int ModuleID { get; set; }
    public string ModuleName { get; set; }
    public string SubModuleName { get; set; }
    public string SubSubModuleName { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public string PageLink { get; set; }
    public string LinkIcon { get; set; }
    public int ParentID { get; set; }
    public int ModuleLevel { get; set; }
    public int ModuleType { get; set; }
    public int OriginalID { get; set; }
    public int LeftSideDisplay { get; set; }
    public bool ViewModule { get; set; }
    public bool EditModule { get; set; }
    public bool DeleteModule { get; set; }
    public int SortOrder { get; set; }
    public int Status { get; set; }
}

public static class GetModuleID
{
    public const int Dashboard = 1;
    public const int User = 7;
    public const int Role = 8;
    public const int ContentPage = 9;
    public const int News = 10;
    public const int Testimonial = 11;
    public const int Career = 12;
    public const int BlogCategory = 13;
    public const int BlogPost = 14;
    public const int Videos = 15;
    public const int VideoCategory = 16;
    public const int Carousel = 17;
    public const int Menu = 18;
    public const int ImageResize = 19;
    public const int Product = 20;
    public const int Brands = 21;
    public const int ProductCategory = 22;

    public const int Defaults = 0;
    public const int ProductImage = 0;
    public const int ProductAttribute = 0;
    public const int ProductDetail = 0;
    public const int ProductAttributeSet = 0;
}

public enum PageTypes { ContentPage = 1, NewsPage = 2, TestimonialPage = 3, BlogCategory = 4, BlogPost = 5, VideoPage = 6, BrandPage = 7, ProductCategory = 8 , CarouselPage = 9 }

public enum ModuleRights { CreateRights = 0, ManageRights = 1, DeleteRights = 2 }
