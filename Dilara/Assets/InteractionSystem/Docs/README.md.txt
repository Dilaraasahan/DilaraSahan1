# README.md 

# Interaction System - [Dilara_Şahan]

## Kurulum
- Unity versiyonu: [6000.3.6f1]

## Nasıl Test Edilir
- TestScene'i açın
- Kontroller: [WASD = hareket ; E = NesneEtkilesimleri ; Mouse = Bakış/Yönlendirme,]
- Test senaryoları - Etkileşimli nesnelere bakıp/bakmadığınızdaki durumu test edin.
UI yönlendirmesi ile E tuşuna basarak nesnelerin durumunu gözlemleyin.  


## Mimari Kararlar
- Etkileşim için Raycast sistemi kullandım.Trigger kullansaydım mesafesine göre olacaktı,
oyuncunun baktığı yön için Raycast sistemi kullandım.
-IInteractable tabanlı yapı Player sınıfının objenin ne olduğunu bilmek zorunda kalmadan Interact 
metodunu çağırır.

## Ludu Arts Standartlarına Uyum
- Hangi standartları uyguladım
-Temel ilkeler başlığı altında isimlendirmelerin ingilizce olması, basit olması gibi kurallar.
-Sınıf içi private değişkenlerde m_ prefix kullanımı.
-Kelime ayırma kuralları PascalCase ve Pascal_Case yapısına uydum.
-Her klasör isminde bu PascalCase yapısına uydum.
-UI prefabları **P_UI_** ile başlıyor. 
-Tüm prefablar P_ ile başlıyor

- Zorlandığım noktalar
 -Hazır asset paketinden gelen Texture isimlendirmeleri standart dışıydı;
  zaman kısıtı nedeniyle ana mekaniklere odaklanılmış, bu kısımlar olduğu gibi bırakılmıştır.

## Bilinen Limitasyonlar
- Tamamlayamadığım özellikler
 -Switch

- Bilinen bug'lar
 - Sandık açıldıktan sonra oyuncunun anahtarı alması için üstüne zıplaması gerekiyor. Colliderları 
   çakışıyor
   

-İyileştirme Önerileri
  -Colliderlar çakıştığı için ve Canvas sisteminde aldığım hatalar çok zamanı aldığı için pratik 
   çözüm olması için anahtarı sandığın içine gömmek yerine yukarı taşıdım. Buna rağmen yine de bu 
    noktada oyuncunun üstüne zıplayarak alması gerekse de ilk haline kıyasla hiç olmamasından iyi halde
Anahtarın algılanmasını kolaylaştırmak için sandık açıldığı an sandığın layer'ı "Ignore Raycast" 
olarak değiştirilebilirdi



## Ekstra Özellikler
- Bonus olarak eklediklerim
  -Sandık açılma animasyonu. Hazır olarak vardı ama onların scriptlerini kullanmadım.
   Kendim bağladım. Idle'da open triggerı ekledim açılma koşulunu scriptte yazdım. Bunları birbirine 
   bağladım.
   -Toggle Door: Kapı sadece açılmakla kalmaz, anahtar alındıktan sonra her 'E' basışında açılıp 
   kapanma (Toggle) özelliğine sahiptir.

```
    Projeye Dair;
    -Projeye genel bir bakış olarak tüm eklenenleri bilinçli bir şekilde yaptım fakat
    Canvas'ın bu kadar zamanımı alması beklemediğim bir nokta oldu. Blueprint ve algoritmalar mantığını
    biliyor olmam kalan zamanımda doğru yönlendirmelerle kodları almamı sağladı. Projeye başlamadan önce
    ne yapacağımı direkt ilk prompt olarak verdim ve akış şeması verdiğim şekilde devam etti. Verilen 
    zamanın yeterli ve aslında baskısız olduğunu düşünüyorum.Sadece dediğim gibi Canvas problemi çok uzun sürdü.
    Zamanım kalsaydı düzgün bir oda leveli vb içinde UI tasarımlarının ve seslerin olduğu bir proje teslim
    ederdim. 
