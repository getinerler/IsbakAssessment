# İsbak Assessment

İsbak Firması için Assessment. 

Kripto para verilerinin, CoinMarketCap API'sinden alınıp hem veritabanına kaydedildiği hem SignalR ile başka bir ASP.NET MVC Core projesine aktarıldığı konsol uygulaması. 

## Çalıştırma

1. IsbakAssessment ve FrontendApplication aynı anda çalışır durumda olmalı.

2. Bir SQL veritabanı, IsbakAssessment projesinin çalıştığı serverda çalışıyor olmalı. IsbakAssessment Program.cs'de veritabanı bilgileri güncellenmeli.

3. IsbakAssessment ScheduledJobService.cs dosyasındaki SendSignal metodu içindeki url, FrontentApplication projesinin url'i olarak güncellenmeli.