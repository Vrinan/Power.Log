select * from PB_User where Code='0162'


select * from PB_Messages where ToHumanName='¬Ө' and IsPowerMessage=0

Select * From  PB_Messages A 
Where  A.ToHumanId='878eba8f-cce7-4472-a9b6-98312103f782' 
and (A.MessageType='notifymanual' or A.MessageType='notify' or A.MessageType='subworkflow') 
--and (A.IsPowerMessage=1 or A.IsPowerMessage=2)
--����ʾ��
--and (A.IsPowerMessage=3)
--��ʾ��
and (A.IsPowerMessage=2)

--IsPowerMessage=3 
--IsPowerMessage=2

Select count(*) as RecordCount From  PB_Messages A Where   (0=0)  and  (0=0)  and A.ToHumanId='878eba8f-cce7-4472-a9b6-98312103f782' and (A.MessageType='notifymanual' or A.MessageType='notify' or A.MessageType='subworkflow') and (A.IsPowerMessage=1 or A.IsPowerMessage=2) and 1=1