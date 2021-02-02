create function [dbo].[fn_getformatmoney] (@money numeric(14,2))

returns nvarchar(32) as

begin

    declare @money_num nvarchar(20)    --�洢�����ַ���ʽ

        , @money_chn nvarchar(32)    --�洢�������Ĵ�д��ʽ

        , @n_chn nvarchar(1), @i int    --��ʱ����

 

    select @money_chn=case when @money>=0 then '' else '(��)' end

        , @money=abs(@money)

        , @money_num=stuff(str(@money, 15, 2), 13, 1, '')    --��ǰ�ÿո��뵽λ��ȥ��С���㣩

        , @i=patindex('%[1-9]%', @money_num)    --�ҵ�������λ

 

    while @i>=1 and @i<=14

    begin

        set @n_chn=substring(@money_num, @i, 1)   

        if @n_chn<>'0' or (substring(@money_num,@i+1,1)<>'0' and @i not in(4, 8, 12, 14))    --ת������������Ϊ���Ĵ�д��ʽ   

            set @money_chn=@money_chn+substring('��Ҽ��������½��ƾ�', @n_chn+1, 1)

        if @n_chn<>'0' or @i in(4, 8, 12)    --������ĵ�λ

            set @money_chn=@money_chn+substring('Ǫ��ʰ��Ǫ��ʰ��Ǫ��ʰԲ�Ƿ�',@i,1)     

   

        set @i=@i+1

    end

 

    set @money_chn=replace(@money_chn, '����', '��')    --�����Ϊx������ʱȥ����

    if @money=0 set @money_chn='��Բ��'    --�����Ϊ��ʱ����'��Բ��'

    if @n_chn='0' set @money_chn=@money_chn+'��'    --�����ĩβΪ���ʱ��'��'��β

 

    return @money_chn    --���ش�д���

end

go