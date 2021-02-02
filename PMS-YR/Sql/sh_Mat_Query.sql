--1
update pb_widget set Name='物资编码申请',WidgetType=6,KeyWord='PS_MDM_Mat',
HtmlPath='/PowerPlat/FormXml/zh-CN/StdMasterData/PS_MDM_Mat.htm',ExtJson='{
    "config": {
        "joindata": {
            "KeyWord": "PS_MDM_Mat",
            "children": [
                {
                    "KeyWord": "PS_MDM_Mat_Property",
                    "fields": {
                        "MasterId": "Id"
                    },
                    "sort": "Sequ"
                }
            ]
        }
    },
    "PS_MDM_Mat.MatBS_Code": {
        "ComponentID": "e1e7e5f1-b8ab-4741-8a59-bc221512e7f4",
        "ComponentType": "wizard",
        "title": "选择材料分类",
        "multi": "0",
        "isleaf": "1",
        "fields": {
            "MatBS_Guid": "Id",
            "MatBS_Code": "MatBSCode",
            "MatBS_Name": "MatBSName"
        },
        "select": "",
        "distinct": []
    }
}',bWebForm=1,MobileExtJson='' where Id = '17ae2e89-7efc-42c1-89f6-6d6338c6f007';

--2
insert into pb_widget(Id,Name,bPublish,bSysDefault,WidgetType,
        KeyWord,HtmlPath,ExtJson,bWebForm,MobileExtJson) 
		select '17ae2e89-7efc-42c1-89f6-6d6338c6f007','物资编码申请',1,1,6,'PS_MDM_Mat','/PowerPlat/FormXml/zh-CN/StdMasterData/PS_MDM_Mat.htm','{
    "config": {
        "joindata": {
            "KeyWord": "PS_MDM_Mat",
            "children": [
                {
                    "KeyWord": "PS_MDM_Mat_Property",
                    "fields": {
                        "MasterId": "Id"
                    },
                    "sort": "Sequ"
                }
            ]
        }
    },
    "PS_MDM_Mat.MatBS_Code": {
        "ComponentID": "e1e7e5f1-b8ab-4741-8a59-bc221512e7f4",
        "ComponentType": "wizard",
        "title": "选择材料分类",
        "multi": "0",
        "isleaf": "1",
        "fields": {
            "MatBS_Guid": "Id",
            "MatBS_Code": "MatBSCode",
            "MatBS_Name": "MatBSName"
        },
        "select": "",
        "distinct": []
    }
}',1,'' where not exists (select * from pb_widget where Id = '17ae2e89-7efc-42c1-89f6-6d6338c6f007');

--3
update pb_widget set Name='物资编码库',WidgetType=6,KeyWord='PS_MDM_MatBS',HtmlPath='/PowerPlat/FormXml/zh-CN/StdMasterData/Win_PS_MDM_MatBS_m.htm',ExtJson='{
    "config": {
        "openformid": "17ae2e89-7efc-42c1-89f6-6d6338c6f007",
        "joindata": {
            "KeyWord": "PS_MDM_MatBS",
            "sort": "MatBSCode",
            "filter": {},
            "children": [
                {
                    "KeyWord": "PS_MDM_Mat",
                    "fields": {
                        "MatBS_Guid": "Id"
                    },
                    "sort": "MatCode",
                    "filter": {},
                    "children": []
                }
            ]
        }
    },
    "PS_MDM_Mat.MatUnit": {
        "ComponentType": "ComboBox",
        "SourceType": "basedata",
        "Source": "BD_Unit"
    },
    "PS_MDM_Mat.OnBtnSearch": {
        "MatCode ": {
            "Lable": "物资编码",
            "IfShowLable": "1",
            "ConditionHTMLType": "TextBox",
            "IfFuzzy": "1"
        },
        "MatLongName": {
            "Lable": "长描述",
            "IfShowLable": "1",
            "ConditionHTMLType": "TextBox",
            "IfFuzzy": "1"
        }
    },
    "PS_MDM_MatBS.Upload": {
        "miniid": "PS_MDM_MatBS",
        "type": "excel",
        "sheet": {
            "parentcolumn": "编号",
            "parentsplitchar": ".",
            "sheetname": "物资编码",
            "KeyWord": "PS_MDM_MatBS",
            "fieldmap": {
                "MatBSCode": "编号",
                "MatBSName": "名称"
            },
            "gridinfo": {
                "keyword": "PS_MDM_Mat",
                "logocolumn": "是否子项",
                "logovalue": "N",
                "forkey": "MatBS_Guid",
                "fieldmap": {
                    "MatCode": "物资类别编码",
                    "MatShortName": "简称",
                    "MatLongName": "物资长描述",
                    "MatUnit": "单位"
                }
            }
        }
    }
}
',bWebForm=0,MobileExtJson='' where Id = '4cc26a50-8159-47c8-8fb7-35119698b7d7';

