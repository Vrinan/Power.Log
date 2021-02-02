--select * from View_SF_YX_EquWaterTesting where date !='2018-09-22'

--sp_helptext View_SF_YX_EquWaterTesting 


select 
Convert(varchar(100),a.Date,23) as Date,a.Department,a.Id,a.MasterId,a.ProjName,a.PH,a.Wd,a.DDL,a.COD,a.BOD,a.NAN,a.TN,a.NOOO,a.NOO,a.SV,a.SS,a.MLSS,a.KRQT_ND,a.KRQT_LL,a.DO,
b.PH as PH1,b.Wd as Wd1,b.DDL as DDL1,b.COD as COD1,b.BOD as BOD1,b.NAN as NAN1,b.TN as TN1,b.NOOO as NOOO1,b.NOO as NOO1,b.SV as SV1,b.SS as SS1,b.MLSS as MLSS1,
b.KRQT_ND as KRQT_ND1,b.KRQT_LL as KRQT_LL1,b.DO as DO1,
c.PH as PH2,c.Wd as Wd2,c.DDL as DDL2,c.COD as COD2,c.BOD as BOD2,c.NAN as NAN2,c.TN as TN2,c.NOOO as NOOO2,c.NOO as NOO2,c.SV as SV2,c.SS as SS2,c.MLSS as MLSS2,
c.KRQT_ND as KRQT_ND2,c.KRQT_LL as KRQT_LL2,c.DO as DO2,
d.PH as PH3,d.Wd as Wd3,d.DDL as DDL3,d.COD as COD3,d.BOD as BOD3,d.NAN as NAN3,d.TN as TN3,d.NOOO as NOOO3,d.NOO as NOO3,d.SV as SV3,d.SS as SS3,d.MLSS as MLSS3,
d.KRQT_ND as KRQT_ND3,d.KRQT_LL as KRQT_LL3,d.DO as DO3,
e.PH as PH4,e.Wd as Wd4,e.DDL as DDL4,e.COD as COD4,e.BOD as BOD4,e.NAN as NAN4,e.TN as TN4,e.NOOO as NOOO4,e.NOO as NOO4,e.SV as SV4,e.SS as SS4,e.MLSS as MLSS4,
e.KRQT_ND as KRQT_ND4,e.KRQT_LL as KRQT_LL4,e.DO as DO4,
f.PH as PH5,f.Wd as Wd5,f.DDL as DDL5,f.COD as COD5,f.BOD as BOD5,f.NAN as NAN5,f.TN as TN5,f.NOOO as NOOO5,f.NOO as NOO5,f.SV as SV5,f.SS as SS5,f.MLSS as MLSS5,
f.KRQT_ND as KRQT_ND5,f.KRQT_LL as KRQT_LL5,f.DO as DO5,
g.PH as PH6,g.Wd as Wd6,g.DDL as DDL6,g.COD as COD6,g.BOD as BOD6,g.NAN as NAN6,g.TN as TN6,g.NOOO as NOOO6,g.NOO as NOO6,g.SV as SV6,g.SS as SS6,g.MLSS as MLSS6,
g.KRQT_ND as KRQT_ND6,g.KRQT_LL as KRQT_LL6,g.DO as DO6,
h.PH as PH7,h.Wd as Wd7,h.DDL as DDL7,h.COD as COD7,h.BOD as BOD7,h.NAN as NAN7,h.TN as TN7,h.NOOO as NOOO7,h.NOO as NOO7,h.SV as SV7,h.SS as SS7,h.MLSS as MLSS7,
h.KRQT_ND as KRQT_ND7,h.KRQT_LL as KRQT_LL7,h.DO as DO7,
i.PH as PH8,i.Wd as Wd8,i.DDL as DDL8,i.COD as COD8,i.BOD as BOD8,i.NAN as NAN8,i.TN as TN8,i.NOOO as NOOO8,i.NOO as NOO8,i.SV as SV8,i.SS as SS8,i.MLSS as MLSS8,
i.KRQT_ND as KRQT_ND8,i.KRQT_LL as KRQT_LL8,i.DO as DO8,
j.PH as PH9,j.Wd as Wd9,j.DDL as DDL9,j.COD as COD9,j.BOD as BOD9,j.NAN as NAN9,j.TN as TN9,j.NOOO as NOOO9,j.NOO as NOO9,j.SV as SV9,j.SS as SS9,j.MLSS as MLSS9,
j.KRQT_ND as KRQT_ND9,j.KRQT_LL as KRQT_LL9,j.DO as DO9,
k.PH as PH10,k.Wd as Wd10,k.DDL as DDL10,k.COD as COD10,k.BOD as BOD10,k.NAN as NAN10,k.TN as TN10,k.NOOO as NOOO10,k.NOO as NOO10,k.SV as SV10,k.SS as SS10,k.MLSS as MLSS10,
k.KRQT_ND as KRQT_ND10,k.KRQT_LL as KRQT_LL10,k.DO as DO10,
l.PH as PH11,l.Wd as Wd11,l.DDL as DDL11,l.COD as COD11,l.BOD as BOD11,l.NAN as NAN11,l.TN as TN11,l.NOOO as NOOO11,l.NOO as NOO11,l.SV as SV11,l.SS as SS11,l.MLSS as MLSS11,
l.KRQT_ND as KRQT_ND11,l.KRQT_LL as KRQT_LL11,l.DO as DO11,
m.PH as PH12,m.Wd as Wd12,m.DDL as DDL12,m.COD as COD12,m.BOD as BOD12,m.NAN as NAN12,m.TN as TN12,m.NOOO as NOOO12,m.NOO as NOO12,m.SV as SV12,m.SS as SS12,m.MLSS as MLSS12,
m.KRQT_ND as KRQT_ND12,m.KRQT_LL as KRQT_LL12,m.DO as DO12,
n.PH as PH13,n.Wd as Wd13,n.DDL as DDL13,n.COD as COD13,n.BOD as BOD13,n.NAN as NAN13,n.TN as TN13,n.NOOO as NOOO13,n.NOO as NOO13,n.SV as SV13,n.SS as SS13,n.MLSS as MLSS13,
n.KRQT_ND as KRQT_ND13,n.KRQT_LL as KRQT_LL13,n.DO as DO13
 from 
(select a.Id as OrderId,a.Date,a.Department,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='调节池') a
left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='调节池出水') b on a.MasterId=b.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='中间池' and b.ProjName='1#') c on a.MasterId=c.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='中间池' and b.ProjName='2#') d on a.MasterId=d.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='UASB池' and b.ProjName='1#') e on a.MasterId=e.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='UASB池' and b.ProjName='2#') f on a.MasterId=f.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='反硝化池' and b.ProjName='1#') g on a.MasterId=g.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='反硝化池' and b.ProjName='2#') h on a.MasterId=h.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='硝化池' and b.ProjName='1#') i on a.MasterId=i.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='硝化池' and b.ProjName='2#') j on a.MasterId=j.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='UF' and b.ProjName='1#') k on a.MasterId=k.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='UF' and b.ProjName='2#') l on a.MasterId=l.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='STRO') m on a.MasterId=m.MasterId
 left join 
(select a.Id as OrderId,a.Date,b.Id,MasterId,ProjName,PH,Wd,DDL,COD,BOD,NAN,TN,NOOO,NOO,SV,SS,MLSS,KRQT_ND,KRQT_LL,DO,QYDate,FXDate
 from SF_YX_EquWaterTesting a left join SF_YX_EquWaterTesting_list b on a.id=b.MasterId where b.Name='排口') n on a.MasterId=n.MasterId
