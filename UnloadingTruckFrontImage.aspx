<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnloadingTruckFrontImage.aspx.cs" Inherits="UnloadingTruckFrontImage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <asp:ImageButton ID="FrontView" runat="server" OnClientClick="return false;" ToolTip="Click to view image" AlternateText="" Width="250px" BorderColor="Silver" BorderStyle="Groove" BorderWidth="2"/>
         <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1"  />

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

    </form>
</body>
</html>
