Insert Into PS_SubContract_Order(Id, MasterId, OrderKeyWord, OrderId, OrderCode, OrderTitle, UpdDate, CompanyId, Company) 
Values('dc37cfe0-2355-92c0-6324-fb62f439c37d', N'a1ff657a-2fed-4427-a49a-d785a77ad801', N'SF_CG_Enquiry', N'71d02491-b800-445b-be26-6bdcc3c83eeb', N'XBJ-181213-009', N'丰盛、江津、长丰运行站备件采购', {ts'2018-12-28 15:46:52'}, N'6e6726da-5702-4987-93e3-6d80e3c0c2ca', N'重庆培茂物资有限公司')

select * from PS_SubContract_Order where id='dc37cfe0-2355-92c0-6324-fb62f439c37d'



Insert Into PS_SubContract_Order(Id, MasterId, OrderKeyWord, OrderId, OrderCode, OrderTitle, UpdDate, CompanyId, Company) Values('10c6d5fa-6921-b98f-284a-87e409b1990d', N'a1ff657a-2fed-4427-a49a-d785a77ad801', N'SF_CG_Enquiry', N'71d02491-b800-445b-be26-6bdcc3c83eeb', N'XBJ-181213-009', N'丰盛、江津、长丰运行站备件采购', {ts'2018-12-28 15:49:55'}, N'6e6726da-5702-4987-93e3-6d80e3c0c2ca', N'重庆培茂物资有限公司')



--LoadMat(string OrderKeyWord, string OrderId, string CompanyId)
--LoadMat(SF_CG_Enquiry, 71d02491-b800-445b-be26-6bdcc3c83eeb, 6e6726da-5702-4987-93e3-6d80e3c0c2ca)
--1找不到
select * from SF_CG_EnquiryCompany where id='71d02491-b800-445b-be26-6bdcc3c83eeb'
--2有35条明细
select * from SF_CG_EnquiryList where MasterId='71d02491-b800-445b-be26-6bdcc3c83eeb'
select * from SF_CG_Enquiry where id='71D02491-B800-445B-BE26-6BDCC3C83EEB'
select * from SF_CG_EnquiryCompany where MasterId='' and CompanyId=''










select * from PS_CM_SubContract where id='a1ff657a-2fed-4427-a49a-d785a77ad801'
select * from PS_SubContract_Order where OrderCode='XBJ-181213-009'


select * from PS_SubContract_Order where MasterId='a1ff657a-2fed-4427-a49a-d785a77ad801'
--LoadMat(string OrderKeyWord, string OrderId, string CompanyId)
--LoadMat(SF_CG_Enquiry, 71d02491-b800-445b-be26-6bdcc3c83eeb, 6e6726da-5702-4987-93e3-6d80e3c0c2ca)

select IsChosen,* from SF_CG_Enquiry where id='71d02491-b800-445b-be26-6bdcc3c83eeb'
update SF_CG_Enquiry set IsChosen = 0 where id='71d02491-b800-445b-be26-6bdcc3c83eeb'

--报错
Insert Into PS_SubContract_Order(Id, MasterId, OrderKeyWord, OrderId, OrderCode, OrderTitle, UpdDate, CompanyId, Company) 
Values('2c350849-21d1-5eb2-3214-1a957a1df2b6', N'a1ff657a-2fed-4427-a49a-d785a77ad801', N'SF_CG_Enquiry', N'71d02491-b800-445b-be26-6bdcc3c83eeb', N'XBJ-181213-009', N'丰盛、江津、长丰运行站备件采购', {ts'2018-12-28 16:21:53'}, N'6e6726da-5702-4987-93e3-6d80e3c0c2ca', N'重庆培茂物资有限公司')

--SK2018（备）-177

select * from SF_CG_EnquiryCompany where MasterId='71d02491-b800-445b-be26-6bdcc3c83eeb' and CompanyId ='6e6726da-5702-4987-93e3-6d80e3c0c2ca'
select * from SF_CG_EnquiryCompany where MasterId='71d02491-b800-445b-be26-6bdcc3c83eeb' and Company='重庆瑞海电子科技有限公司'

select * from SF_CG_EnquiryCompanyChlid where MasterId='1cc821fd-75f3-8e46-fd38-a2b7390d291e'
and PlanCode='JS2218008-16' and IsSelected=1

select * from PB_Organize where Name like '%瑞海%'--6D1FA593-A4DA-4B10-A082-E48338FC9B8B
update SF_CG_EnquiryCompany set CompanyId='6D1FA593-A4DA-4B10-A082-E48338FC9B8B' where MasterId='71d02491-b800-445b-be26-6bdcc3c83eeb' and Company='重庆瑞海电子科技有限公司'
select * from PB_Organize where Name like '%茂%'--6E6726DA-5702-4987-93E3-6D80E3C0C2CA


select * from PS_CM_SubContract where id='a1ff657a-2fed-4427-a49a-d785a77ad801'

select * from PS_SubContract_Order where MasterId='a1ff657a-2fed-4427-a49a-d785a77ad801'



--报错
Insert Into PS_SubContract_Order(Id, MasterId, OrderKeyWord, OrderId, OrderCode, OrderTitle, UpdDate, CompanyId, Company) Values('1a252e40-1f6a-f5a6-3c39-9628879bac20', N'a1ff657a-2fed-4427-a49a-d785a77ad801', N'SF_CG_Enquiry', N'71d02491-b800-445b-be26-6bdcc3c83eeb', N'XBJ-181213-009', N'丰盛、江津、长丰运行站备件采购', {ts'2018-12-28 20:08:21'}, N'6e6726da-5702-4987-93e3-6d80e3c0c2ca', N'重庆培茂物资有限公司')