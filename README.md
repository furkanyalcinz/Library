# Library
Projede kullanılan teknolojiler:
.Net Core Mvc, .Net Core Web API, JWT, Fluent Valiadation, Serilog, N katmanlı mimari, Generic Repository Design Pattern, Html, Bootstrap, JQuery, Entity Framework Core, Sql Server.

Projeyi başlatmak için;
Öncelikle SQL serverde Library adında bir database oluşturulmalı. Code First yaklaşım uygulandığından dolayı WebApi üzerinden DataAccess katmanına database migration yapılmalı bunun için;
Package-Manager consoledan add-migration initialMigration ve update-database komutları çalıştırılmalı.
Sonrasında Client projesi çalıştırılıp ardından WebApi projesi çalıştırılmalı.
https://localhost:44305/ adresi üzerinden siteye erişim sağlayabilirsiniz. 
Ana ekranda kitap listelerini göreceksiniz. Kitap ödünç alabilmek için kayıt oluşturmalısınız. Register ekranından kayıt olduktan sonra Login ekranında giriş yapabilirsiniz. Böylelikle kitap ödünç alabilirsiniz. Kitabı ödünç alırken geri vereceğiniz tarihi seçmelisiniz. Siteye yeni kitap eklemek için swagger weya postman üzerinden https://localhost:7047/api/Book/AddBook endpointe admin kullanıcısı ile istek atarak yeni kitap ekleyebilirsiniz. Kitap eklemeden önce Kategoriler oluşturulmalı. Kitap eklerken kategori id'sine ihtiyacınız olacak. 
