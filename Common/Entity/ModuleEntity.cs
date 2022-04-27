using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ModuleEntity
{
    public int PageID { get; set; }
    public int ParentID { get; set; }
    public string PageName { get; set; }
  //  public string ModuleName { get; set; }
   // public string SubModuleName { get; set; }
   // public string SubSubModuleName { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public string PageNameURL { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public int MenuOrderID { get; set; }
    public int ModuleType { get; set; }
    public DateTime CreatedDate { get; set; }

}
public class MenuItem
{
    public string LinkName { get; set; }
    public string Link { get; set; }
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
