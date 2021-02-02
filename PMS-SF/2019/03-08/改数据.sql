 select * from PS_PUR_MatRequisitions where code ='LLD-190307-016'

 select * from PS_PUR_MatRequisitions_Dtl where MasterId='6EF81B04-D0E0-4057-BD18-6A8A4A122677'
 --delete from PS_PUR_MatRequisitions_Dtl where Id='2B02400C-DC40-7AA8-8021-BAF7D2A1C130'
 --mat_guid 
 --6F971B7F-2AA6-4378-8E05-289FE299A1A3

 select * from PS_PUR_MatOutStore where Requisition_Guid='6EF81B04-D0E0-4057-BD18-6A8A4A122677'

 select * from PS_PUR_MatOutStore_Dtl where MasterId='E40756FD-3C07-44DD-B5EB-936EAD4B399D'
 --delete from PS_PUR_MatOutStore_Dtl where Id='C5FC1755-C233-4FEC-A0A2-D6B70C82B3AE'

 select * from PS_PUR_MatStoreBalance where Mat_Guid='6F971B7F-2AA6-4378-8E05-289FE299A1A3'
--update PS_PUR_MatStoreBalance set ValidNum=10 where Mat_Guid='6F971B7F-2AA6-4378-8E05-289FE299A1A3'


select * from PB_User where Name='ึÜะหฮภ'