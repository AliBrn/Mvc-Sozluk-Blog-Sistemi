-- ========================================================
-- Proje: MVC Proje Kampı (Sözlük & Blog Yönetim Sistemi)
-- Veritabanı: DbMvcKamp
-- Oluşturulma Tarihi: 2026-10-08 21:53:02
-- ========================================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DbMvcKamp')
BEGIN
    CREATE DATABASE [DbMvcKamp];
END
GO
USE [DbMvcKamp];
GO

-- --------------------------------------------------------
-- Tablo: Categories
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Categories]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(50) NULL,
    [CategoryDescription] nvarchar(200) NULL,
    [CategoryStatus] bit NOT NULL,
    CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Categories] ON;
INSERT INTO [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES
    (1, N'Eğitim', N'Egitim Kategorisi', 1),
    (2, N'Spor', N'Spor Kategorisi', 1),
    (3, N'Kitap', N'Kitap Kategorisi ', 1),
    (4, N'Film', N'Film Kategorisi', 0),
    (5, N'Yemek', N'Yemek Kategorisi', 1),
    (6, N'Tiyatro', N'Tiyatro Kategorisi', 0),
    (17, N' Müzik', N'Müzik Kategorisi', 0),
    (18, N'Yüzme', N'Yüzme Kategorisi', 0);
SET IDENTITY_INSERT [dbo].[Categories] OFF;
GO

-- --------------------------------------------------------
-- Tablo: Writers
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Writers]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Writers] (
    [WriterID] int IDENTITY(1,1) NOT NULL,
    [WriterName] nvarchar(50) NULL,
    [WriterSurName] nvarchar(50) NULL,
    [WriterImage] nvarchar(250) NULL,
    [WriterMail] nvarchar(200) NULL,
    [WriterPassword] nvarchar(200) NULL,
    [WriterAbout] nvarchar(100) NULL,
    [WriterTitle] nvarchar(100) NULL,
    [WriterStatus] bit NOT NULL,
    CONSTRAINT [PK_dbo.Writers] PRIMARY KEY CLUSTERED ([WriterID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Writers] ON;
INSERT INTO [dbo].[Writers] ([WriterID], [WriterName], [WriterSurName], [WriterImage], [WriterMail], [WriterPassword], [WriterAbout], [WriterTitle], [WriterStatus]) VALUES
    (1, N'Stefan', N'Zweig', N'https://png.pngtree.com/png-vector/20230728/ourmid/pngtree-writer-clipart-cartoon-bearded-man-with-pencil-vector-png-image_6818170.png', N'zweig21@gmail.com', N'2121', N'Almanya doğumlu, eski şiirci ve alman kültürüne sahip önemli bir yazardır.', N'Yazar', 0),
    (2, N'Baran', N'Alıcaklı', N'https://upload.wikimedia.org/wikipedia/commons/a/aa/A_Humble_Cartoon_Businessman.svg?utm_source=commons.wikimedia.org&utm_campaign=index&utm_content=original', N'baran23@gmail.com', N'2323', N'Yazılımcı ve müzik sever biri bunların yanında gitar çalmakla meşgul müzisyen', N'Yapay Zeka Uzmanı', 0),
    (3, N'Hasan', N'Karaca', N'https://static.vecteezy.com/system/resources/thumbnails/073/839/915/small_2x/businessman-cartoon-character-in-suit-and-tie-holding-a-briefcase-professional-corporate-worker-illustration-vector.jpg', N'hasan38@gmail.com', N'3838', N'Hobiler arasında yüzme var ve kitap okuma delisi  bir bireydir.', N'Prof Dr.', 0),
    (4, N'Füsun', N'Yerli', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQJ-EpV5AdURS-q46KhTSysSBEfnYDp2s_7eGaK61LRvw&s=10', N'fyerli@gmail.com', N'2121', N'Kahveler aram çok iyidir .Kitaplar tek varlıgım.', N'dİJİTAL PAZARLAMA UZMANI', 1),
    (5, N'Merve', N'Kaya', N'https://t3.ftcdn.net/jpg/09/37/60/02/360_F_937600227_RlGrfMocC7StqnaR1CZPb4Bs2xjKfy4c.jpg', N'merve23@gmail.com', N'3421', N'Almanya doğumlu, eski şiirci ve alman kültürüne sahip önemli biri', N'Yazar', 1),
    (6, N'Ahmet', N'Yesil', N'https://artwork.presentermedia.com/clipart/00030000/30857/casual_guy_icon_bust_800_wht.jpg', N'yesil2@gmail.com', N'2333', N'Hayattan öykü anlatır iyi yazar ve iyi konuşan bir diksiyon hocası.', N'Yazar', 1),
    (7, N'Admin', N'Adminn', N'https://img.magnific.com/free-photo/3d-cartoon-portrait-person-practicing-law-related-profession_23-2151419548.jpg?semt=ais_hybrid&w=740&q=80', N'admin@gmail.com', N'12345', N'Admin Tüm sistemi yöneten  yetkili kişi', N'Admin', 1),
    (8, N'Berna', N'Yeşim', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQXrRAwZ0fPpuXTupPTPtv6fm3mv1A4Uarr4FgwVCvLw7RHj-EVXaloe7g&s=10', N'berna11@gmail.com', N'1111', N'Dünyayı Tanımak', N'Yazılım Geliştirici', 1),
    (9, N'Ali', N'Baran', NULL, N'baranali320@gmail.com', N'4444', NULL, N'Analist ', 1),
    (10, N'ES', N'BS', NULL, N'al21@gmail.com', N'1111', NULL, N'dİJİTAL PAZARLAMA UZMANI', 1),
    (11, N'Aylin', N'Kaya', NULL, N'ayle@gmail.com', N'1111', NULL, N'Analist Uzman', 1),
    (12, N'Ahmet ', N'Taş', NULL, N'ahmet32@gmail.com', N'3232', NULL, N'Endüstri Mühendisi', 1);
SET IDENTITY_INSERT [dbo].[Writers] OFF;
GO

-- --------------------------------------------------------
-- Tablo: Headings
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Headings]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Headings] (
    [HeadingID] int IDENTITY(1,1) NOT NULL,
    [HeadingName] nvarchar(50) NULL,
    [HeadingDate] datetime NOT NULL,
    [CategoryID] int NOT NULL,
    [WriterID] int NOT NULL,
    [HeadingStatus] bit NOT NULL,
    CONSTRAINT [PK_dbo.Headings] PRIMARY KEY CLUSTERED ([HeadingID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Headings] ON;
INSERT INTO [dbo].[Headings] ([HeadingID], [HeadingName], [HeadingDate], [CategoryID], [WriterID], [HeadingStatus]) VALUES
    (1, N'Satranç', N'2025-08-27 00:00:00', 3, 1, 1),
    (2, N'Yemeklerin Sırrı', N'2026-08-23 00:00:00', 5, 2, 1),
    (3, N'Yemek Pişirmenin Süresi', N'2026-01-29 00:00:00', 5, 4, 0),
    (4, N'Hayat Güzeldir Her Zaman', N'2005-03-21 00:00:00', 4, 1, 1),
    (7, N'Romeo ve Juliet', N'2001-05-12 00:00:00', 6, 3, 1),
    (8, N'Yeni Yerleşmiş Hayatlar', N'2026-09-07 00:00:00', 6, 6, 0),
    (9, N'Olağanüstü Bir Gece', N'2026-09-17 00:00:00', 3, 1, 1),
    (10, N'Amok Koşucusu', N'2026-09-17 00:00:00', 3, 1, 1),
    (11, N'Rapunzel', N'2026-09-17 00:00:00', 6, 1, 0),
    (12, N'Yemeklerin Sunumu', N'2024-06-05 00:00:00', 5, 2, 1),
    (13, N'Big Bang Teorisi', N'2026-09-21 00:00:00', 3, 2, 1),
    (14, N'Dünya Kupası Finali', N'2026-09-21 00:00:00', 2, 2, 1),
    (15, N'Dünyanın Bilinmeyen Katmanları', N'2026-09-21 00:00:00', 1, 3, 1),
    (16, N'Pirincin Biyolojik  İşleyişi', N'2026-09-21 00:00:00', 5, 4, 1),
    (17, N'Geçmişin Bedeli', N'2026-09-30 00:00:00', 3, 1, 0),
    (18, N'Bilinmeyen Bir Kadının Mektubu', N'2026-09-30 00:00:00', 1, 1, 1),
    (19, N'xx', N'2026-10-08 00:00:00', 1, 2, 0),
    (20, N'cccc', N'2026-10-08 00:00:00', 1, 2, 0);
SET IDENTITY_INSERT [dbo].[Headings] OFF;
GO

-- --------------------------------------------------------
-- Tablo: Contents
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Contents]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Contents] (
    [ContentID] int IDENTITY(1,1) NOT NULL,
    [ContentValue] nvarchar(1000) NULL,
    [ContentDate] datetime NOT NULL,
    [HeadingID] int NOT NULL,
    [WriterID] int NULL,
    [ContentStatus] bit NOT NULL,
    CONSTRAINT [PK_dbo.Contents] PRIMARY KEY CLUSTERED ([ContentID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Contents] ON;
INSERT INTO [dbo].[Contents] ([ContentID], [ContentValue], [ContentDate], [HeadingID], [WriterID], [ContentStatus]) VALUES
    (1, N'Satranç yokluktaki aslında bir oyundan çok bir hayat şekli', N'2026-07-30 00:00:00', 1, 1, 0),
    (2, N'Satranç bir oyun mu yoksa aslında o anki  bir düşünce biçimi mi', N'2026-09-13 00:00:00', 1, 3, 0),
    (3, N'Aslında yemeklerin  lezzeti pişirme deki zamanlamadır', N'2026-06-07 00:00:00', 3, 4, 0),
    (4, N'Dramatik bir film olsada o zamanın şartlarına göre o yoklukta hala çoçuğunu güldürebilen bir babanın hikayesi', N'2025-05-05 00:00:00', 4, 2, 0),
    (5, N' Buna benzeyen yeni filmler çekilmeli günümüz filmleri bu tarz filmin yanında sadece görsel efekt', N'2026-04-03 00:00:00', 4, 2, 1),
    (6, N'Çok güzel bir kitap herkesin okumasını şiddetle tavsiye ederim.', N'2026-09-23 00:00:00', 1, 2, 1),
    (7, N'Filmi de var onuda izlemenizi tavsiye ederim.', N'2026-09-23 00:00:00', 1, 2, 1),
    (8, N'Big Bang patlamasında dolayı dünyanını bu derece kusurz bir nizam ve yörüngede bulunması gerçekten bir şaheser.', N'2026-09-23 00:00:00', 13, 1, 1),
    (9, N'Bu maç şaibelerle dolu bir maç  resmen arjantin final oynatılmak için çeşitli yollar denediler .', N'2026-09-23 00:00:00', 14, 1, 1),
    (11, N'Yemekler sadece pişirmeyle değil genel olarak baharat kullanımıda çok önemli', N'2023-05-04 00:00:00', 2, 5, 1),
    (12, N'Bu kitap  platonik bir aşkın  anlatan dram dolu bir zweig eseridir.', N'2026-09-30 00:00:00', 18, 1, 1),
    (13, N'Yemekler sadece  bir doyurma ihtiyacı için değil bir sanat için de yapılan bir kültür meselesidir.Bunun en yaygın örneği yemek kültürü olarak Meksikalılar,İtalyanlar,Fransızlar .', N'2026-09-30 00:00:00', 2, 1, 1),
    (14, N'Çok güzel bir kitap okumayı şiddetle tavsiye ederim.', N'2026-10-04 00:00:00', 1, 2, 1),
    (15, N'Yemekle ilgili  yeni yazılar bekliyoruz', N'2026-10-08 00:00:00', 3, 2, 1);
SET IDENTITY_INSERT [dbo].[Contents] OFF;
GO

-- --------------------------------------------------------
-- Tablo: Abouts
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Abouts]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Abouts] (
    [AboutID] int IDENTITY(1,1) NOT NULL,
    [AboutDetails1] nvarchar(1000) NULL,
    [AboutDetails2] nvarchar(1000) NULL,
    [AboutImage1] nvarchar(100) NULL,
    [AboutImage2] nvarchar(100) NULL,
    [AboutStatus] bit NOT NULL,
    CONSTRAINT [PK_dbo.Abouts] PRIMARY KEY CLUSTERED ([AboutID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Abouts] ON;
INSERT INTO [dbo].[Abouts] ([AboutID], [AboutDetails1], [AboutDetails2], [AboutImage1], [AboutImage2], [AboutStatus]) VALUES
    (1, N'Yazarlar için özellikle  kullanımı oldukça kolaydı', N'Hakkımda 2', N'görsel1', N'resim1', 1),
    (2, N'Yeni içerikler ve güncellemeler eklenerek yapı daha da temize çekilcek', N'Hakkımda 2', N'görsel2', N'resim2', 1),
    (3, N'Her tasarımda  mobile uygun tasarlanmış', N'Hakkımda 2', N'görsel3', N'resim3', 1),
    (4, N'Yazar ve Admin Paneli  kullanıcı tüm isteklerini karşılayacak şekilde tasarlanmış', N'Hakkımda 2', N'görsel4', N'resim4', 1),
    (5, N'Her detay eksiksiz tamamlanmaya çalışmıştır', N'Hakkımda 2', N'görsel5', N'resim5', 1),
    (6, N'Güncellemeler geldikçe  modern site olarak daha rahat yönetilcek', N'Hakkımda 2', N'görsel6', N'resim6', 1),
    (7, N'Sitede Aktif 100 yazar var', N'Hakkımda 2', N'görsel7', N'resim7', 1),
    (8, N'Bu çok iyi bir yazı ve bunla ilgili işlemler ypaılır', N'Hakkımda 2', N'görsel8', N'resim8', 1),
    (9, N'Yeni Değerler Eklencek', N'Hakkımda 2', N'görsel9', N'resim9', 1),
    (10, N'Gönderiler Gayet Güzel olmuş', N'Hakkımda 2', N'görsel10', N'resim10', 1);
SET IDENTITY_INSERT [dbo].[Abouts] OFF;
GO

-- --------------------------------------------------------
-- Tablo: Contacts
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Contacts]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Contacts] (
    [ContactID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50) NULL,
    [UserMail] nvarchar(50) NULL,
    [Subject] nvarchar(50) NULL,
    [Message] nvarchar(max) NULL,
    [ContactDate] datetime NOT NULL,
    [IsRead] bit NOT NULL,
    CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED ([ContactID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON;
INSERT INTO [dbo].[Contacts] ([ContactID], [UserName], [UserMail], [Subject], [Message], [ContactDate], [IsRead]) VALUES
    (1, N'Ali Gün', N'algun21@gmail.com', N'Yazarlar Bakış Açısı', N'Her yazar mutlaka okuması gereken temel aksiyon ve konuşmalar olmalı', N'2023-09-15 00:00:00', 1),
    (2, N'Nazlı Yerel', N'nazz12@gmail.com', N'Yapay Zeka Gelişimi', N'Yapay zeka sadece bir otonom kontrol süreçten daha büyük sorunlar getirmekte.', N'2021-08-17 00:00:00', 1),
    (3, N'Ayşe', N'Ayse23@gmail.com', N'Site Planlama', N'Site genel olarak güzel tasarlanmış ancak hala  yazılar çok net okunmuyor ayarlamakda sorun yaşıyorum lütfen buna göre aksiyon alır mısınız.', N'2026-09-29 22:02:32', 1),
    (4, N'Aslı Merve', N'asli@gmail.com', N'Site Ayarı', N'Denemeler DAHA da güncel hale getireilebilir', N'2026-09-29 22:08:32', 0),
    (5, N'berk', N'berk@gmail.com', N'Ayarlar', N'Değişiklik güncelleme boyutu  iyi olmuş', N'2026-09-29 22:08:53', 1),
    (6, N'Burak', N'burak2@gmail.com', N'MVC SÖZLÜK', N'Siteniz gayet güzel olmuş elinize sağlık', N'2026-09-29 22:23:57', 1),
    (7, N'berk', N'berk@gmail.com', N'Yazılar', N'Siteniz yazı olarak   çok baskın renkte biraz daha açabilirsiniz', N'2026-10-01 16:35:00', 1);
SET IDENTITY_INSERT [dbo].[Contacts] OFF;
GO

-- --------------------------------------------------------
-- Tablo: ImageFiles
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[ImageFiles]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[ImageFiles] (
    [ImageID] int IDENTITY(1,1) NOT NULL,
    [ImageName] nvarchar(100) NULL,
    [ImagePath] nvarchar(250) NULL,
    CONSTRAINT [PK_dbo.ImageFiles] PRIMARY KEY CLUSTERED ([ImageID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[ImageFiles] ON;
INSERT INTO [dbo].[ImageFiles] ([ImageID], [ImageName], [ImagePath]) VALUES
    (1, N'Amsterdam', N'/AdminLTE-3.0.4/ImageFile/Amsterdam.jpg'),
    (2, N'Barcelona', N'/AdminLTE-3.0.4/ImageFile/Barcelona.jpg'),
    (3, N'Berlin', N'/AdminLTE-3.0.4/ImageFile/Berlin.jpg'),
    (4, N'Bükreş', N'/AdminLTE-3.0.4/ImageFile/Bükreş.jpg'),
    (5, N'Çin', N'/AdminLTE-3.0.4/ImageFile/Chine.jpg'),
    (6, N'Londra', N'/AdminLTE-3.0.4/ImageFile/Londra.jpeg'),
    (7, N'Seul', N'/AdminLTE-3.0.4/ImageFile/Seul.jpg'),
    (8, N'New York', N'/AdminLTE-3.0.4/ImageFile/New york.jpg'),
    (9, N'Pekin', N'/AdminLTE-3.0.4/ImageFile/Pekin.jpeg'),
    (10, N'Venedik', N'/AdminLTE-3.0.4/ImageFile/Venedik.jpeg'),
    (11, N'Porto', N'/AdminLTE-3.0.4/ImageFile/Porto.jpg'),
    (12, N'Tokyo', N'/AdminLTE-3.0.4/ImageFile/Tokyo.jpg'),
    (13, N'Dubai', N'/AdminLTE-3.0.4/ImageFile/Dubai.jpg'),
    (14, N'Akropolisi', N'/AdminLTE-3.0.4/ImageFile/Yunanistan.jpg'),
    (15, N'Chichén Itzá', N'/AdminLTE-3.0.4/ImageFile/Meksika.jpg');
SET IDENTITY_INSERT [dbo].[ImageFiles] OFF;
GO

-- --------------------------------------------------------
-- Tablo: Messages
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Messages]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Messages] (
    [MessageID] int IDENTITY(1,1) NOT NULL,
    [SenderMail] nvarchar(50) NULL,
    [ReceiverMail] nvarchar(50) NULL,
    [Subject] nvarchar(100) NULL,
    [MessageContent] nvarchar(max) NULL,
    [MessageDate] datetime NOT NULL,
    [MessageIsRead] bit NOT NULL,
    [IsDraft] bit NOT NULL,
    CONSTRAINT [PK_dbo.Messages] PRIMARY KEY CLUSTERED ([MessageID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Messages] ON;
INSERT INTO [dbo].[Messages] ([MessageID], [SenderMail], [ReceiverMail], [Subject], [MessageContent], [MessageDate], [MessageIsRead], [IsDraft]) VALUES
    (1, N'baran23@gmail.com', N'admin@gmail.com', N'Yazılım Gelişimi', N'Yazılımdaki Eksiklerin dolayı siteye bazı veriler ekleyemiyorum', N'2021-03-15 00:00:00', 0, 0),
    (2, N'hasan38@gmail.com', N'baran23@gmail.com', N'Yazılımla alakalı yazı eksikliği', N'Bazı konular tam netleştirmeden kısa özet geçtiniz bu yazılım dünyasındaki önemli eksiklerden biri ', N'2020-01-11 00:00:00', 1, 0),
    (3, N'fyerli@gmail.com', N'admin@gmail.com', N'Siteye  Yeni İçerik Ekleyemiyorum', N'Dünden beridir  eklemek istediğim bir yazı hakkında  sürekli hata alıp durmaktayım lütfen  ilgilenir misinz', N'2003-05-05 00:00:00', 1, 0),
    (5, N'fyerli@gmail.com', N'merve23@gmail.com', N'Yazımı İnceler Misin', N'Dün yeni bir yazı ekledim ancak kısa sürelik kalabildi ekran görüntüsü böyle sence bu yazdıa eksikler neler bu konu hakkında feedback bekliyorum', N'2015-05-16 00:00:00', 1, 0),
    (8, N'merve23@gmail.com', N'admin@gmail.com', N'Site Güncellemesi', N'Bu sitede sürekli güncelleme saatiyle ilgili önceden uyarı yapar msınıız bu yüzden yazılarımızı kaç gündür paylaşcağım zaman güncellemeye takılıyor', N'2016-04-15 00:00:00', 1, 0),
    (9, N'admin@gmail.com', N'baran23@gmail.com', N'Güvenlik Uyarısı', N'Hesabınız birden fazla cihazda oturum açılmakta bu yüzden  güvenlik nedeniyle size ait olmayan oturumları kaldırmanız sizin açınızdan daha güvenli', N'2009-03-12 00:00:00', 1, 0),
    (10, N'zweig21@gmail.com', N'baranali320@gmail.com', N'Deneme Sürümü', N'Yapmış oldugunuz site genel olarak güzel ancak bu kadar aktif olarak kullanılması ve birlikte yönetim zorlugu aynı anda birden fazla cihazda kullanımı zor olabiliyor bu konuyla ilgili düzeltme yaparsanız çok memnun oluruz.', N'2026-09-11 00:00:00', 1, 0),
    (11, N'hasan38@gmail.com', N'admin@gmail.com', N'Yazılar', N'Maalesef yazmış oldugum yazıların bazıları hala aktif&nbsp; olarak yayınlanmadı sunucularınızdan kaynaklı işlemler oldugunda&nbsp; &nbsp;kaynaklı uyarıda bulundunuz bu sorunu ne zaman çözeceksiniz bunla ilgili yapmam gereken sorumluluğu belli eder misiniz', N'2026-09-11 00:00:00', 0, 0),
    (17, N'yesil2@gmail.com', N'admin@gmail.com', N'Sorun', N'Siteye Giriş  yapamıyorum engelleyip login atıyor yardımcı olun', N'2002-04-15 00:00:00', 0, 0),
    (18, N'admin@gmail.com', N'yesil2@gmail.com', N'Çözüm', N'Sistemde uzun süre deneme yaptıgınız için hesap güvenlik nedeniyle askıya alındı 3 saat sonra tekrar deneyin çözülcektir', N'2002-04-15 00:00:00', 0, 0),
    (20, N'baran23@gmail.com', N'yesil2@gmail.com', N'Yazı İçerik', N'Yazınız çok güzel olmuş daha önce buna benzer bir anlatım  yazan olmadı bu konuda tebrik ederim', N'2003-12-05 00:00:00', 0, 0),
    (22, N'baran23@gmail.com', N'fyerli@gmail.com', N'İçeriğiniz Eksikler', N'Bazı başlıklarınızı üstün körü anlatmışssınız yeni bir kullanıcı olarak baktıgımda içeriğini anlamak çok kolay değil  tavsiye olarak yorum yaptım.', N'2010-11-05 00:00:00', 1, 0),
    (24, N'fyerli@gmail.com', N'baran23@gmail.com', N'Sorun Kaynağı', N'Yaptıgınız yorum için Teşekkür ederim tam olarak hangi kısımda bu yorumu bahsettiniz detay verir misinz buna göre aksiyon almaya çalışırım', N'2010-11-06 00:00:00', 1, 0),
    (28, N'baran23@gmail.com', N'fyerli@gmail.com', N'Yazı Tespiti', N'Makale yazınınzdaki  ilk konu yapay zeka gelişimi  ve insan beynine benzeyen yönüyle derin sinir ağları çok soyut kalıyor burdaki genel ağırlık ve aktivasyon fonksiyonları biraz daha detaylandırıp görsel kullanmanız kullanıcılar ve yarın bir gün geriye döndüğünüzde alıntı makalede kullanılabilcek güzel bir yazı olabilir teşekkürler iyi günler dilerim.', N'2010-11-06 00:00:00', 0, 0),
    (29, N'baran23@gmail.com', N'hasan38@gmail.com', N'Yazı Boyutu', N'Makalenizdeki yazı boyutları bilimsel makaleye göre çok farklılık göstermekte bundan dolayı değiştirmenizi tavsiye ederim.', N'2026-09-18 00:00:00', 0, 0),
    (30, N'baran23@gmail.com', N'hasan38@gmail.com', N'Yazı Boyutu', N'Makalenizdeki yazı tipi ve boyutu bilimsel makale yazılarına göre oldukça farklı bu konuda kullanıcıları yanıltabilir örnek makale açısından tekrar düzeltir misiniz.', N'2026-09-18 00:00:00', 0, 0),
    (31, N'baran23@gmail.com', N'gizem@hotmail.com', N'Dergi Park Yazısı', N'Yeni Yazmış oldugunuz yazı çok beğendim bu alanla ilgili daha çok çalışmanızı sabırsızllıkla bekliyorum', N'2026-09-18 00:00:00', 0, 0),
    (32, N'fyerli@gmail.com', N'hasan38@gmail.com', N'Yazı Hakkında', N'Yazmış oldugunu  yazı çok güzel olmuş elinize sağlık.
                    ', N'2026-09-24 00:00:00', 0, 0),
    (33, N'baran23@gmail.com', N'fyerli@gmail.com', N'Makale Yazınız', N'Makale yazınızla ilgili açıkladıgınız bilgiler gerçekten çok değerli ancak hala soyut kalan yerler var daha detaylandırmanız okuyucular açısından faydalı olabilir iyi günler.                               
       ', N'2026-09-24 00:00:00', 0, 0),
    (34, N'admin21@gmail.com', N'baranali320@gmail.com', N'İçerikle alakalı', N'Yazmış oldugunuz yazıyı biraz daha&nbsp; &nbsp;tüm yaşlara hitap edecek şekilde güncellerseniz çok iyi olur.', N'2026-10-01 16:32:34', 0, 0),
    (36, N'baranali320@gmail.com', N'admin21@gmail.com', N'Bilgilendirme', N'Teşekkür ederim bilgiledirdiğiniz için ancak bu konuyla ilgili şu açıklığı dile getirmek isterim bu konu zaten her yaşın anlayacağı bir kapasitede değil ve iç olaylar birazcık daha hitap kitlesi olarak  orta yaş sınıfı hedef alınmıştır', N'2026-10-01 00:00:00', 1, 0),
    (40, N'fyerli@gmail.com', N'admin21@gmail.com', N'Değerlendirme', N'Güzel bir tasarım yaptınız', N'2020-12-03 00:00:00', 1, 0),
    (42, N'yesil2@gmail.com', N'admin21@gmail.com', N'Giriş', N'Sitede  kullanıcı adımda sorun var', N'2020-10-04 00:00:00', 0, 0),
    (44, N'admin21@gmail.com', N'yas21@gmail.com', N'Dosya Ayarları', N'Yüklediğiniz görsel ayarlar gereğinden fazla büyük lütfen bunları düzeltelim önerilen mb göre', N'2026-10-01 22:27:29', 0, 0),
    (45, N'admin21@gmail.com', N'fersa@gmail.com', N'Deneme', N'Yeni güncellemelerden haberdar olmak için&nbsp; bildirimleri açık tutalım.', N'2026-10-01 22:29:47', 0, 0),
    (48, N'baran23@gmail.com', N'kate21@gmail.com', N'Yazılar', N'Deneme  yazı tipini düzeltir misin', N'2026-10-04 16:36:49', 0, 0),
    (51, N'baran23@gmail.com', N'baranali320@gmail.com', N'xd', N'                               
                    ', N'2026-10-08 19:45:27', 0, 1);
SET IDENTITY_INSERT [dbo].[Messages] OFF;
GO

-- --------------------------------------------------------
-- Tablo: Admins
-- --------------------------------------------------------
IF OBJECT_ID(N'dbo.[Admins]', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Admins] (
    [AdminID] int IDENTITY(1,1) NOT NULL,
    [AdminUserName] nvarchar(50) NULL,
    [AdminPassword] nvarchar(500) NULL,
    [AdminRole] nvarchar(1) NULL,
    [AdminStatus] bit NOT NULL,
    CONSTRAINT [PK_dbo.Admins] PRIMARY KEY CLUSTERED ([AdminID] ASC)
);
END
GO
SET IDENTITY_INSERT [dbo].[Admins] ON;
INSERT INTO [dbo].[Admins] ([AdminID], [AdminUserName], [AdminPassword], [AdminRole], [AdminStatus]) VALUES
    (1, N'admin@gmail.com', N'10000.yjyBuIcoArX8shtGqA6BGg==.Obgh1YxAWL+kdpm83PBp1yzfEj46Pjct1TitMpws8/w=', N'A', 1),
    (2, N'admin21@gmail.com', N'10000.Nztd3bsRSqNtPEOm/fLkzw==.U1S8NvCxyArcXlDhY+JJKOesq18sVx0hpK0ziYSetzE=', N'C', 1),
    (3, N'admin22@gmail.com', N'10000.jU3UZbe1WWqsaBKdutxm6A==./vuEVuY92M/bf9fB4jJmuDR6isIK3Zta4PJobr65fjs=', N'B', 1),
    (4, N'admin44@gmail.com', N'10000.j3mxeAyEfLRFdcJgouCQzw==.a/w0CxzPt8osxx1Pu+kjVRdnF5vDheffctiB7vMflfk=', N'B', 1),
    (5, N'Admin23@gmail.com', N'10000.h3xyYIHlUIu5EemOFEXbNw==.spol9thbdz/ldAzTgwz+XtaPcYD01lAaMDlBxvxoRSM=', N'A', 1),
    (6, N'Admin7@gmail.com', N'10000./cUAbvZac4y32JWN878Ulg==.3DvANGPWJG2x8hmrDJl0LgMAqTEnqy89LB1pEOWHHtc=', N'B', 1),
    (7, N'adm12@gmail.com', N'10000.6BrzFIM8gP0btVfJcIkjJw==.LDsmTCVnLmpuHPj4t/cHXkqUu6wbh+g15ttEqNj6Mro=', N'B', 1);
SET IDENTITY_INSERT [dbo].[Admins] OFF;
GO

-- --------------------------------------------------------
-- YabancÄ± Anahtarlar (Foreign Keys)
-- --------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_dbo.Headings_dbo.Categories_CategoryID')
BEGIN
    ALTER TABLE [dbo].[Headings] WITH CHECK ADD CONSTRAINT [FK_dbo.Headings_dbo.Categories_CategoryID] FOREIGN KEY([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]) ON DELETE CASCADE;
    ALTER TABLE [dbo].[Headings] CHECK CONSTRAINT [FK_dbo.Headings_dbo.Categories_CategoryID];
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_dbo.Headings_dbo.Writers_WriterID')
BEGIN
    ALTER TABLE [dbo].[Headings] WITH CHECK ADD CONSTRAINT [FK_dbo.Headings_dbo.Writers_WriterID] FOREIGN KEY([WriterID]) REFERENCES [dbo].[Writers] ([WriterID]) ON DELETE CASCADE;
    ALTER TABLE [dbo].[Headings] CHECK CONSTRAINT [FK_dbo.Headings_dbo.Writers_WriterID];
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_dbo.Contents_dbo.Headings_HeadingID')
BEGIN
    ALTER TABLE [dbo].[Contents] WITH CHECK ADD CONSTRAINT [FK_dbo.Contents_dbo.Headings_HeadingID] FOREIGN KEY([HeadingID]) REFERENCES [dbo].[Headings] ([HeadingID]) ON DELETE CASCADE;
    ALTER TABLE [dbo].[Contents] CHECK CONSTRAINT [FK_dbo.Contents_dbo.Headings_HeadingID];
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_dbo.Contents_dbo.Writers_WriterID')
BEGIN
    ALTER TABLE [dbo].[Contents] WITH CHECK ADD CONSTRAINT [FK_dbo.Contents_dbo.Writers_WriterID] FOREIGN KEY([WriterID]) REFERENCES [dbo].[Writers] ([WriterID]);
    ALTER TABLE [dbo].[Contents] CHECK CONSTRAINT [FK_dbo.Contents_dbo.Writers_WriterID];
END
GO
