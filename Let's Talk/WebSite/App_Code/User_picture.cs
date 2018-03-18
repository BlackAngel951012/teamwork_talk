using System.IO;
using System.Web;

/// <summary>
///   User_picture 的摘要说明
/// </summary>
public class User_picture : UserInfo
{
    public string root_path = HttpContext.Current.Request.PhysicalApplicationPath;
    public string user_folder_name;
    protected string user_picture_save_folder = "Images/Pictures/";

    public string User_folder_name
    {
        get { return user_folder_name; }
        set { user_folder_name = value; }
    }

    public string User_picture_save_folder
    {
        get { return user_picture_save_folder; }
        set { user_picture_save_folder = value; }
    }

    public void folder_delete()
    {
        string path = root_path + user_picture_save_folder + user_folder_name;
        try
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
        catch
        {
        }
    }

    public void folder_creat()
    {
        string path = root_path + user_picture_save_folder + user_folder_name;
        try
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
        }
        catch
        {
        }
    }

    public int get_file_total()
    {
        string path = root_path + user_picture_save_folder + user_folder_name + "\\";
        string[] fileArray = Directory.GetFiles(path, "*");
        return fileArray.Length - 1;
    }

    public string[] get_all_file_name()
    {
        string path = root_path + user_picture_save_folder + user_folder_name;
        string[] fileArray = Directory.GetFiles(path, "*");
        string[] filename = new string[fileArray.Length];
        int i = 0;
        foreach (string aoo in fileArray)
        {
            if (aoo.Substring(aoo.LastIndexOf("\\") + 1) != "Thumbs.db")
            {
                filename[i++] = aoo.Substring(aoo.LastIndexOf("\\") + 1);
            }
        }
        return filename;
    }
}