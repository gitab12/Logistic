<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TruckFourView.aspx.cs" Inherits="TruckFourView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title></head>
<body>
    <form id="form1" runat="server">
    <asp:ImageButton ID="FrontView" runat="server" OnClientClick="return false;" ToolTip="Click to view image" AlternateText="" Width="250px" BorderColor="Silver" BorderStyle="Groove" BorderWidth="2"/>
    <asp:ImageButton ID="RearView" runat="server" OnClientClick="return false;" ToolTip="Click to view image" AlternateText="" Width="250px" BorderColor="Silver" BorderStyle="Groove" BorderWidth="2"/><br />
    <%--<asp:Image ID="FrontView" runat="server" Width="250px" />
    <asp:Image ID="RearView" runat="server" Width="250px" /><br />--%>
    <asp:ImageButton ID="LeftView" runat="server" OnClientClick="return false;" ToolTip="Click to view image" AlternateText="" Width="250px" BorderColor="Silver" BorderStyle="Groove" BorderWidth="2"/>
    <asp:ImageButton ID="RightView" runat="server" OnClientClick="return false;" ToolTip="Click to view image" AlternateText="" Width="250px" BorderColor="Silver" BorderStyle="Groove" BorderWidth="2"/><br />
    
    <%--<asp:Image ID="LeftView" runat="server"  Width="250px"/>
    <asp:Image ID="RightView" runat="server"  Width="250px"/>--%>
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1"  />
    
        <center>
            <!-- Button used to launch the animation -->
            <%--<asp:Button ID="btnInfo" runat="server" OnClientClick="return false;" Text="Click Here"/>--%>
            <%--<asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="return false;" Text="Click Here" AlternateText="" ImageUrl="~/images/Driver Pic/default.png"/>--%>
      
        </center>

        
        <!-- "Wire frame" div used to transition from the button to the info panel -->
        <div id="flyout" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
        
        <!-- Info panel to be displayed as a flyout when the button is clicked -->
        <div id="info" style="display: none; width: 580px; z-index: 2;  font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
            <div id="btnCloseParent" style="float: right; ">
                <asp:LinkButton id="btnClose" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                    Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
            </div>
            <div>
                <p>
                <asp:Image ID="imgID" AlternateText="" Height="450px" Width="580px" runat="server" />
                   <asp:LinkButton id="lnkShow" OnClientClick="return false;" runat="server"></asp:LinkButton>
                    <asp:LinkButton OnClientClick="return false;" id="lnkClose" runat="server"></asp:LinkButton>
                </p>
            </div>
        </div>
             
             <div id="info0" style="display: none; width: 580px; z-index: 2;  font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
            <div id="btnCloseParent0" style="float: right; ">
                <asp:LinkButton id="btnClose0" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                    Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
            </div>
            <div>
                <p>
                <asp:Image ID="imgID0" AlternateText="" Height="450px" Width="580px" runat="server" />
                   <asp:LinkButton id="LinkButton1" OnClientClick="return false;" runat="server"></asp:LinkButton>
                    <asp:LinkButton OnClientClick="return false;" id="LinkButton2" runat="server"></asp:LinkButton>
                </p>
            </div>
        </div>
             
        
        
        
        <div id="info1" style="display: none; width: 580px; z-index: 2;  font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
            <div id="btnCloseParent1" style="float: right; ">
                <asp:LinkButton id="btnClose1" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                    Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
            </div>
            <div>
                <p>
                <asp:Image ID="imgID1" AlternateText="" Height="450px" Width="580px" runat="server" />
                   <asp:LinkButton id="LinkButton4" OnClientClick="return false;" runat="server"></asp:LinkButton>
                    <asp:LinkButton OnClientClick="return false;" id="LinkButton5" runat="server"></asp:LinkButton>
                </p>
            </div>
        </div>
        
        
        
        
        
        <div id="info2" style="display: none; width: 580px; z-index: 2;  font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
            <div id="btnCloseParent2" style="float: right; ">
                <asp:LinkButton id="btnClose2" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                    Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
            </div>
            <div>
                <p>
                <asp:Image ID="imgID2" AlternateText="" Height="450px" Width="580px" runat="server" />
                   <asp:LinkButton id="LinkButton6" OnClientClick="return false;" runat="server"></asp:LinkButton>
                    <asp:LinkButton OnClientClick="return false;" id="LinkButton7" runat="server"></asp:LinkButton>
                </p>
            </div>
        </div>
                
        <!-- Info1 panel to be displayed as a flyout when the button is clicked -->
        
        <script type="text/javascript" language="javascript">
            // Move an element directly on top of another element (and optionally
            // make it the same size)
            function Cover(bottom, top, ignoreSize) {
                var location = Sys.UI.DomElement.getLocation(top);
                //alert(location.y);
                top.style.position = 'absolute';
                top.style.top = '1px';
                top.style.left = '1px';

                if (!ignoreSize) {
                    top.style.height = bottom.offsetHeight + 'px';
                    top.style.width = bottom.offsetWidth + 'px';
                    alert(location);
                }
            }
        </script>
        
        <ajaxToolkit:AnimationExtender id="OpenAnimation" runat="server" TargetControlID="FrontView">
            <Animations>
                <OnClick>
                    <Sequence>
                        <%-- Disable the button so it can't be clicked again --%>
                        <EnableAction Enabled="false" />
                        
                        <%-- Position the wire frame on top of the button and show it --%>
                        <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo'), $get('flyout'));" />
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>
                        
                        <%-- Move the wire frame from the button's bounds to the info panel's bounds --%>
                        <Parallel AnimationTarget="flyout" Duration=".5" Fps="25">
                            <Move Horizontal="400" Vertical="-200" />
                            <Resize Width="580" Height="450" />
                            <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                        </Parallel>
                        
                        <%-- Move the info panel on top of the wire frame, fade it in, and hide the frame --%>
                        <ScriptAction Script="Cover($get('flyout'), $get('info'), true);" />
                        <StyleAction AnimationTarget="info" Attribute="display" Value="block"/>
                        <FadeIn AnimationTarget="info" Duration=".2"/>
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>
                        
                        <%-- Flash the text/border red and fade in the "close" button --%>
                        <Parallel AnimationTarget="info" Duration=".5">
                            <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                        <Parallel AnimationTarget="info" Duration=".5">
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeIn AnimationTarget="btnCloseParent" MaximumOpacity=".9" />
                        </Parallel>
                    </Sequence>
                </OnClick>
            </Animations>
        </ajaxToolkit:AnimationExtender>
        <ajaxToolkit:AnimationExtender id="CloseAnimation" runat="server" TargetControlID="btnClose">
            <Animations>
                <OnClick>
                    <Sequence AnimationTarget="info">
                        <%--  Shrink the info panel out of view --%>
                        <StyleAction Attribute="overflow" Value="hidden"/>
                        <Parallel Duration=".3" Fps="15">
                            <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                            <FadeOut />
                        </Parallel>
                        
                        <%--  Reset the sample so it can be played again --%>
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="width" Value="580px"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="fontSize" Value="12px"/>
                        <OpacityAction AnimationTarget="btnCloseParent" Opacity="0" />
                        
                        <%--  Enable the button so it can be played again --%>
                        <EnableAction AnimationTarget="FrontView" Enabled="true" />
                    </Sequence>
                </OnClick>
                <OnMouseOver>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                </OnMouseOver>
                <OnMouseOut>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                </OnMouseOut>
             </Animations>
        </ajaxToolkit:AnimationExtender>
        
        
        
        
        <asp:Panel ID="xmlShow" runat="server" style="display: none; z-index: 3; background-color:#DDD; border: thin solid navy;">
            <pre id="Pre1" style="margin: 5px" runat="server"><asp:Label ID="dname" runat="server" Text=""></asp:Label>
           </pre>
        </asp:Panel>
        
        <asp:Panel ID="xmlClose" runat="server" style="display: none; z-index: 3; background-color: #DDD; border: thin solid navy;">
            <pre style="margin: 5px">
            Bye !!!!
        </pre>
        </asp:Panel>
        
        <ajaxToolkit:HoverMenuExtender ID="hm2" runat="server" TargetControlID="lnkShow" PopupControlID="xmlShow" PopupPosition="Bottom" />
        <ajaxToolkit:HoverMenuExtender ID="hm1" runat="server" TargetControlID="lnkClose" PopupControlID="xmlClose" PopupPosition="Bottom" />




