--����
select * from View_SF_ZHLeave
--sp_helptext View_SF_ZHLeave
--alter view View_SF_ZHLeave
--as
--select * from SF_ZH_Leave where LeaveStatus = '0' and status=50

select DaptId,Department,* from SF_ZH_Leave 


select * from PB_Widget where id='1f13be96-6001-4c3e-83f5-7dcdf954023f'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_Leave.htm

select * from PB_Department where Name='���в�'
select * from PB_Department where Id='D045F0D9-C9F2-4DC8-B5AB-15EEE958A186' or ParentId='D045F0D9-C9F2-4DC8-B5AB-15EEE958A186'


select * from PB_Widget where id='B3C45A27-5685-4B1A-B31E-3E05439C5430'
--/PowerPlat/FormXml/zh-CN/StdSystem/UserPage.htm
select * from PB_Human
select * from PB_User

 CREATE PROCEDURE UpdateHumanCode
 (
    @humCode nvarchar(50),
    @new_humCode nvarchar(50)  
  )
  AS
  begin
    update SF_ZH_Leave set HumCode = @new_humCode where HumCode = @humCode   --HumCode �������
    update SF_ZH_OverTime set HumCode = @new_humCode where HumCode = @humCode --HumCode�Ӱ�����
    update SF_ZH_OverTimeBatch_list set HumCode = @new_humCode where HumCode = @humCode --HumCode�����Ӱ�������ϸ
    update SF_ZH_MonthOverTime_list set HumCode = @new_humCode where HumCode = @humCode --HumCode�Ӱ���ͳ��
    update SF_Hires set HumanCode = @new_humCode where HumanCode = @humCode --HumCodeԱ����ְ��
    update SF_ZH_PassengerList set HumCode = @new_humCode where HumCode = @humCode --HumCode�ó�������ϸ���г���¼��ϸ
    update SF_ZH_Allocation_list set HumCode = @new_humCode where HumCode = @humCode --HumCode��Ա������ϸ
    update SF_ZH_BusinessTravel_list set HumCode = @new_humCode where HumCode = @humCode --HumCode����������ϸ
    update SF_ZH_TrainPlan_list set HumCode = @new_humCode where HumCode = @humCode --HumCode��ѵ�ƻ����������ϸ
    update SF_ZH_TrainRecord_list set HumCode = @new_humCode where HumCode = @humCode --HumCode��ѵ��¼��ϸ
    update SF_SJ_MeetingSummary_Par set JobNumber = @new_humCode where JobNumber = @humCode --JobNumber�����Ҫ��ϸ
    update SF_HSE_InspectionNotice_dtl set HuamnCode = @new_humCode where HuamnCode = @humCode --HumanCode���ͨ����ϸ
    update SF_HSE_SecurityMeeting_dtl set HumanCode = @new_humCode where HumanCode = @humCode --HumanCode��ȫ������ϸ
    update SF_HSE_CareerCheck_dtl set HumanCode = @new_humCode where HumanCode = @humCode --HumanCodeְҵ��Σ�����ض��ڼ����ϸ
    update SF_HSE_UnNature_dtl set HumanCode = @new_humCode where HumanCode = @humCode --HumanCodeְҵ��Σ�����ض��ڼ����ϸ
    update SF_HumanCheckOnWork set HumanCode = @new_humCode where HumanCode = @humCode --HumanCode ���ſ���
    UPDATE SF_ZH_CheckWork_All SET HumanCode = @new_humCode where HumanCode = @humCode --HumanCode ���ſ�����ͳ��
    UPDATE pb_Human SET code = @new_humCode where code = @humCode --HumanCode ��Ա
 end