<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="S7_Dashboard._Default" %>

<%@ Register assembly="Microsoft.AspNet.EntityDataSource" namespace="Microsoft.AspNet.EntityDataSource" tagprefix="ef" %>

<asp:Content ID="BodyContent" 
ContentPlaceHolderID="MainContent" runat="server">
     <style>
         .label
         {
           align-self:center;
         }
         .filterrow {
         background-color:gainsboro
         }
         </style>
      <script src="../Scripts/raphael-2.1.4.min.js"></script>
    <script src="../Scripts/justgage.js"></script>
   
    <div class="jumbotron">
        
         <div class="row">
        <div class="col-md-6">
         <div id="g1" class="gauge"></div>
           </div>
             <div class="col-md-6">
         <div id="g2" class="gauge"></div>
           </div>
        <script>
            document.addEventListener("DOMContentLoaded", function (event) {
                var g1 = new JustGage({
                    id: "g1",
                    title: "Temparature 1",
                    value: 0,
                    min: 0,
                    max: 200,
                    decimals: 0,
                    gaugeWidthScale: 0.9,
                    label: "Temparature 1",
                    decimals: 2
                   
                });
                var g2 = new JustGage({
                    id: "g2",
                    title: "Temparature 2",
                    value: 0,
                    min: 0,
                    max: 200,
                    decimals: 0,
                    gaugeWidthScale: 0.6,
                    label: "Temparature 2",
                    decimals: 2,
                    
                   
                });
                setInterval(function () {
                    $.ajax({
                        type: "POST",
                        url: "Default.aspx/Getvalue",
                        data: "{'Temp':'Temparature 1'}", //Pass the parameter names and values
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            g1.refresh(msg.d);
                        }
                    });
                     $.ajax({
                        type: "POST",
                        url: "Default.aspx/Getvalue",
                         data: "{'Temp':'Temparature 2'}", //Pass the parameter names and values
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            g2.refresh(msg.d);
                        }
                    });
                   
                }, 1000); // update the charts every 5 seconds.
            })
            var timeout;
            function scheduleGridUpdate(grid) {
                window.clearTimeout(timeout);
                timeout = window.setTimeout(
                    function () { grid.Refresh(); },
                    2000
                );
            }
            function grid_Init(s, e) {
                scheduleGridUpdate(s);
            }
            function grid_BeginCallback(s, e) {
                window.clearTimeout(timeout);
            }
            function grid_EndCallback(s, e) {
                scheduleGridUpdate(s);
            }
</script> 

       </div>
    </div>
 <div class="row filterrow">

 <div class="col-md-1">
    
     <asp:Label ID="Temp" Text="Temparature" runat="server" >

     </asp:Label>
     </div>
     <div class="col-md-2">
     <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name"></asp:DropDownList>
   
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:S7ConnectionString %>" SelectCommand="select Distinct [Name] from [dbo].[Temparatures]"></asp:SqlDataSource>
   
 </div>

     <div class="col-md-1">
     <asp:Label ID="Label2" Text="Date" runat="server" >
     </asp:Label>
     </div>
     
     <div class="col-md-1">
  <asp:TextBox ID="Date" runat="server"></asp:TextBox>
   </div>     
      <div class="col-md-1"></div>
  <div class="col-md-1">
  <asp:Button ID="Filter" runat="server" Text="Filter" OnClick="Filter_Click"></asp:Button>
   </div>
 </div>    
    <p></p>
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="3600" OnTick="Timer1_Tick" ></asp:Timer>

          <asp:GridView runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" Height="100%" Width="100%" ID="Gridview2"


>
              <Columns>
                  <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                  <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" SortExpression="Date">
                  <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Time" DataFormatString="{0:HH:mm:ss}" HeaderText="Time" SortExpression="Time">
                  <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Value" DataFormatString="{0:0.00}" HeaderText="Value" SortExpression="Value">
                  <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
              </Columns>
              <PagerSettings Visible="False" />
            </asp:GridView>     
                    </ContentTemplate>
        </asp:UpdatePanel>
          
            
            
            
            <%--<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" EnableTheming="True" Theme="Office2010Blue" Width="100%" SettingsLoadingPanel-Mode="Disabled">
               <SettingsPager Mode="ShowAllRecords" Visible="False">
               </SettingsPager>
               <Settings ShowGroupPanel="True" ShowHeaderFilterButton="True" VerticalScrollableHeight="100" VerticalScrollBarMode="Auto" />
               <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
               <SettingsSearchPanel Visible="True" />
               <Columns>
                   <dx:GridViewCommandColumn VisibleIndex="0" Visible="False">
                   </dx:GridViewCommandColumn>
                   <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataDateColumn FieldName="Date" VisibleIndex="3">
                   </dx:GridViewDataDateColumn>
                   <dx:GridViewDataDateColumn FieldName="Time" VisibleIndex="4">
                       <PropertiesDateEdit DisplayFormatString="t" EditFormat="Time" EditFormatString="t">
                       </PropertiesDateEdit>
                   </dx:GridViewDataDateColumn>
                   <dx:GridViewDataTextColumn FieldName="Value" VisibleIndex="5">
                       <PropertiesTextEdit DisplayFormatString="n2">
                       </PropertiesTextEdit>
                   </dx:GridViewDataTextColumn>
               </Columns>
            </dx:ASPxGridView>--%>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="S7_Dashboard.S7Entities" EntityTypeName="" OrderBy="Id desc" TableName="Temparatures">
            </asp:LinqDataSource>
        </div>
     
    </div>

</asp:Content>
