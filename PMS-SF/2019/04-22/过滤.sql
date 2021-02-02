select ISNULL(MeetingId,'00000000-0000-0000-0000-000000000000') as MeetingId from SF_ZH_WeeklyMeeting

select * from SF_SJ_MeetingSummary  where type = 1 and Id not in(select ISNULL(MeetingId,'00000000-0000-0000-0000-000000000000') as MeetingId from SF_ZH_WeeklyMeeting)


select * from PB_Widget where Id='3fbbbd0b-d420-4de5-b47a-f1ffd016a15c'
--/PowerPlat/FormXml/zh-CN/SF_ZH/SF_ZH_WeeklyMeeting.htm

select * from PB_Widget where Id='bbf4c358-fdb3-4cef-8dc3-93cab40f6e78'
--/PowerPlat/FormXml/zh-CN/SF_CG/SF_CG_Enquiry.htm