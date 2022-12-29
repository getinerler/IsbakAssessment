# İsbak Assessment

İsbak Firması için Assessment. 

Kripto para verilerinin, CoinMarketCap API'sinden alınıp hem veritabanına kaydedildiği hem SignalR ile bir ASP.NET MVC Core projesine aktarıldığı konsol uygulaması. 

## Çalıştırma

1. IsbakAssessment ve FrontendApplication aynı anda çalışır durumda olmalı.

2. Bir SQL veritabanı, IsbakAssessment projesinin çalıştığı serverda çalışıyor olmalı. IsbakAssessment Globals.cs'deki ConnectionString, veritabanı bilgileri ile güncellenmeli.

3. IsbakAssessment Globals.cs dosyasındaki FrontendProjectUrl, FrontentApplication projesinin url'i olarak güncellenmeli.