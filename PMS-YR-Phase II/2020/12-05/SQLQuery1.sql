select * from XLX_PS_BID_Inquiry
where
Id in
     ( 
		select masterid from  XLX_PS_BID_Inquiry_MatList  B where B.xlx_request_list_id in 
			(
				select InquirymatList_Id from XLX_PUR_Order_List  where FK='03d9351f-a5b7-40cd-8200-bd2ba64cb67e'
			)
	)