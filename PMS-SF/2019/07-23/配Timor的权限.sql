--�ۺϸ�λ
--�������
select * from PB_Widget where Id='1f13be96-6001-4c3e-83f5-7dcdf954023f'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_Leave.htm
--�Ӱ�����
select * from pb_widget where id='c867323c-f068-4956-a496-4f2527cdaf38'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_OverTime.htm
--�Ӱ���ͳ��
select * from PB_Widget where Id='03e7a009-ccbb-4912-a823-a34f83095a12'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_MonthOvertime.htm
--����
select * from PB_Widget where Id='b0699e4d-6445-48a9-8658-b74a0db5623a'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_BusinessTravel.htm
--�����Ҫ
select * from PB_Widget where Id='3b78586f-6aca-4c96-a963-3d8f458815e2'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_MeetingSummary.htm
--�����ᶽ��
select * from PB_Widget where Id='3a836371-4b16-4521-b6d4-2aaf1d43aeeb'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_WeeklyMeeting.htm

select * from PLN_project where project_name='���첿��Ŀ'
select * from dbo.returnEPSChildrenTreeIds('4314f031-f5c9-46c8-aa77-0ab039e62028')

select * from SF_ZH_Leave
select * from SF_ZH_OverTime
select * from SF_ZH_MonthOvertime
select * from SF_ZH_BusinessTravel
select * from SF_SJ_MeetingSummary where Type=1

select * from PB_Department where Name='���ж���'
select * from PB_Human
select * from PB_User where Name='������'