--4
insert into pb_widget(Id,Name,bPublish,bSysDefault,WidgetType,KeyWord,HtmlPath,ExtJson,bWebForm,MobileExtJson) 
select '4cc26a50-8159-47c8-8fb7-35119698b7d7','物资编码库',1,1,6,'PS_MDM_MatBS','/PowerPlat/FormXml/zh-CN/StdMasterData/Win_PS_MDM_MatBS_m.htm','{
    "config": {
        "openformid": "17ae2e89-7efc-42c1-89f6-6d6338c6f007",
        "joindata": {
            "KeyWord": "PS_MDM_MatBS",
            "sort": "MatBSCode",
            "filter": {},
            "children": [
                {
                    "KeyWord": "PS_MDM_Mat",
                    "fields": {
                        "MatBS_Guid": "Id"
                    },
                    "sort": "MatCode",
                    "filter": {},
                    "children": []
                }
            ]
        }
    },
    "PS_MDM_Mat.MatUnit": {
        "ComponentType": "ComboBox",
        "SourceType": "basedata",
        "Source": "BD_Unit"
    },
    "PS_MDM_Mat.OnBtnSearch": {
        "MatCode ": {
            "Lable": "物资编码",
            "IfShowLable": "1",
            "ConditionHTMLType": "TextBox",
            "IfFuzzy": "1"
        },
        "MatLongName": {
            "Lable": "长描述",
            "IfShowLable": "1",
            "ConditionHTMLType": "TextBox",
            "IfFuzzy": "1"
        }
    },
    "PS_MDM_MatBS.Upload": {
        "miniid": "PS_MDM_MatBS",
        "type": "excel",
        "sheet": {
            "parentcolumn": "编号",
            "parentsplitchar": ".",
            "sheetname": "物资编码",
            "KeyWord": "PS_MDM_MatBS",
            "fieldmap": {
                "MatBSCode": "编号",
                "MatBSName": "名称"
            },
            "gridinfo": {
                "keyword": "PS_MDM_Mat",
                "logocolumn": "是否子项",
                "logovalue": "N",
                "forkey": "MatBS_Guid",
                "fieldmap": {
                    "MatCode": "物资类别编码",
                    "MatShortName": "简称",
                    "MatLongName": "物资长描述",
                    "MatUnit": "单位"
                }
            }
        }
    }
}
',0,'' where not exists (select * from pb_widget where Id = '4cc26a50-8159-47c8-8fb7-35119698b7d7');

--5
insert into PB_Wizard(Id,WizardId,Code,Name,[Sequ],Data,FilePath) select 'e1e7e5f1-b8ab-4741-8a59-bc221512e7f4','e1e7e5f1-b8ab-4741-8a59-bc221512e7f4','WizardMDM_MatBS','选择材料分类',0,'','/PowerPlat/FormXml/zh-CN/StdMasterData/WizardMDM_MatBS.htm' where not exists (select * from PB_Wizard where Id = 'e1e7e5f1-b8ab-4741-8a59-bc221512e7f4');

--6
update PB_Wizard set WizardId='e1e7e5f1-b8ab-4741-8a59-bc221512e7f4',Code='WizardMDM_MatBS',Name='选择材料分类',[Sequ]='0',Data='',FilePath='/PowerPlat/FormXml/zh-CN/StdMasterData/WizardMDM_MatBS.htm' where Id='e1e7e5f1-b8ab-4741-8a59-bc221512e7f4'

--分割线1---------------
