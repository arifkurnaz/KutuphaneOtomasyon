-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 30 Mar 2023, 03:11:16
-- Sunucu sürümü: 5.7.39
-- PHP Sürümü: 8.1.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `kutuphanedb`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kitaplar`
--

CREATE TABLE `kitaplar` (
  `kitap_id` int(11) NOT NULL,
  `tur_id` tinyint(4) NOT NULL,
  `kitap_adi` varchar(40) COLLATE utf8_turkish_ci NOT NULL,
  `yazar` varchar(40) COLLATE utf8_turkish_ci NOT NULL,
  `yayinevi` varchar(40) COLLATE utf8_turkish_ci NOT NULL,
  `sayfasayisi` smallint(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kitaplar`
--

INSERT INTO `kitaplar` (`kitap_id`, `tur_id`, `kitap_adi`, `yazar`, `yayinevi`, `sayfasayisi`) VALUES
(1, 1, 'ÇALI KUSU', 'HALIDE EDIP ADIVAR', 'Bilinmiyor', 406),
(2, 1, 'GEN', 'AY', 'Bilinmiyor', 114),
(3, 1, 'YAPRAK D', 'R.NUR', 'Bilinmiyor', 134),
(4, 1, 'YAPRAK DÖKÜMÜ', 'NAMIK KEMAL', 'Bilinmiyor', 176),
(6, 1, 'DON KISOT', 'CERVANTES', 'Bilinmiyor', 320),
(7, 1, 'VADIDEKI ZAMBAK', 'BALZAK', 'Bilinmiyor', 366),
(8, 1, 'SEMERKANT', 'AM', 'Bilinmiyor', 318),
(10, 1, 'KUMARBAZ', 'DOSTOYEVSK', 'Bilinmiyor', 160),
(12, 1, 'ANA', 'GORK', 'Bilinmiyor', 344),
(13, 1, 'SU', 'DOSTOYEVSK', 'Bilinmiyor', 384),
(14, 1, 'NOTRE DAME KAMBURU', 'VICTOR HUGO', 'Bilinmiyor', 408),
(15, 1, 'SEF', 'V', 'Bilinmiyor', 479),
(16, 1, 'SOKRATES\'', 'PLATON', 'Bilinmiyor', 129),
(17, 1, 'BABALAR VE O', 'TURGENYEV', 'Bilinmiyor', 287),
(18, 1, 'C', 'MOL', 'Bilinmiyor', 120),
(19, 1, 'D', 'TOLSTOY', 'Bilinmiyor', 284),
(20, 1, 'SAVA', 'TOLSTOY', 'Bilinmiyor', 768),
(21, 1, 'MOR SALKIMLI EV', 'H.ED', 'Bilinmiyor', 301),
(22, 1, 'KILI', 'H.ED', 'Bilinmiyor', 344),
(23, 1, 'S', 'H.ED', 'Bilinmiyor', 455),
(25, 1, 'ATE', 'H. ED', 'Bilinmiyor', 221),
(26, 1, 'HANDAN', 'H.ED', 'Bilinmiyor', 216),
(27, 1, 'SARI ZEYBEK', 'CAN D', 'Bilinmiyor', 140),
(28, 1, 'YAR', 'CAN D', 'Bilinmiyor', 155),
(29, 1, 'YABAN', 'YAKUP K. KARAOSMANO', 'Bilinmiyor', 214),
(30, 1, 'MURTAZA', 'ORHAN KEMAL', 'Bilinmiyor', 356),
(31, 1, 'CEZM', 'NAMIK KEMAL', 'Bilinmiyor', 368),
(32, 1, 'G', '', 'Bilinmiyor', 159),
(33, 1, 'S', 'REF', 'Bilinmiyor', 206),
(34, 1, 'BABE EV', 'ORHAN KEMAL', 'Bilinmiyor', 103),
(35, 1, 'MELEKLERLE YA', 'BEK', 'Bilinmiyor', 244),
(36, 1, 'K', 'AY', 'Bilinmiyor', 255),
(40, 1, 'G', '', 'Bilinmiyor', 439),
(41, 1, 'B', '', 'Bilinmiyor', 204),
(42, 1, 'EY VATAN', 'OSMAN PAMUKO', 'Bilinmiyor', 158),
(45, 1, 'G', '', 'Bilinmiyor', 181),
(46, 1, 'LANETL', 'GEORGESAND', 'Bilinmiyor', 135),
(47, 1, 'G', '', 'Bilinmiyor', 179),
(48, 1, 'DOKUZUNCU HAR', 'PEYAM', 'Bilinmiyor', 128),
(49, 1, 'SELMA VE G', 'PEYAM', 'Bilinmiyor', 160),
(50, 1, 'HAT', 'HIFZI TOPUZ', 'Bilinmiyor', 246),
(51, 1, 'TAA', '', 'Bilinmiyor', 159),
(52, 1, 'FAT', 'PEYAM', 'Bilinmiyor', 159),
(53, 1, 'HER', 'M', 'Bilinmiyor', 149),
(54, 1, 'KUTADGU B', 'YUSUF HAS HAC', 'Bilinmiyor', 159),
(55, 1, 'MUTLU B', 'MEMDUH ', 'Bilinmiyor', 208),
(56, 1, 'U', 'EM', 'Bilinmiyor', 367),
(57, 1, 'B', 'HANRYBENOZUS', 'Bilinmiyor', 222),
(58, 1, 'CAN BEDEL', 'CLAY BLA', 'Bilinmiyor', 291),
(60, 1, 'T', 'H.ED', 'Bilinmiyor', 333),
(61, 1, 'TOPRAK YE', 'K.HAMSUN', 'Bilinmiyor', 478),
(62, 1, 'BUDALA', 'DOSTOYEVSK', 'Bilinmiyor', 679),
(63, 1, 'EZ', 'DOSTOYEVSK', 'Bilinmiyor', 389),
(65, 1, 'GER', 'MAEVE B', 'Bilinmiyor', 574),
(66, 1, 'YALNIZIZ', 'PEYAM', 'Bilinmiyor', 365),
(67, 1, 'BUZ ', 'ANDREY KURKOV', 'Bilinmiyor', 230),
(68, 1, 'D', 'W', 'Bilinmiyor', 231),
(69, 1, 'G', '', 'Bilinmiyor', 159),
(71, 1, 'R', 'FUZUL', 'Bilinmiyor', 104),
(72, 1, 'TOPRAK ANA', 'CENG', 'Bilinmiyor', 143),
(73, 1, 'SAVA', 'TOLSTOY', 'Bilinmiyor', 352),
(74, 1, 'BABALAR VE O', 'TURGENYEV', 'Bilinmiyor', 221),
(75, 1, 'SOKA', 'AHMET G', 'Bilinmiyor', 350),
(76, 1, 'DO', 'EDWERD O. WILSON', 'Bilinmiyor', 199),
(77, 1, 'MEYHANE', 'EM', 'Bilinmiyor', 304),
(78, 1, 'DEN', 'W.WOOLF', 'Bilinmiyor', 336),
(79, 1, 'AFR', 'JULES VERNE', 'Bilinmiyor', 159),
(80, 1, 'PAR', 'EM', 'Bilinmiyor', 496),
(81, 1, 'YAZGIM ', 'JA', 'Bilinmiyor', 344),
(82, 1, 'B', 'N', 'Bilinmiyor', 320),
(83, 1, 'PAR', 'FERENC MOLNAR', 'Bilinmiyor', 218),
(84, 1, 'HAK', 'M.MALEBRANCHE', 'Bilinmiyor', 364),
(85, 1, 'Y', 'PU', 'Bilinmiyor', 192),
(86, 1, 'BEYZA ZAMBAKLAR ', 'G', 'Bilinmiyor', 133),
(87, 1, 'SINIRSIZ G', 'ANTHON', 'Bilinmiyor', 431),
(88, 1, 'POLYNANA', 'ELENER H. PORTER', 'Bilinmiyor', 159),
(89, 1, 'B', 'MARLO MORGAN', 'Bilinmiyor', 240),
(90, 1, 'YA', 'ERNEST HEM', 'Bilinmiyor', 132),
(91, 1, 'KIRMIZI VE S', 'S', 'Bilinmiyor', 292),
(93, 1, 'KARNAVAL UCUBELER', 'LEMANYE S', 'Bilinmiyor', 256),
(94, 1, 'FARELER VE ', 'JOHANY STE', 'Bilinmiyor', 128),
(95, 1, 'MARTILI KAYA', 'JULES SANDEAU', 'Bilinmiyor', 224),
(96, 1, 'D', 'DAN BROWN', 'Bilinmiyor', 436),
(97, 1, 'GAZHAP ', 'JOHN STA', 'Bilinmiyor', 476),
(98, 1, 'ROMEO VE JULIET', 'W', 'Bilinmiyor', 126),
(99, 1, 'HEIDE', 'JOHAMA SPYRI', 'Bilinmiyor', 162),
(100, 1, 'B', '', 'Bilinmiyor', 293),
(101, 1, 'DON H', '', 'Bilinmiyor', 322),
(102, 1, 'GONA', 'ROBINDRANATH', 'Bilinmiyor', 512),
(103, 1, 'KULUBE', '', 'Bilinmiyor', 176),
(105, 1, 'GEL', 'N', 'Bilinmiyor', 336),
(107, 1, 'G', 'HENRY JAMES', 'Bilinmiyor', 611),
(108, 1, 'GEN', 'HERMANN HESSE', 'Bilinmiyor', 235),
(109, 1, 'SON YAPRAK', 'O.HENRY', 'Bilinmiyor', 192),
(110, 1, 'SEYAHAT TABLOLARI', 'HE', 'Bilinmiyor', 263),
(111, 1, 'BENON', 'K.HAMSUN', 'Bilinmiyor', 271),
(112, 1, 'ARKADA', 'GORK', 'Bilinmiyor', 158),
(113, 1, 'EMKME', 'GORK', 'Bilinmiyor', 271),
(114, 1, 'G', 'K.HOMSUN', 'Bilinmiyor', 448),
(115, 1, 'A', 'K.HOMSUN', 'Bilinmiyor', 192),
(116, 1, 'ZLATANUN G', 'ZLATA F', 'Bilinmiyor', 177),
(118, 1, 'MADAM BAVORY', 'GUSTAVE FULOUBER', 'Bilinmiyor', 380),
(119, 1, 'BU B', 'REF', 'Bilinmiyor', 232),
(120, 1, 'TURFANDAMI YOKSA TURFAMI', 'MEHMET MURAT', 'Bilinmiyor', 312),
(121, 1, 'K', 'AY', 'Bilinmiyor', 255),
(122, 1, 'AKI', 'PINAR K', 'Bilinmiyor', 171),
(123, 1, 'MELEKLERLE YA', 'BEK', 'Bilinmiyor', 144),
(124, 1, 'AYLAK K', 'SADIK H', 'Bilinmiyor', 84),
(125, 1, 'SANCAKLAR DALGANANINCA', '', 'Bilinmiyor', 144),
(126, 1, 'DENEMELER', 'MANTA', 'Bilinmiyor', 326),
(127, 1, 'ZEHRA', 'NABIZADE NAZIM', 'Bilinmiyor', 160),
(129, 1, 'K', 'YAKUP KADR', 'Bilinmiyor', 232),
(130, 1, 'BU ', 'TUNA K', 'Bilinmiyor', 197),
(132, 1, 'SEL', 'YAVUZ BAHADIRO', 'Bilinmiyor', 201),
(134, 1, 'A', 'K', 'Bilinmiyor', 340),
(135, 1, 'MAFYA DOSYASI', 'PETER MOOS', 'Bilinmiyor', 318),
(136, 1, 'GAR', 'OKTAY AKBAL', 'Bilinmiyor', 142),
(138, 1, 'S', 'ALEXSANDR DUMAS', 'Bilinmiyor', 224),
(139, 1, 'FAUST', 'GOETHE', 'Bilinmiyor', 176),
(140, 1, 'NORTH AND SOUTH', 'EL', 'Bilinmiyor', 403),
(141, 1, 'KAMELYALI KADIN', 'ALEXANDRE DUMAS', 'Bilinmiyor', 231),
(142, 1, 'DE', 'RE', 'Bilinmiyor', 144),
(143, 1, 'TATARCIK', 'HAL', 'Bilinmiyor', 191),
(144, 1, 'BEKLENMEYEN M', 'AGOTHA CHR', 'Bilinmiyor', 170),
(145, 1, 'SOF', 'JOSTE', 'Bilinmiyor', 592),
(146, 1, 'SIR', 'SABAHATT', 'Bilinmiyor', 141),
(148, 1, 'SERG', 'SAM', 'Bilinmiyor', 126);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kitap_turleri`
--

CREATE TABLE `kitap_turleri` (
  `tur_id` int(11) NOT NULL,
  `tur_adi` varchar(50) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kitap_turleri`
