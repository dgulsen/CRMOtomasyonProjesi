go
create trigger StokDus
on MusteriSiparisDetay
after insert
as
declare @urunId int
declare @stok int 
select @urunId=UrunID,@stok=Miktar from inserted

update UrunStoklari set Kalan=Kalan-@stok  where UrunID=@urunId
go