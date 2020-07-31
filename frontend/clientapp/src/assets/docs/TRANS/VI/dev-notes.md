<!-- Do not edit this file. It was translated by Google. -->
<h1> Xử lý các định dạng bảng điểm mới </h1>
<p> Mục tiêu cuối cùng là viết mã sẽ xử lý bất kỳ định dạng bảng điểm nào. Nhưng cho đến lúc đó, chúng ta cần viết mã tùy chỉnh để xử lý từng định dạng mới. Khi chúng ta có đủ các mẫu có định dạng khác nhau, chúng ta sẽ có thể viết mã chung tốt hơn. </p>

<p> Đây là các bước để xử lý các định dạng bản ghi mới: </p>

<ul>
<li>
<p> Lấy bảng điểm mẫu của cuộc họp chính phủ dưới dạng tệp pdf hoặc văn bản. </p>
</li>
<li>
<p> Đặt tên cho tệp như sau: "country_state_county_munIDIAality_agency_lingu-code_date.pdf". (hoặc .txt) Ví dụ: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Tạo một lớp mới với giao diện "ISpecificFix" trong dự án "ProcessTranscripts_Lib". </p>
</li>
<li>
<p> Đặt tên cho lớp là "country_state_county_munIDIAality_agency_lingu-code". Ví dụ: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Thực hiện phương thức lớp: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix () nhận văn bản bản ghi hiện có và trả về văn bản theo định dạng sau: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Khi lớp này được hoàn thành, WorkflowApp sẽ xử lý các bản sao mới khi chúng xuất hiện trong "DATAFILES / RECEIVED". </p>

<p> Ghi chú: </p>

<p> Chúng tôi sử dụng System.Reflection để khởi tạo lớp chính xác dựa trên tên của tệp sẽ được xử lý. </p>

<p> Xem lớp "USA_PA_Phil &lt;_Phil &lt;_CityCferences_en" trong ProcessTranscripts_Lib để biết ví dụ. Bạn có thể hiểu rõ hơn những gì lớp này đang làm bằng cách xem các dấu vết của tệp nhật ký trong "workfolder" được truyền dưới dạng đối số cho Fix (). </p>

<p> Chúng tôi không trích xuất thông tin sau đây, nhưng cuối cùng chúng tôi sẽ muốn làm điều này. </p>

<ul>
<li> Cán bộ tham dự </li>
<li> Hóa đơn và nghị quyết được giới thiệu </li>
<li> Kết quả bỏ phiếu </li>
</ul>
<p> Austin, TX - Hoa Kỳ cũng có bảng điểm các cuộc họp công khai trực tuyến. Một lớp đã được tạo có tên là "USA_TX_TravisCounty_Austin_CityCeree_en" trong ProcessTranscripts_Lib. Nhưng phương thức Fix () đã không được thực hiện. Bảng điểm có thể được lấy từ trang web của họ: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, Hội đồng thành phố TX</a> </p>
<h1> Sửa đổi Bảng điều khiển khách hàng </h1><h2> Thêm thẻ cho tính năng mới </h2>
<ul>
<li> Tại dấu nhắc thiết bị đầu cuối, di chuyển đến thư mục: FrontEnd / ClientApp </li>
<li> Nhập: ng tạo thành phần tính năng của bạn </li>
<li> Thêm chức năng của bạn vào các tệp trong: FrontEnd / ClientApp / src / app / your-Feature </li>
<li> Chèn phần tử thẻ gm-small-card hoặc gm-Large-card mới trong app / dash-main / dash-main.html. </li>
<li> Sửa đổi biểu tượng, iconcolor, tiêu đề, vv của thành phần thẻ. </li>
<li> Nếu bạn cần truy cập vào tên của vị trí và đại lý hiện được chọn trong bộ điều khiển của bạn: 
<ul>
<li> Thêm các thuộc tính đầu vào vị trí và đại lý cho thành phần tính năng của bạn </li>
<li> Thêm vị trí và thuộc tính @Input trong bộ điều khiển của bạn. </li>
</ul></li>
</ul>
<p> (Xem các mẫu khác trong dash-main.html) </p>
<h2> Sắp xếp lại thẻ </h2><ol>
<li> Mở tệp: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Thay đổi vị trí thẻ bằng cách thay đổi vị trí của các thành phần thẻ gm-small-card hoặc gm-Large-card trong tệp này. </li></ol><h1> Ghi nhật ký </h1>
<p> Các tệp nhật ký cho WebApp và WorkflowApp nằm trong thư mục "log" ở thư mục gốc của giải pháp. </p>

<ul>
<li> "nlog-all- (ngày) .log" chứa tất cả các thông điệp tường trình bao gồm cả hệ thống. </li>
<li> Tệp "nlog-own- (date) .log" chỉ chứa các thông báo ứng dụng. </li>
</ul>
<p> Ở đầu nhiều tệp thành phần trong ClientApp, một "NoLog" được xác định. Thay đổi giá trị của nó từ true thành false để bật ghi nhật ký giao diện điều khiển cho thành phần đó. </p>
<h1> Xây dựng tập lệnh </h1>
<p> Tập lệnh xây dựng Powershell có thể được tìm thấy trong Tiện ích / PsScripts </p>

<ul>
<li> BuildPublishAndDeploy.ps1 -Call các tập lệnh khác để xây dựng một bản phát hành và triển khai nó. </li>
<li> Build-ClientApp.ps1 - Xây dựng các phiên bản sản xuất của ClientApp </li>
<li> Publish-WebApp.ps1 - Xây dựng thư mục "xuất bản" của WebApp </li>
<li> Copy-ClientAssets.ps1 - Sao chép tài sản ClientApp vào thư mục wwwroot của WebApp </li>
<li> Deploy-PublishFolder.ps1 - Triển khai thư mục xuất bản đến máy chủ từ xa </li>
<li> Tạo tệp README.md cho Gethub từ các tệp tài liệu </li>
</ul>
<p> Deploy-PublishFolder.ps1 triển khai phần mềm cho govmeeting.org, sử dụng FTP. Thông tin đăng nhập FTP nằm trong tệp apps settings.Development.json trong thư mục SECRETS. Nó chứa FTP và các bí mật khác để sử dụng trong phát triển. Dưới đây là phần của tệp này được sử dụng bởi FTP: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>