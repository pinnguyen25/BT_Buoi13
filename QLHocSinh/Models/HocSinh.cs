public class HocSinh
{
    public static int IdDem = 1;
    public int MaHs {get; set; }
    public string TenHs {get; set; }
    public double DiemA {get; set; }
    public double DiemV {get; set; }
    public double DiemT {get; set; }

    // hàm constructor
    public HocSinh()
    {

    }

    // hàm tạo
    public HocSinh(string ten, double DiemT, double DiemV, double DiemA)
    {
        MaHs = IdDem++;
        TenHs = ten;
        this.DiemT = DiemT;
        this.DiemV = DiemV;
        this.DiemA = DiemA;
    }
    
    // tính điểm trung bình
    public double DiemTB()
    {
        return (DiemT+DiemV+DiemA)/3;
    }

    // xếp loại
    public string XepLoai()
    {
        double dtb = DiemTB();
        return dtb switch
        {
            < 5 => "Yếu",
            >= 5 and <= 6.5 => "Trung Bình",
            > 6.5 and <= 8 => "Khá",
            > 8 and <= 10 => "Giỏi",
            _ => "Không hợp lệ"
        };
    }

    // phương thức
    public void InFoHS()
    {
        Console.WriteLine($"Mã HS: {MaHs} | Tên HS: {TenHs} | Điểm trung bình: {DiemTB():F2} | Xếp loại: {XepLoai()}");
    }
}