<ajaxToolkit:AnimationExtender id="AnimationExtender1" runat="server" TargetControlID="RearView">
            <Animations>
                <OnClick>
                    <Sequence>
                        <%-- Disable the button so it can't be clicked again --%>
                        <EnableAction Enabled="false" />
                        
                        <%-- Position the wire frame on top of the button and show it --%>
                        <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo0'), $get('flyout'));" />
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>
                        
                        <%-- Move the wire frame from the button's bounds to the info panel's bounds --%>
                        <Parallel AnimationTarget="flyout" Duration=".5" Fps="25">
                            <Move Horizontal="400" Vertical="-200" />
                            <Resize Width="580" Height="450" />
                            <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                        </Parallel>
                        
                        <%-- Move the info panel on top of the wire frame, fade it in, and hide the frame --%>
                        <ScriptAction Script="Cover($get('flyout'), $get('info0'), true);" />
                        <StyleAction AnimationTarget="info0" Attribute="display" Value="block"/>
                        <FadeIn AnimationTarget="info0" Duration=".2"/>
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>
                        
                        <%-- Flash the text/border red and fade in the "close" button --%>
                        <Parallel AnimationTarget="info0" Duration=".5">
                            <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                        <Parallel AnimationTarget="info0" Duration=".5">
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeIn AnimationTarget="btnCloseParent0" MaximumOpacity=".9" />
                        </Parallel>
                    </Sequence>
                </OnClick>
            </Animations>
        </ajaxToolkit:AnimationExtender>
        <ajaxToolkit:AnimationExtender id="AnimationExtender2" runat="server" TargetControlID="btnClose0">
            <Animations>
                <OnClick>
                    <Sequence AnimationTarget="info0">
                        <%--  Shrink the info panel out of view --%>
                        <StyleAction Attribute="overflow" Value="hidden"/>
                        <Parallel Duration=".3" Fps="15">
                            <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                            <FadeOut />
                        </Parallel>
                        
                        <%--  Reset the sample so it can be played again --%>
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="width" Value="580px"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="fontSize" Value="12px"/>
                        <OpacityAction AnimationTarget="btnCloseParent0" Opacity="0" />
                        
                        <%--  Enable the button so it can be played again --%>
                        <EnableAction AnimationTarget="RearView" Enabled="true" />
                    </Sequence>
                </OnClick>
                <OnMouseOver>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                </OnMouseOver>
                <OnMouseOut>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                </OnMouseOut>
             </Animations>
        </ajaxToolkit:AnimationExtender>
        
        
        
        
        <asp:Panel ID="Panel1" runat="server" style="display: none; z-index: 3; background-color:#DDD; border: thin solid navy;">
            <pre id="Pre2" style="margin: 5px" runat="server"><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
           </pre>
        </asp:Panel>
        
        <asp:Panel ID="Panel2" runat="server" style="display: none; z-index: 3; background-color: #DDD; border: thin solid navy;">
            <pre style="margin: 5px">
            Bye !!!!
        </pre>
        </asp:Panel>
        
        <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lnkShow" PopupControlID="xmlShow" PopupPosition="Bottom" />
        <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lnkClose" PopupControlID="xmlClose" PopupPosition="Bottom" />




