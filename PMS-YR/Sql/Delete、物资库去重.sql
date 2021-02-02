--select matcode from XLX_MDM_MAT_Middle group by matcode having count(matcode)>1

--select * from XLX_MDM_MAT_Middle where matcode='1388101530004' 

--select * from ps_pur_bom where matcode='1388101530004'

--select * from PS_MDM_Mat where matlongname is null



--select * from PS_MDM_Mat where matcode='1060907010001'

--select stuff(matcode,1,9,'') from PS_MDM_Mat
--select matcode from PS_MDM_Mat

--select * from ps_pur_bom where matcode ='1388101530004'





--select matcode from PS_MDM_Mat group by matcode having count(matcode)>1
--select * from PS_MDM_Mat where MatBS_Guid is null

select * from PS_pur_BOM where matcode='1601103010005'
select matcode from PS_MDM_Mat group by matcode having count(matcode)>1

select * from PS_MDM_Mat where matcode='1381081030003'

--delete from PS_MDM_Mat where id='EFBC10EA-04D7-4DDE-A172-DF9922FDA755'

--描述不一样的
select * from PS_MDM_Mat where matcode like '138180104%'

--update PS_MDM_Mat set matcode='1381801040004' where id='7F0EA10F-FE2C-44D7-A8D5-E256E7E9D403'

