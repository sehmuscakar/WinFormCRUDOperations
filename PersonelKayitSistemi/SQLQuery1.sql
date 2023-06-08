insert into personel (PerAd,PerSoyad) values ('Ali','Baran')

truncate table Personel

select count(*) from personel 

select PerMeslek,count(*) from Personel group by PerMeslek-- her meslekte kaç kisi çalýþýyor 