<ajaxToolkit:AnimationExtender id="AnimationExtender3" runat="server" TargetControlID="LeftView">
            <Animations>
                <OnClick>
                    <Sequence>
                        <%-- Disable the button so it can't be clicked again --%>
                        <EnableAction Enabled="false" />
                        
                        <%-- Position the wire frame on top of the button and show it --%>
                        <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo1'), $get('flyout'));" />
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>
                        
                        <%-- Move the wire frame from the button's bounds to the info panel's bounds --%>
                        <Parallel AnimationTarget="flyout" Duration=".5" Fps="25">
                            <Move Horizontal="400" Vertical="-200" />
                            <Resize Width="580" Height="450" />
                            <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                        </Parallel>
                        
                        <%-- Move the info panel on top of the wire frame, fade it in, and hide the frame --%>
                        <ScriptAction Script="Cover($get('flyout'), $get('info1'), true);" />
                        <StyleAction AnimationTarget="info1" Attribute="display" Value="block"/>
                        <FadeIn AnimationTarget="info1" Duration=".2"/>
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>
                        
                        <%-- Flash the text/border red and fade in the "close" button --%>
                        <Parallel AnimationTarget="info1" Duration=".5">
                            <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                        <Parallel AnimationTarget="info1" Duration=".5">
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeIn AnimationTarget="btnCloseParent1" MaximumOpacity=".9" />
                        </Parallel>
                    </Sequence>
                </OnClick>
            </Animations>
        </ajaxToolkit:AnimationExtender>
        <ajaxToolkit:AnimationExtender id="AnimationExtender4" runat="server" TargetControlID="btnClose1">
            <Animations>
                <OnClick>
                    <Sequence AnimationTarget="info1">
                        <%--  Shrink the info panel out of view --%>
                        <StyleAction Attribute="overflow" Value="hidden"/>
                        <Parallel Duration=".3" Fps="15">
                            <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                            <FadeOut />
                        </Parallel>
                        
                        <%--  Reset the sample so it can be played again --%>
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="width" Value="580px"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="fontSize" Value="12px"/>
                        <OpacityAction AnimationTarget="btnCloseParent1" Opacity="0" />
                        
                        <%--  Enable the button so it can be played again --%>
                        <EnableAction AnimationTarget="LeftView" Enabled="true" />
                    </Sequence>
                </OnClick>
                <OnMouseOver>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                </OnMouseOver>
                <OnMouseOut>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                </OnMouseOut>
             </Animations>
        </ajaxToolkit:AnimationExtender>
        
        
        
        
        
        
     
     
     <ajaxToolkit:AnimationExtender id="AnimationExtender5" runat="server" TargetControlID="RightView">
            <Animations>
                <OnClick>
                    <Sequence>
                        <%-- Disable the button so it can't be clicked again --%>
                        <EnableAction Enabled="false" />
                        
                        <%-- Position the wire frame on top of the button and show it --%>
                        <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo2'), $get('flyout'));" />
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>
                        
                        <%-- Move the wire frame from the button's bounds to the info panel's bounds --%>
                        <Parallel AnimationTarget="flyout" Duration=".5" Fps="25">
                            <Move Horizontal="400" Vertical="-200" />
                            <Resize Width="580" Height="450" />
                            <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                        </Parallel>
                        
                        <%-- Move the info panel on top of the wire frame, fade it in, and hide the frame --%>
                        <ScriptAction Script="Cover($get('flyout'), $get('info2'), true);" />
                        <StyleAction AnimationTarget="info2" Attribute="display" Value="block"/>
                        <FadeIn AnimationTarget="info2" Duration=".2"/>
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>
                        
                        <%-- Flash the text/border red and fade in the "close" button --%>
                        <Parallel AnimationTarget="info2" Duration=".5">
                            <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                        <Parallel AnimationTarget="info2" Duration=".5">
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeIn AnimationTarget="btnCloseParent2" MaximumOpacity=".9" />
                        </Parallel>
                    </Sequence>
                </OnClick>
            </Animations>
        </ajaxToolkit:AnimationExtender>
        <ajaxToolkit:AnimationExtender id="AnimationExtender6" runat="server" TargetControlID="btnClose2">
            <Animations>
                <OnClick>
                    <Sequence AnimationTarget="info2">
                        <%--  Shrink the info panel out of view --%>
                        <StyleAction Attribute="overflow" Value="hidden"/>
                        <Parallel Duration=".3" Fps="15">
                            <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                            <FadeOut />
                        </Parallel>
                        
                        <%--  Reset the sample so it can be played again --%>
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="width" Value="580px"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="fontSize" Value="12px"/>
                        <OpacityAction AnimationTarget="btnCloseParent2" Opacity="0" />
                        
                        <%--  Enable the button so it can be played again --%>
                        <EnableAction AnimationTarget="RightView" Enabled="true" />
                    </Sequence>
                </OnClick>
                <OnMouseOver>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                </OnMouseOver>
                <OnMouseOut>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                </OnMouseOut>
             </Animations>
        </ajaxToolkit:AnimationExtender>   
        
        
        <asp:Panel ID="Panel3" runat="server" style="display: none; z-index: 3; background-color:#DDD; border: thin solid navy;">
            <pre id="Pre3" style="margin: 5px" runat="server"><asp:Label ID="Label2" runat="server" Text=""></asp:Label>
           </pre>
        </asp:Panel>
        
        <asp:Panel ID="Panel4" runat="server" style="display: none; z-index: 3; background-color: #DDD; border: thin solid navy;">
            <pre style="margin: 5px">
            Bye !!!!
        </pre>
        </asp:Panel>
        
        <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender3" runat="server" TargetControlID="lnkShow" PopupControlID="xmlShow" PopupPosition="Bottom" />
        <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" TargetControlID="lnkClose" PopupControlID="xmlClose" PopupPosition="Bottom" />


    </form>
</body>
</html>
