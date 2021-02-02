--规格型号，制造标准，材质，型式
--物资编码库，/PowerPlat/FormXml/zh-CN/StdMasterData/Win_PS_MDM_MatBS_m.htm
select * from pb_widget where id='554dafc2-7209-4a79-bf8e-b72470831f54'
--新增物资申请，/PowerPlat/FormXml/zh-CN/StdMasterData/PS_MDM_Mat.htm
select * from pb_widget where id='6c7c4f7f-4002-4e41-8864-0b0712ae9c0d'
--新增物资申请，/PowerPlat/FormXml/zh-CN/StdMasterData/PS_MDM_Mats.htm
select * from pb_widget where id='4bc429a6-ef0b-48b4-bdab-716ef89c44f8'
--中间库，/PowerPlat/FormXml/zh-CN/StdMasterData/Win_PS_MDM_MatBS_m.htm。。。/PowerPlat/FormXml/zh-CN/XLX_CM/Win_CPL_MiddleMat.htm
select * from pb_widget where id='20f3a543-9117-4a35-8a21-2d5452a81bf2'
--到货检查，/PowerPlat/FormXml/zh-CN/StdPurchase/PS_ArrivalCheck.htm
select * from PB_Widget where id='273dea71-73a1-4e45-89d9-e35ff8fc6105'
--到货检查-按合同到货，/PowerPlat/FormXml/zh-CN/StdPurchase/Wizard_PurchaseContractMaterial.htm
select * from PB_Wizard where id='8106c2c7-bd3c-40e4-83c5-691cbf704e42'
--到货检查-从物资库选择，/PowerPlat/FormXml/zh-CN/StdMasterData/WizardMDM_Material.htm
select * from PB_Wizard where id='6db50dc9-daaa-4093-8e68-de5f65ab69c1'
--不合格项，/PowerPlat/FormXml/zh-CN/StdPurchase/PS_NonConformProduct_A.htm
select * from pb_widget where id='3b253222-abc6-4c09-be0d-bbead38c523f'
--不合格项 新增，/PowerPlat/FormXml/zh-CN/StdPurchase/Wizard_PS_ArrivalCheck_Dtl.htm
select * from PB_Wizard where id='3eec75d3-0d45-49cd-8903-1b5e2713c314'
--物资入库,/PowerPlat/FormXml/zh-CN/StdPurchase/PS_MatInStore.htm
select * from pb_widget where id='7fb0df68-6adc-4b77-b8f9-3977f3291170'
--物资入库，新增，/PowerPlat/FormXML/zh-CN/XLX_PUR/Wizard_PurchaseContractMaterial.htm
--视图-View_ArrivalCheck_SubContract
select * from PB_Wizard where id='4541cbfd-df71-466c-9b19-e1983bc4027e'
--领料申请，/PowerPlat/FormXml/zh-CN/StdPurchase/PS_MatRequisitions.htm
select * from PB_Widget where id='7dacb7ef-7156-452b-b1ac-0182a4ab14a7'
--领料申请，新增，/PowerPlat/FormXML/zh-CN/XLX_PUR/Wizard_XLX_BOM_MatRequisitions.html
--视图-View_XLX_PS_BOM
select * from PB_Wizard where id='57165e49-4c65-4496-a3ce-1f41c6120691'
--出库，/PowerPlat/FormXml/zh-CN/StdPurchase/PS_MatOutStore.htm
select * from PB_Widget where id='943e1066-f8d0-4227-b2e1-55329b237ef2'
--出库，新增，/PowerPlat/FormXml/zh-CN/StdPurchase/Wizard_PurcahseMatReqStoreBalance.htm
--视图—View_PS_ReqMatStoreBalance。
select * from PB_Wizard where id='fd481d58-41a0-411f-9f23-4b3ea892572f'
--物资调拨，/PowerPlat/FormXml/zh-CN/StdPurchase/PS_MatTransfer.htm
select * from pb_widget where id='121e948f-7059-42a8-93bf-6b447b226c1a'
select * from PB_Widget where id='763586e8-3d16-426b-bbe9-d7f033a27a82'
--物资调拨，新增，/PowerPlat/FormXml/zh-CN/XLX_PUR/Wizard_PS_PUR_MatStoreBalance.htm
--视图-View_PS_PUR_MatStoreBalance
select * from PB_Wizard where id='7f541e5c-f81a-493d-b775-f50b99f94f5a'
--退库申请，/PowerPlat/FormXml/zh-CN/StdPurchase/PS_MatReturn.htm
select * from PB_Widget where id='7dd65822-3dbb-4715-9c48-f129905db743'
--退库申请，新增，/PowerPlat/FormXml/zh-CN/StdPurchase/Wizard_ReturnMatRequisitions.htm
select * from PB_Wizard where id='dbe72aca-1e3a-4c26-99c4-596155d04fe4'
--材料入库统计，/PowerPlat/FormXml/zh-CN/StdPurchase/Win_V_PS_MatInStoreDtl.htm
--视图-V_PS_MatInStoreDtl
select * from pb_widget where id='6860ba46-5422-4dd4-8c2c-613b1f4de557'
--库存查询，/PowerPlat/FormXml/zh-CN/StdPurchase/Win_V_PS_PUR_MatStoreBalance.htm
--视图-V_PS_PUR_MatStoreBalance_StorageName-Export-- Specifi,Standard,Texture,Pattern,
select * from pb_widget where id='15a15ca6-4a2e-4066-af9f-687f57f6a3fe'
--物资盘点，/PowerPlat/FormXml/zh-CN/StdPurchase/Wizard_V_PurcahseMatReqStoreBalance.htm
select * from PB_Wizard where id='378120d6-e5ee-408d-ba61-1fbab2c51226'
--物资处置,/PowerPlat/FormXml/zh-CN/StdPurchase/Wizard_V_PS_PUR_MatStoreBalance_PS_MDM_Mat.htm
select * from pb_widget where id='a4d6c534-3f27-4cce-923c-79df35ac5d79'
--/PowerPlat/FormXml/zh-CN/StdPurchase/PS_MatDisposal.htm
select * from pb_widget where id='6c507816-c02b-44b4-b64b-854c871e17c4'
select * from pb_widget where id='bbf1b8b4-c8e0-4b5a-adbd-404450112556'
select * from PB_Wizard where id='9eb3644d-f181-4e50-8c0b-8b058f193e50'

