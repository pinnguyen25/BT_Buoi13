class Program
{
    static void Main()
    {
        HocSInhMng qly = new HocSInhMng();
        SanPhamMng qlsp = new SanPhamMng();
        DonHangMng qldh = new DonHangMng();
        //menu chọn
        int choice;
        while (true)
        {
            Console.WriteLine(@"
 --------------------------------- MENU -----------------------------------
|                                                                          |
 ============================ Menu QL Học Sinh=============================
|    1/ Thêm thông tin học sinh                                            |
|    2/ Tìm kiếm học sinh theo tên                                         |
|    3/ Cập nhập điểm số học sinh                                          |
|    4/ Xoá học sinh khỏi danh sách                                        |
|    5/ Hiển thị học sinh kèm xếp loại học lực dựa trên điểm trung bình    |
|    6/ Hiển thị học sinh theo điểm trung bình tăng dần (Orderby)          |
|    7/ Hiển thị học sinh theo tên (dùng orderby).                         |
|                                                                          |
 --------------------------------------------------------------------------
 ====================== Menu QL Sản phẩm - Đơn Hàng =======================
|    8/ Thêm sản phẩm                                                      |
|    9/ Tìm kiếm sản phẩm theo tên                                         |
|   10/ Cập nhật giá hoặc tồn kho                                          |
|   11/ Xóa sản phẩm theo mã                                               |
|   12/ Hiển thị danh sách sản phẩm và tổng kho                            |
|   13/ Sắp xếp theo giá bán tăng dần                                      |
|   14/ Sắp xếp theo tên sản phẩm                                          |
|   15/ Quản lý đơn hàng (CRUD)                                            |
|   16/ Thoát                                                              |
 ==========================================================================
            ");
            Console.WriteLine("Chọn chức năng 1 - 16: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    qly.Add();
                    break;
                case 2:
                    Console.WriteLine("Nhập tên học sinh cần tìm: ");
                    string ten = Console.ReadLine();
                    qly.SearchHS(ten);
                    break;
                case 3:
                    qly.UpdateDiem();
                    break;
                case 4:
                    Console.WriteLine("Nhập mã học sinh cần xoá: ");
                    int id = int.Parse(Console.ReadLine());
                    qly.DelHS(id);
                    break;
                case 5:
                    qly.ShowListXL();
                    break;
                case 6:
                    qly.ShowDTB();
                    break;
                case 7:
                    qly.ShowTenO();
                    break;
                case 8:
                    qlsp.ThemSP();
                    break;
                case 9:
                    Console.WriteLine("Nhập tên sp cần tìm: ");
                    string tensp = Console.ReadLine();
                    qlsp.TimKiemSP(tensp);
                    break;
                case 10:
                    qlsp.CapNhapSP();
                    break;
                case 11:
                    Console.WriteLine("Nhập mã sp cần xoá: ");
                    string masp = Console.ReadLine();
                    qlsp.XoaSP(masp);
                    break;
                case 12:
                    qlsp.HienThiSP();
                    break;
                case 13:
                    qlsp.SapXepTheoGia();
                    break;
                case 14:
                    qlsp.SapXepTheoTen();
                    break;
                case 15:
                    qldh.QlDonHang();
                    break;
                case 16:
                    Console.WriteLine("Bái bai");
                    return;
                default:
                    Console.WriteLine("Nhập không hợp lệ");
                    break;

            }
        }
    }
}