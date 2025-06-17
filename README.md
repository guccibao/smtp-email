# 📧 Gmail Web App bằng Flask (SMTP + IMAP)

Một ứng dụng web đơn giản sử dụng Python Flask giúp bạn:
- 📤 Gửi email thông qua Gmail (SMTP)
- 📥 Đọc inbox Gmail mới nhất (IMAP)
- 🧑‍💻 Giao diện web thân thiện

---

## 🚀 Cách sử dụng

### 1. Cài đặt yêu cầu
```bash
pip install flask

### 2. Chạy ứng dụng
bash
python app.py
Sau đó mở trình duyệt và truy cập
http://127.0.0.1:5000

🔐 Gmail App Password là gì?
Google không cho phép đăng nhập Gmail trực tiếp bằng mật khẩu thông thường từ ứng dụng.
Bạn cần tạo App Password như sau:

Truy cập: https://myaccount.google.com/apppasswords

Đăng nhập, bật xác minh 2 bước nếu chưa có

Tạo App Password mới (chọn "Mail" và "Windows Computer")

Sao chép 16 ký tự và dán vào ứng dụng khi được yêu cầu
🛠️ Tính năng
Gửi email: nhập Gmail, App Password, người nhận, tiêu đề, nội dung

Đọc inbox: hiển thị 10 email mới nhất, đọc tiêu đề, nội dung

Tương thích Gmail

Chạy local không cần internet để frontend

