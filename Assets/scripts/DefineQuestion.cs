using System.Collections.Generic;
using Newtonsoft.Json;

public static class DefineQuestion
{
    public static List<DeFaultQuest> ListQuestion = new List<DeFaultQuest>();

    public static int RandomQuestion(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static List<QuestionDenfine> GetQuestion()
    {
        List<QuestionDenfine> list = new List<QuestionDenfine>();
        List<int> listIndex = new List<int>();
        while (list.Count < 7)
        {
         var insert = new QuestionDenfine();
         int index = RandomQuestion(0, ListQuestion.Count);
         if (listIndex.Contains(index)) continue;
         insert.quest = ListQuestion[index].Cauhoi;
         insert.A = ListQuestion[index].A;
         insert.B = ListQuestion[index].B;
         insert.C = ListQuestion[index].C;
         insert.D = ListQuestion[index].D;
         insert.indexTrue = ListQuestion[index].Dapan.ToLower() == "a" ? 0 : ListQuestion[index].Dapan.ToLower() == "b" ? 1 : ListQuestion[index].Dapan.ToLower() == "c" ? 2 : 3;
         list.Add(insert);
         listIndex.Add(index);
        }
        return list;
    }

    public static void Run()
    {
        string data = @"[
 {
  ""Cauhoi"": ""Khi bạn vào trường, việc đầu tiên bạn làm là gì?"",
  ""A"": ""Học trên lớp"",
  ""B"": ""Gửi xe"",
  ""C"": ""Đi bộ vào"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Điền câu còn thiếu : Con ơi ghi nhớ lời này Công cha, nghĩa mẹ, ... chớ quên."",
  ""A"": ""ơn huệ"",
  ""B"": ""ơn thầy"",
  ""C"": ""công đức"",
  ""Dapan"": ""b""
 },
 {
  ""Cauhoi"": ""Trường Đại Học Dân Lập Phương Đông thành lập năm nào?"",
  ""A"": 1999,
  ""B"": 1994,
  ""C"": 1949,
  ""Dapan"": ""b""
 },
 {
  ""Cauhoi"": ""Tại sao các chương trình luôn bắt đầu bằng hàm main () ? (đố vui)"",
  ""A"": ""Vì không có \""main\"", mọi thứ sẽ trở nên \""phụ\"""",
  ""B"": ""Vì main () được viết đầu tiên nên đứng đầu"",
  ""C"": ""Vì người code lười đặt tên khác"",
  ""D"": ""Vì các hàm khác bận đi chơi"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Bạn nghĩ gì khi nhắc đến sinh viên IT ?"",
  ""A"": ""Hacker Lord"",
  ""B"": ""Con dân mọt sách"",
  ""C"": ""Lập trình viên rất thông minh"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Bạn sẽ nuôi tớ chứ 🌝"",
  ""A"": ""Chắn chắn ùi 😚"",
  ""B"": ""Không nuôi cậu thì nuôi aiii 😖"",
  ""C"": ""Không chỉ nuôi cậu, tớ sẽ cho cậu tất cả những gì tớ có luôn 😚"",
  ""D"": ""Nuôi cậu đến kiếp sauu 😆"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Hiệu trưởng của trường chúng ta hiện tại là thầy?"",
  ""A"": ""Nguyễn An"",
  ""B"": ""Bùi Thiện Dụ"",
  ""C"": ""Trần Ngọc Kim"",
  ""Dapan"": ""B""
 },
 {
  ""Cauhoi"": ""Điểm thi cuối kỳ của bạn tổng kết là 3.6 , bạn sẽ nhận học bổng loại gì?"",
  ""A"": ""Xuất Sắc"",
  ""B"": ""Giỏi"",
  ""C"": ""Khá"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Nhà trường có mấy cơ sở đào tạo"",
  ""A"": ""2 cơ sở"",
  ""B"": ""1 cơ sở"",
  ""C"": ""3 cơ sở"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Đố các bạn biết, đại học Phương Đông có bao nhiêu ngành?"",
  ""A"": 9,
  ""B"": 10,
  ""C"": 11,
  ""Dapan"": ""B""
 },
 {
  ""Cauhoi"": ""Khoa CNTT & TT hiện đang đào tạo tại cơ sở nào"",
  ""A"": ""Hưng Ký"",
  ""B"": ""Trung Ký"",
  ""C"": ""Cầu Giấy"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Chúng ta thường được nghỉ hè bao nhiêu lâu?"",
  ""A"": ""1 tuần"",
  ""B"": ""1 tháng"",
  ""C"": ""2 tháng"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Một sinh viên có thể tham gia tối đa bao nhiêu CLB?"",
  ""A"": 1,
  ""B"": 2,
  ""C"": 3,
  ""D"": ""Không giới hạn"",
  ""Dapan"": ""D""
 },
 {
  ""Cauhoi"": ""Thầy cô bên khoa chúng ta có chức danh trình độ học vấn như nào?"",
  ""A"": ""Thạc Sỹ Trở lên"",
  ""B"": ""Tiến Sỹ Trở lên"",
  ""C"": ""Giáo Sư Trở lên"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Giả sử, chúng ta mời ca sĩ về trường để hát vào các sự kiện, các bạn có phải đóng tiền không?"",
  ""A"": ""Không và nhà trường đầu tư"",
  ""B"": ""Đóng tiền"",
  ""C"": ""Đóng vào học phí"",
  ""D"": ""Các thầy cô tài trợ"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Theo bạn, theo học IT là học những gì?"",
  ""A"": ""Lập trình và xây dựng sản phẩm"",
  ""B"": ""Hack Facebook và cài Win dạo"",
  ""C"": ""Học để làm quán nét"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Theo bạn, game của CLB IT làm ra để làm gì?"",
  ""A"": ""quảng cáo ngành và trường"",
  ""B"": ""khơi gợi và hưởng ứng sự kiện chào tân"",
  ""C"": ""dành để tuyển thành viên cho CLB"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Nếu bạn đấm chính mình mà thấy đau là do bạn khỏe hay do bạn yếu"",
  ""A"": ""Bạn khỏe"",
  ""B"": ""Bạn yếu"",
  ""C"": ""Cả 2"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Trong breaking bad, Jesse Pinkman đã nói từ \""bitch\"" bao nhiêu lần?"",
  ""A"": 53,
  ""B"": 54,
  ""C"": 55,
  ""D"": 56,
  ""Dapan"": ""B""
 },
 {
  ""Cauhoi"": ""Tại sao lập trình viên lại sợ đi cắm trại"",
  ""A"": ""Vì họ sợ phải debug cả lửa trại"",
  ""B"": ""Vì họ thích ngồi trước màn hình"",
  ""C"": ""Vì trong rừng không có oai phai"",
  ""D"": ""Vì họ không thể tìm thấy \""bug\"" ngoài đời thực"",
  ""Dapan"": ""D""
 },
 {
  ""Cauhoi"": ""Cách tán crut nhanh nhất ⭕️"",
  ""A"": ""Vẽ trái tym"",
  ""B"": ""Bóng bay trái tym"",
  ""C"": ""Lập trình code hình trái tym"",
  ""D"": ""Uốn lưỡi hình trái tym"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Ngôn ngữ lập trình nào có tốc độ compile nhanh nhất?"",
  ""A"": ""C++"",
  ""B"": ""Python"",
  ""C"": ""Rust"",
  ""D"": ""C"",
  ""Dapan"": ""D""
 },
 {
  ""Cauhoi"": ""Trong cấu trúc chương trình C++ có bao nhiêu hàm main()?"",
  ""A"": 1,
  ""B"": 2,
  ""C"": 3,
  ""D"": 4,
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Lệnh cout trong C++ đi kèm với cặp dấu nào?"",
  ""A"": "">>"",
  ""B"": ""\\\\"",
  ""C"": ""\/\/"",
  ""D"": ""<<"",
  ""Dapan"": ""D""
 },
 {
  ""Cauhoi"": ""Ý nghĩa con số 8386"",
  ""A"": ""Tài lộc song hành"",
  ""B"": ""Tài lộc sinh tài lộc"",
  ""C"": ""Phát tài phát lộc"",
  ""D"": ""Mãi mãi không tử"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Con gì vừa biết bay, vừa biết bơi, lại vừa biết đi bộ?"",
  ""A"": ""Đại bàng"",
  ""B"": ""Cá heo"",
  ""C"": ""Chim cánh cụt"",
  ""D"": ""Gấu trắng"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Năm 2024 là năm con gì theo lịch âm"",
  ""A"": ""Giáp Thìn"",
  ""B"": ""Giáp Mão"",
  ""C"": ""Quý Thìn"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Tác giả của cuốn tiểu thuyết \""Bố già\"" là ai?"",
  ""A"": ""John Steinbeck"",
  ""B"": ""Trấn Thành"",
  ""C"": ""Mario Puzo"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Quốc gia nào là quê hương gốc của món mỳ tương đen?"",
  ""A"": ""Trung Quốc"",
  ""B"": ""Hàn Quốc"",
  ""C"": ""Nhật Bản"",
  ""D"": ""Việt Nam"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Bánh mỳ Việt Nam có tên quốc tế là gì"",
  ""A"": ""Bread"",
  ""B"": ""Bánh Mỳ"",
  ""C"": ""Tacos"",
  ""Dapan"": ""B""
 },
 {
  ""Cauhoi"": ""Điều gì càng nhiều càng nhẹ"",
  ""A"": ""Tiền"",
  ""B"": ""Nước"",
  ""C"": ""Lời nói"",
  ""D"": ""Không khí"",
  ""Dapan"": ""D""
 },
 {
  ""Cauhoi"": ""Cái gì của bạn nhưng người khác lại dùng nhiều nó hơn cả bạn"",
  ""A"": ""Tên mình"",
  ""B"": ""Quần áo"",
  ""C"": ""Số điện thoại"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Cái gì càng rửa càng bẩn"",
  ""A"": ""Tay"",
  ""B"": ""Chân"",
  ""C"": ""Đường phố"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Con gì càng chạy càng béo"",
  ""A"": ""Con người"",
  ""B"": ""Con mèo"",
  ""C"": ""Con đường"",
  ""D"": ""Con chó"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Con gì không bao giờ bị ướt khi đi qua sông"",
  ""A"": ""Con mèo"",
  ""B"": ""Con chó"",
  ""C"": ""Con lợn"",
  ""D"": ""Con đường"",
  ""Dapan"": ""D""
 },
 {
  ""Cauhoi"": ""Cái gì luôn đi đến mà không bao giờ đến nơi"",
  ""A"": ""Xe buýt"",
  ""B"": ""Cái bóng"",
  ""C"": ""Ngày mai"",
  ""D"": ""Đồng hồ báo thức"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Con gì đập thì sống không đập thì chết"",
  ""A"": ""Con tim"",
  ""B"": ""Con ruồi"",
  ""C"": ""Con cá"",
  ""D"": ""Con cua"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Cái gì càng nóng càng lạnh"",
  ""A"": ""Tủ lạnh"",
  ""B"": ""Cục nóng điều hoà"",
  ""C"": ""Kem"",
  ""Dapan"": ""C""
 },
 {
  ""Cauhoi"": ""Nếu được chọn trở thành thành viên clb ITPDU và trở thành tỷ phú bạn sẽ chọn gì?"",
  ""A"": ""Đương nhiên là ITPDU rùi"",
  ""B"": ""ITPDU luôn là nơi mà mình muốn tham gia"",
  ""C"": ""Trở thành thành viên clb ITPDU"",
  ""D"": ""Cả 3 đáp án trên"",
  ""Dapan"": ""D""
 },
 {
  ""Cauhoi"": ""Baby hả anh tới chưaaaa"",
  ""A"": ""Anh tới rồiiii"",
  ""B"": ""Pikachu bắt anh rồiii"",
  ""C"": ""Bùngggh"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Nhà máy điện Phú Mỹ chạy bằng:"",
  ""A"": ""Khí"",
  ""B"": ""Than đá"",
  ""C"": ""Than trắng"",
  ""D"": ""Năng lượng mặt trời"",
  ""Dapan"": ""A""
 },
 {
  ""Cauhoi"": ""Các địa điểm nào sau đây là tài nguyên du lịch tự nhiên của nước ta:"",
  ""A"": ""Vinh Hạ Long"",
  ""B"": ""Chùa Một Cột"",
  ""C"": ""Cố Đô Huế"",
  ""Dapan"": ""A""
 }
]";
        ListQuestion = JsonConvert.DeserializeObject<List<DeFaultQuest>>(data);
    }


}

public class DeFaultQuest
{
    public string Cauhoi = "";
    public string A = "";
    public string B = "";
    public string C = "";
    public string D = "";
    public string Dapan = "";
}