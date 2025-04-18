public class DonHangMng
{
    List<DonHang> dsDH = new List<DonHang>();

    public void QlDonHang()
    {
        while (true)
        {
            Console.WriteLine(@"
     ============ QL ĐƠN HÀNG =============
    |   1/ Thêm đơn hàng                   |
    |   2/ Hiển thị đơn hàng               |
    |   3/ Cập nhật đơn hàng theo mã       |
    |   4/ Xóa đơn hàng theo mã            |
    |   5/ Thoát                           |
     ======================================
            ");
            Console.Write("Chọn: ");
            int chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    ThemDonHang();
                    break;
                case 2:
                    HienThiDonHang();
                    break;
                case 3:
                    CapNhatDonHang();
                    break;
                case 4:
                    XoaDonHang();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Chức năng không hợp lệ!");
                    break;
            }
        }
    }
    public void ThemDonHang()
    {
        Console.WriteLine("Nhập mã đơn hàng: ");
        string madh = Console.ReadLine();
        Console.WriteLine("Mã sản phẩm: ");
        string masp = Console.ReadLine();
        Console.WriteLine("Số lượng bán: ");
        int sl = int.Parse(Console.ReadLine());
        Console.WriteLine("Tên người đặt: ");
        string tenDat = Console.ReadLine();
        Console.WriteLine("Đơn hàng đã giao (true/false): ");
        bool dagiao = bool.Parse(Console.ReadLine());

        dsDH.Add(new DonHang
        {
            MaDH = madh,
            MaSP = masp,
            SoLuongBan = sl,
            TenNguoiDat = tenDat,
            DaGiao = dagiao
        });

        Console.WriteLine("Đơn hàng đã được thêm thành công!");
    }

    public void HienThiDonHang()
    {
        if (dsDH.Count == 0)
        {
            Console.WriteLine("Chưa có đơn hàng nào.");
            return;
        }

        foreach (var dh in dsDH)
        {
            Console.WriteLine($"{dh.MaDH} | {dh.MaSP} | SL: {dh.SoLuongBan} | Người đặt: {dh.TenNguoiDat} | Đã giao: {dh.DaGiao}");
        }
    }

    public void CapNhatDonHang()
    {
        Console.Write("Nhập mã đơn hàng cần cập nhật: ");
        string ma = Console.ReadLine();
        var dh = dsDH.FirstOrDefault(d => d.MaDH == ma);
        if (dh != null)
        {
            Console.WriteLine("Nhập mã sản phẩm mới: ");
            dh.MaSP = Console.ReadLine();
            Console.WriteLine("Nhập số lượng mới: ");
            dh.SoLuongBan = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập tên người đặt mới: ");
            dh.TenNguoiDat = Console.ReadLine();
            Console.WriteLine("Đã giao? (true/false): ");
            dh.DaGiao = bool.Parse(Console.ReadLine());

            Console.WriteLine("Cập nhật thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy đơn hàng.");
        }
    }

    public void XoaDonHang()
    {
        Console.Write("Nhập mã đơn hàng cần xóa: ");
        string ma = Console.ReadLine();
        var dh = dsDH.FirstOrDefault(d => d.MaDH == ma);
        if (dh != null)
        {
            dsDH.Remove(dh);
            Console.WriteLine("Xóa thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy đơn hàng.");
        }
    }
}