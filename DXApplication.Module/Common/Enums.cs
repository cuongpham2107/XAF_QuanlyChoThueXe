using DevExpress.ExpressApp.DC;

namespace DXApplication.Blazor.Common;

public class Enums
{
    public enum LoaiBaoDuong
    {
        [XafDisplayName("Sửa chữa")] sc = 0,
        [XafDisplayName("Đổ xăng")] dx = 1,
    }
    public enum LoaiThue
    {
        [XafDisplayName("Thuê giờ")] gio = 0,
        [XafDisplayName("Thuê ngày")] ngay = 1,
        [XafDisplayName("Thuê tháng")] thang = 2,
        
    }
    public enum TrangThaiThue
    {
        [XafDisplayName("Lưu Tạm")] luutam = 0,
        [XafDisplayName("Đang cho thuê")] dangchothue = 1,
        [XafDisplayName("Đã trả xe")] datraxe = 2,
    }
    public enum TrangThaiXe
    {
        [XafDisplayName("Khả dụng")] kd = 0,
        [XafDisplayName("Đã bán xe")] dbx = 1,
    }
    public enum TrangThaiBaoDuong
    {
        [XafDisplayName("Lưu tạm")] lt = 0,
        [XafDisplayName("Đã duyệt")] dx =1,
    }
    public enum LyDo
    {
        [XafDisplayName("Thu tiền tạm ứng")] thuTienTamUng = 0,
        [XafDisplayName("Bảo dưỡng, sửa chữa")] baoDuongSuaChua = 1,
        [XafDisplayName("Đổ xăng")] doXang = 2,
    }
}