Các bước đưa dự án [ sapabase + blazor server ] lên render kết hợp docker
1. thực hiện tạo 1 file docker tự động bằng visual code
2. Thiết lập cấu hình môi trường cho sapabase trong appseting
3. lên render tạo dự án :
   +  1. Name: Tên dịch vụ — ví dụ: blazor-supabase-app
      2. Environment: Chọn: Docker
      3. Region: Chọn nơi gần Việt Nam nhất → Singapore
      4. Branch: Chọn nhánh chứa source code, thường là main hoặc master
      5.  Root Directory:Nếu Dockerfile nằm ở thư mục gốc của project → để trống/ Nếu nó nằm trong subfolder (ví dụ /src/MyApp) → điền đúng thư mục đó.
      6.  Thiết lập Environment Variables (Biến môi trường) Bấm vào tab Advanced → tìm mục Environment Variables, điền như sau:
            Key	Value
            SUPABASE_URL	https://xxx.supabase.co
            SUPABASE_KEY	your-secret-key
      7. Deploy
4. các bước kiểm tra chạy đúng đưới local bằng docker destop
   1. Thực hiện kiểm tra Dockerfile: # 1. Mở Terminal/Command Prompt và di chuyển đến thư mục gốc dự án
                                      cd đường_dẫn_đến_dự_án_của_bạn
                                      
                                      # 2. Xây dựng Docker image
                                      docker build -t blazorapp .
                                      
                                      # 3. Kiểm tra xem image đã được tạo chưa
                                      docker images

   2. Chạy và kiểm tra container: docker run -d -p 8080:8080 -e "Supabase__Url=xxxx" -e "Supabase__Key=xxxx" -e "ASPNETCORE_ENVIRONMENT=Development" --name fastdoapp-container yourprojectname
   3. # Kiểm tra xem container đang chạy không:  docker ps
   4. Dọn dẹp sau khi kiểm tra :
      # Dừng container: docker stop blazor-test
      # Xóa container: docker rm blazor-test
   5. Kiểm tra lỗi (nếu có):
       # Xem logs của container :docker logs blazor-test
       # Hoặc xem logs theo thời gian thực: docker logs -f blazor-test
    6. Mở trình duyệt và truy cập http://localhost:8080 hoặc http://localhost:8088
