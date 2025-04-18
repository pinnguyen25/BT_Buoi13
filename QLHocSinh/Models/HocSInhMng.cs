using System.Text;
using System.Text.Json;
using Unidecode.NET;

public class HocSInhMng
{
    List<HocSinh>? dsHS = new List<HocSinh>();

    public string path = "data.json";

    // hàm tạo
    public HocSInhMng()
    {
        LayData();
    }

    // thêm hs
    public void Add()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.Unicode;
        Console.WriteLine("Nhập tên học sinh: ");
        string ten = Console.ReadLine();
        Console.WriteLine("Nhập điểm Toán: ");
        double Toan = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập điểm Văn: ");
        double Van = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập điểm Anh: ");
        double Anh = double.Parse(Console.ReadLine());
        HocSinh nhap = new HocSinh(ten, Toan, Van, Anh);
        dsHS.Add(nhap);
        Console.WriteLine("Thêm thành công");
        LuuData();
    }

    // tìm kím thông tin theo tên
    public void SearchHS(string ten)
    {
        // xử lý tìm không dấu
        string a = "Tiếng Việt";
        a.Unidecode();// => tieng viet
        var kq = dsHS.Where(hs => hs.TenHs.Trim().Unidecode().ToLower().Contains(ten.Unidecode().ToLower()));
        // hs.TenHs.Unidecode().ToLower(): chuyển tên trong ds thành tiếng việt ghi thường k dấu
        // ten.Unidecode().ToLower(): tên người dùng muốn tìm thành không dấu
        // contains : ktr ds chứa kết quả
        // show kq

        Console.WriteLine("Thông tin học sinh: ");
        foreach(var b in kq)
        {
            Console.WriteLine($"Mã HS: {b.MaHs} | Tên HS: {b.TenHs} | Điểm Toán: {b.DiemT} | Điểm Văn: {b.DiemV} | Điểm Anh: {b.DiemA}");
        }
    }

    // cập nhập điểm 
    public void UpdateDiem()
    {
        Console.WriteLine("Nhập mã của học sinh cần cập nhập: ");
        int id = int.Parse(Console.ReadLine());
        HocSinh hs = dsHS.FirstOrDefault(hs=>hs.MaHs == id);
        if(hs != null) // tìm thấy
        {
            Console.WriteLine($"Tên HS: {hs.TenHs}");
            Console.WriteLine("Điểm Toán mới: ");
            hs.DiemT = double.Parse(Console.ReadLine());
            Console.WriteLine("Điểm Văn mới: ");
            hs.DiemV = double.Parse(Console.ReadLine());
            Console.WriteLine("Điểm Anh mới: ");
            hs.DiemA = double.Parse(Console.ReadLine());
            Console.WriteLine("Cập nhập thành công");
            LuuData();
        }
        else
        {
            Console.WriteLine($"Không tìm thấy học sinh {hs}");
        }

    }

    // xoá hs khỏi list
    public void DelHS(int id)
    {
        int FindHS = dsHS.FindIndex(hs=>hs.MaHs == id);
        if(FindHS != -1) // có tìm thấy
        {
            dsHS.RemoveAt(FindHS);
            Console.WriteLine($"Đã xoá học sinh mã số {FindHS+1}");
            LuuData();
        }
        else
        {
            Console.WriteLine($"Không tìm thấy học sinh mã {FindHS+1}");
        }
    }
    // hiển thị danh sách hs kèm xếp loại dựa trên điểm tb
    public void ShowListXL()
    {
        if(dsHS.Count() == 0)
        {
            Console.WriteLine("Danh sách trống");
            return;
        }
        foreach(var hs in dsHS)
        {
            hs.InFoHS();
        }
    }
    
    // hiển thị học sinh theo điểm tb tăng dần (orderby)

    public void ShowDTB()
    {
        var dsDTB = dsHS.OrderBy(hs=>hs.DiemTB()).ToList();
        foreach(var hs in dsDTB)
        {
            hs.InFoHS();
        }
    }

    // hiển thị hs theo tên (dùng orderby). Xử lý . ví dụ trần An => tách ra sắp theo chữ An
    public void ShowTenO()
    {
        var dsTen = dsHS.OrderBy(hs=>hs.TenHs.Split(' ').Last()).ToList();
        // Split: tách tên dựa trên khoảng trắng
        // last: lấy phần cuối cùng của tên
        // orderby : dùng để sắp xếp danh sách học sinh dựa trên phần cuối cùng của tên
        Console.WriteLine($"Danh sách học sinh theo tên {dsTen}");
        foreach (var hs in dsTen)
        {
            hs.InFoHS();
        }
    }

    // Lưu data
    public void LuuData()
    {
        var json = JsonSerializer.Serialize(dsHS, new JsonSerializerOptions{WriteIndented = true});
        // ghi vào json
        File.WriteAllText(path,json);
        Console.WriteLine("Lưu thành công");
    }

    // Lấy data
    public void LayData()
    {
        if(File.Exists(path))
        {
            // đọc file
            var json = File.ReadAllText(path);
            //chuyển đổi vê list hoc sinh
            // kiểm tra điều kiện cho file json
            if(json.Count() >0 )
            {
                dsHS = JsonSerializer.Deserialize<List<HocSinh>>(json);
                //update iddem
                int maxID = dsHS.Max(hs=>hs.MaHs);
                HocSinh.IdDem = maxID +1;
            }
            else
            {
                Console.WriteLine("File rỗng");
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy đường dẫn file");
        }
    }
}