using System.Text;
using System.Text.Json;

public class SanPhamMng
{
    List<SanPham> dsSP = new List<SanPham>();
    public string pathfile = "sanpham.json";
    
    public SanPhamMng()
    {
        LayData();
    }

    public void ThemSP(){
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.Unicode;
        Console.WriteLine("Mã SP: ");
        string ma = Console.ReadLine();
        Console.WriteLine("Tên SP: ");
        string ten = Console.ReadLine();
        Console.WriteLine("Giá bán: ");
        double gia = double.Parse(Console.ReadLine());
        Console.WriteLine("Số lượng tồn: ");
        int sl = int.Parse(Console.ReadLine());
        // tạo sp mới trực tiếp, không phải tạo hàm infosp() để gọi từ file sanpham.cs
        dsSP.Add(new SanPham{MaSP = ma, TenSP = ten, GiaSP = gia, SoLuongTon = sl});
        LuuData();
        Console.WriteLine("Thêm thành công");
    }

    public void HienThiSP()
    {
        foreach(var sp in dsSP)
        {
            Console.WriteLine($"{sp.MaSP} - {sp.TenSP} - {sp.GiaSP} - {sp.SoLuongTon}");
        }
        Console.WriteLine($"Tổng giá trị kho: {TinhTongGiaTriKho()}");
    }

    public void TimKiemSP(string ten)
    {
        ten = ten.ToLower();
        var kq = dsSP.Where(sp=>sp.TenSP.ToLower().Contains(ten)).ToList();
        if(kq.Count >0)
        {
            foreach(var sp in kq)
            {
                Console.WriteLine($"{sp.MaSP} - {sp.TenSP} - {sp.GiaSP} - {sp.SoLuongTon}");
            }
        }
        else
        Console.WriteLine("Không tìm thấy sản phẩm");
    }

    public void CapNhapSP()
    {
        HienThiSP();
        Console.WriteLine("Nhập mã SP cần cập nhập: ");
        string ma = Console.ReadLine();
        var sp = dsSP.FirstOrDefault(sp=>sp.MaSP == ma);
        if (sp != null)
        {
            Console.WriteLine("Nhập giá mới: ");
            double giaMoi = double.Parse(Console.ReadLine());
            sp.GiaSP = giaMoi;

            Console.WriteLine("Nhập số lượng tồn mới: ");
            int sltonMoi = int.Parse(Console.ReadLine());
            sp.SoLuongTon = sltonMoi;

            Console.WriteLine("Cập nhập thành công");
        }
    }

    public void XoaSP(string ma)
    {
        HienThiSP();
        ma = Console.ReadLine();
        var sp = dsSP.FirstOrDefault(sp=> sp.MaSP == ma);
        if(sp != null)
        {
            dsSP.Remove(sp);
            Console.WriteLine("Xoá thành công");
        }
        else Console.WriteLine("Không tìm thấy sản phẩm");
    }

    public double TinhTongGiaTriKho()
    {
        return dsSP.Sum(sp => sp.GiaSP * sp.SoLuongTon);
    }
    
    public void SapXepTheoGia()
    {
        var sapxep = dsSP.OrderBy(sp=>sp.GiaSP);
        foreach(var sp in sapxep)
        {
            Console.WriteLine($"{sp.MaSP} - {sp.TenSP} - {sp.GiaSP}");
        }
    }

    public void SapXepTheoTen()
    {
        var theoten = dsSP.OrderBy(sp=>sp.TenSP.Split(' ').Last());
        foreach(var sp in theoten)
        {
            Console.WriteLine($"{sp.MaSP} - {sp.TenSP}");
        }
    }

    // Lưu data
    public void LuuData()
    {
        var json = JsonSerializer.Serialize(dsSP, new JsonSerializerOptions{WriteIndented = true});
        // ghi vào json
        File.WriteAllText(pathfile,json);
        Console.WriteLine("Lưu thành công");
    }

    // Lấy data
    public void LayData()
    {
        if(File.Exists(pathfile))
        {
            // đọc file
            var json = File.ReadAllText(pathfile);
            // kiểm tra điều kiện cho file json
            dsSP = JsonSerializer.Deserialize<List<SanPham>>(json);
        }
        else
        {
            Console.WriteLine("Không tìm thấy đường dẫn file");
        }
    }
}