--

INSERT INTO `kitap_turleri` (`tur_id`, `tur_adi`) VALUES
(1, 'Roman'),
(2, 'Hikaye'),
(3, 'Şiir'),
(4, 'Gezi'),
(5, 'Çocuk'),
(6, 'Kişisel Gelişim'),
(7, 'Saglik');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `odunc_kitaplar`
--

CREATE TABLE `odunc_kitaplar` (
  `id` int(11) NOT NULL,
  `ogr_no` int(11) NOT NULL,
  `kitap_id` int(11) NOT NULL,
  `verilis_tarihi` date DEFAULT NULL,
  `teslim_tarihi` date DEFAULT NULL,
  `aciklama` varchar(200) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ogrenciler`
--

CREATE TABLE `ogrenciler` (
  `ogrenci_no` int(11) NOT NULL,
  `ad` varchar(25) COLLATE utf8_turkish_ci NOT NULL,
  `soyad` varchar(25) COLLATE utf8_turkish_ci NOT NULL,
  `sinif` tinyint(4) NOT NULL,
  `cinsiyet` varchar(7) COLLATE utf8_turkish_ci NOT NULL,
  `telefon` varchar(12) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `kitaplar`
--
ALTER TABLE `kitaplar`
  ADD PRIMARY KEY (`kitap_id`),
  ADD KEY `tur_id` (`tur_id`);

--
-- Tablo için indeksler `kitap_turleri`
--
ALTER TABLE `kitap_turleri`
  ADD PRIMARY KEY (`tur_id`);

--
-- Tablo için indeksler `odunc_kitaplar`
--
ALTER TABLE `odunc_kitaplar`
  ADD PRIMARY KEY (`id`),
  ADD KEY `oduncSilme` (`kitap_id`),
  ADD KEY `ogrenci` (`ogr_no`);

--
-- Tablo için indeksler `ogrenciler`
--
ALTER TABLE `ogrenciler`
  ADD PRIMARY KEY (`ogrenci_no`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `kitaplar`
--
ALTER TABLE `kitaplar`
  MODIFY `kitap_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=149;

--
-- Tablo için AUTO_INCREMENT değeri `kitap_turleri`
--
ALTER TABLE `kitap_turleri`
  MODIFY `tur_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `odunc_kitaplar`
--
ALTER TABLE `odunc_kitaplar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `ogrenciler`
--
ALTER TABLE `ogrenciler`
  MODIFY `ogrenci_no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=113;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `odunc_kitaplar`
--
ALTER TABLE `odunc_kitaplar`
  ADD CONSTRAINT `oduncSilme` FOREIGN KEY (`kitap_id`) REFERENCES `kitaplar` (`kitap_id`),
  ADD CONSTRAINT `ogrenci` FOREIGN KEY (`ogr_no`) REFERENCES `ogrenciler` (`ogrenci_no`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
