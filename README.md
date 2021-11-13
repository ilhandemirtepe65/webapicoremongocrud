# Proje Hakkında
* Proje Çalıştırılması
  *  Bilgisayarınızda Redis ve Mongo Db olmalıdır. Ben dockerdan imageleri pull edip container ayağa kaldırdım.Sizin bilgisayarınızda Redis ve Mongo kurulu ise Dockerdan imageleri çekmeye gerek yoktur. Redis 6379 ve Mongo 27107 portlarında çalışmaktadır. 
  *  Proje kod first mantığı ile çalışmaktadır. Yani projeyi çalıştırmak için DB oluşturmanıza gerek yoktur.Kayıt insert attığınız zaman  *ECommerceDb  db si oluşacaktır .
  *  Projede redis kullanılmıştır . GetProduct ve GetAllProduct önce redise bakılıyor eğer rediste varsa redisten getiriyor.Eğer redisten yoksa Mongodan çekip önce redise yazıyorum sonra Dbden çekiyorum . 2. sefer aynı istekte bulunduğum zaman bu sefer redisten gelecek data. Redisteki kayıtların yaşama süresi 5 dakikadır
  * Prodcutlar ve Categoriler CRUD işlemleri yapılmıştır.Swagger örnekleri ektedir
 
* Kullanılan Yapılar
  *  Fluent Validation
  *  AutoMapper
  *  Katmanlı Mimari
  *  Dependency Injection
  *  Object Oriented Programing
  *  Generic Repository Pattern
  *  Solid Prensipleri
  *  MediatR Kütüphanesi ve CQRS Pattern
*Not : Geliştirilmeye devam edilmektedir
 ## Redise Yazma Ve Okuma İşlemleri
 ![image](https://user-images.githubusercontent.com/80510214/140640655-0d37a1f4-6e7c-4f73-8f30-fc38eb00e7d6.png)
![image](https://user-images.githubusercontent.com/80510214/140640683-0e4afa3f-3fae-4fc5-8276-f221746302be.png)



 ## Kategori Crud İşlemleri
![image](https://user-images.githubusercontent.com/80510214/140624154-93ac8f4a-0e49-47a9-859b-821c90c716db.png)
![image](https://user-images.githubusercontent.com/80510214/140624178-969e812b-56d2-45ea-8b70-c35d28df05a1.png)
![image](https://user-images.githubusercontent.com/80510214/140624265-5f54049c-c9a8-4d78-98f2-8cea84294abf.png)
![image](https://user-images.githubusercontent.com/80510214/140624372-20dc635a-5fbd-4599-99eb-b17750142e1c.png)
![image](https://user-images.githubusercontent.com/80510214/140624379-a22247ed-733f-4844-b38a-0afca37d13c2.png)
![image](https://user-images.githubusercontent.com/80510214/140624436-02429f8b-68ca-44be-92b1-7f084afe99fc.png)

## Product Crud İşlemleri
![image](https://user-images.githubusercontent.com/80510214/140640346-668534a9-5d70-442a-8d1e-443048174058.png)
![image](https://user-images.githubusercontent.com/80510214/140640360-633524b2-cfdc-4295-890e-69f480a5125d.png)
![image](https://user-images.githubusercontent.com/80510214/140640384-08447a76-09a7-4fe7-83fd-c0f95d7f0c9b.png)
![image](https://user-images.githubusercontent.com/80510214/140640526-2842017b-40b5-4eb2-8c8a-ac32a3b22d20.png)
![image](https://user-images.githubusercontent.com/80510214/140640601-bf431f59-5792-450e-af86-d306a2b4568e.png)





