Imports System.Data
Imports System.Data.SqlClient
Imports AARMEmail
Partial Class ProductCreation
    Inherits System.Web.UI.Page
    Dim obj_Authenticated As String
    Dim maPlaceHolder As New PlaceHolder
    Dim obj_Tabs As UserControl
    Dim obj_LoginCtrl As UserControl
    Dim obj_WelcomCtrl As UserControl
    Dim obj_bannerCtrl As UserControl

    Dim obj_Navi As UserControl
    Dim obj_Navihome As UserControl
    Dim qry As String
    Dim Bizconnect As New BizConnectClass

    Public Sub ChkAuthentication()


        obj_Authenticated = Session("Authenticated").ToString()
        maPlaceHolder = CType(Master.FindControl("P1"), PlaceHolder)
        If Not IsDBNull(maPlaceHolder) Then

            obj_Tabs = CType(maPlaceHolder.FindControl("right1"), UserControl)
            If Not IsDBNull(obj_Tabs) Then


                obj_LoginCtrl = CType(obj_Tabs.FindControl("Login1"), UserControl)
                obj_WelcomCtrl = CType(obj_Tabs.FindControl("Welcome1"), UserControl)

                obj_Navi = CType(obj_Tabs.FindControl("Navii"), UserControl)
                Dim contp As ContentPlaceHolder
                contp = CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                obj_Navihome = CType(contp.FindControl("navihome1"), UserControl)

                If Not IsDBNull(obj_LoginCtrl) And Not IsDBNull(obj_WelcomCtrl) Then

                    If obj_Authenticated = "1" Then

                        SetVisualON()


                    Else

                        SetVisualOFF()

                    End If

                Else
                End If

            Else
            End If
        End If
    End Sub
    Public Sub SetVisualON()

        obj_LoginCtrl.Visible = False
        obj_WelcomCtrl.Visible = True
        'obj_Navi.Visible = False
        'obj_Navihome.Visible = True

    End Sub
    Public Sub SetVisualOFF()

        obj_LoginCtrl.Visible = True
        obj_WelcomCtrl.Visible = False
        'obj_Navi.Visible = True
        'obj_Navihome.Visible = False
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ChkAuthentication()
            'fillProductType()
            'fillProductCategory()
            'FillPackingtype()
            'fillUnitWeight()
            'fillUnitVolume()
            'fillUnitLH()
        End If
    End Sub
    Sub FillPackingtype()
        Dim ds As DataSet
        ds = Bizconnect.get_PackingType(DDLproducttype.SelectedValue)

        DDLpackingType.DataSource = ds
        DDLpackingType.DataTextField = "PackingMethod"
        DDLpackingType.DataValueField = "PackingMethodID"
        DDLpackingType.DataBind()
    End Sub

    Sub fillProductType()
        Dim ds As DataSet
        ds = Bizconnect.get_ProductType

        DDLproducttype.DataSource = ds
        DDLproducttype.DataTextField = "ProductType"
        DDLproducttype.DataValueField = "ProductTypeID"
        DDLproducttype.DataBind()
    End Sub
    'Sub fillMeasurementType()
    '    Dim ds As DataSet
    '    ds = Bizconnect.get_MeasurementType

    '    DDLmeasurementtype.DataSource = ds
    '    DDLmeasurementtype.DataTextField = "MeasurementType"
    '    DDLmeasurementtype.DataValueField = "MeasurementTypeID"
    '    DDLmeasurementtype.DataBind()
    'End Sub
    'Sub fillUnit()
    '    Dim ds As DataSet
    '    ds = Bizconnect.get_unit(DDLmeasurementtype.SelectedValue)

    '    DDLunit.DataSource = ds
    '    DDLunit.DataTextField = "unit"
    '    DDLunit.DataValueField = "unitid"
    '    DDLunit.DataBind()
    'End Sub

    Sub fillUnitWeight()
        Dim ds As DataSet
        ds = Bizconnect.get_unit(2)

        DDLWeightUnit.DataSource = ds
        DDLWeightUnit.DataTextField = "unit"
        DDLWeightUnit.DataValueField = "unitid"
        DDLWeightUnit.DataBind()
    End Sub
    Sub fillUnitVolume()
        Dim ds As DataSet
        ds = Bizconnect.get_unit(3)

        DDlvolumeunit.DataSource = ds
        DDlvolumeunit.DataTextField = "unit"
        DDlvolumeunit.DataValueField = "unitid"
        DDlvolumeunit.DataBind()
    End Sub
    Sub fillUnitLH()
        Dim ds As DataSet
        ds = Bizconnect.get_unit(1)
        'Length
        DDLLengthUnit.DataSource = ds
        DDLLengthUnit.DataTextField = "unit"
        DDLLengthUnit.DataValueField = "unitid"
        DDLLengthUnit.DataBind()
        'Width
        DDLwidthunit.DataSource = ds
        DDLwidthunit.DataTextField = "unit"
        DDLwidthunit.DataValueField = "unitid"
        DDLwidthunit.DataBind()
        'Height
        DDLHeightUnit.DataSource = ds
        DDLHeightUnit.DataTextField = "unit"
        DDLHeightUnit.DataValueField = "unitid"
        DDLHeightUnit.DataBind()
    End Sub
   
    Sub fillProductCategory()
        Dim ds As DataSet
        ds = Bizconnect.get_ProductCategory(DDLproducttype.SelectedValue)

        DDLproductcategory.DataSource = ds
        DDLproductcategory.DataTextField = "CategoryName"
        DDLproductcategory.DataValueField = "ProductCategoryID"
        DDLproductcategory.DataBind()
    End Sub
  
    Protected Sub Btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_submit.Click
        Dim res As Integer
        Session("ClientID") = 1
        res = Bizconnect.Insert_Product(Session("ClientID"), Txt_sku.Text, Txt_productname.Text, txt_productDescription.Text, DDLproducttype.SelectedValue, DDLproductcategory.SelectedValue, DDLpackingType.Text, Val(txt_weight.Text), DDLWeightUnit.Text, Val(txt_length.Text), DDLLengthUnit.SelectedValue, Val(Txt_width.Text), DDLwidthunit.SelectedValue, Val(txt_height.Text), DDLHeightUnit.SelectedValue, Val(txt_volume.Text), DDlvolumeunit.SelectedValue, DDLpckngsp.SelectedValue, Val(txt_transcostperunit.Text))
        If res = 1 Then
            lblmsg.Visible = True
            lblmsg.Text = "Data saved successfully"
        Else
            lblmsg.Visible = True
            lblmsg.Text = "Data not saved"
        End If

    End Sub

    Protected Sub DDLproducttype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLproducttype.SelectedIndexChanged
        fillProductCategory()
        FillPackingtype()
    End Sub
    Sub EnableSolid()
        DDLLengthUnit.Enabled = True
        DDLwidthunit.Enabled = True
        DDLHeightUnit.Enabled = True
        DDlvolumeunit.Enabled = False
        txt_length.Enabled = True
        Txt_width.Enabled = True
        txt_height.Enabled = True
        txt_volume.Enabled = False
    End Sub
    Sub EnableLiquid()
        DDLLengthUnit.Enabled = False
        DDLwidthunit.Enabled = False
        DDLHeightUnit.Enabled = False
        DDlvolumeunit.Enabled = True
        txt_length.Enabled = False
        Txt_width.Enabled = False
        txt_height.Enabled = False
        txt_volume.Enabled = True
    End Sub

    Protected Sub DDLpackingType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpackingType.SelectedIndexChanged
        If DDLpackingType.SelectedValue = 6 Then
            EnableLiquid()
        Else
            EnableSolid()
        End If
    End Sub
End Class

