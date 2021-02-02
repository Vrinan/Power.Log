create function [dbo].[fn_getformatmoney] (@money numeric(14,2))

returns nvarchar(32) as

begin

    declare @money_num nvarchar(20)    --存储金额的字符形式

        , @money_chn nvarchar(32)    --存储金额的中文大写形式

        , @n_chn nvarchar(1), @i int    --临时变量

 

    select @money_chn=case when @money>=0 then '' else '(负)' end

        , @money=abs(@money)

        , @money_num=stuff(str(@money, 15, 2), 13, 1, '')    --加前置空格补齐到位（去掉小数点）

        , @i=patindex('%[1-9]%', @money_num)    --找到金额最高位

 

    while @i>=1 and @i<=14

    begin

        set @n_chn=substring(@money_num, @i, 1)   

        if @n_chn<>'0' or (substring(@money_num,@i+1,1)<>'0' and @i not in(4, 8, 12, 14))    --转换阿拉伯数字为中文大写形式   

            set @money_chn=@money_chn+substring('零壹贰叁肆伍陆柒捌玖', @n_chn+1, 1)

        if @n_chn<>'0' or @i in(4, 8, 12)    --添加中文单位

            set @money_chn=@money_chn+substring('仟佰拾亿仟佰拾万仟佰拾圆角分',@i,1)     

   

        set @i=@i+1

    end

 

    set @money_chn=replace(@money_chn, '亿万', '亿')    --当金额为x亿零万时去掉万

    if @money=0 set @money_chn='零圆整'    --当金额为零时返回'零圆整'

    if @n_chn='0' set @money_chn=@money_chn+'整'    --当金额末尾为零分时以'整'结尾

 

    return @money_chn    --返回大写金额

end

go