<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BTL.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container my-5">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/user.png" width="150" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Profile</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>
                        <div class="row p-3 mb-5">
                            <div class="col">
                                <div class="row mb-md-3">
                                    <div class="col-md-6">
                                        <label class="ms-1 mb-1">
                                            Name
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBoxName" runat="server" placeholder="Name" TextMode="SingleLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="ms-1 mb-1">
                                            Date of birth
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBoxBirthdate" runat="server" placeholder="Birthdate" TextMode="Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <label class="ms-1 mb-1">
                                            Phone
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBoxPhone" runat="server" placeholder="Phone" TextMode="Phone"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="ms-1 mb-1">
                                            City
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBoxCity" runat="server" placeholder="City"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Login credentials</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <div class="row">
                                    <div class="col-md-6 mb-3">
                                        <label class="ms-1 mb-1">
                                            Email
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control-plaintext" ID="TextBoxEmail" runat="server" placeholder="Email" TextMode="Email" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-3">
                                        <label class="ms-1 mb-1">
                                            Password
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBoxCurrentPassword" runat="server" placeholder="Current password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 mb-3">
                                        <label class="ms-1 mb-1">
                                            Password
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBoxNewPassword" runat="server" placeholder="New password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-3">
                                        <label class="ms-1 mb-1">
                                            Confirm password
                                        </label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBoxConfNewPassword" runat="server" placeholder="Confirm new password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="mb-4">
                                    <center>
                                        <asp:Label class="alert alert-danger" role="alert" ID="LabelNotify" runat="server" Text="" Visible="False"></asp:Label>
                                    </center>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 mb-3">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-danger btn-lg w-100" ID="ButtonDelete" runat="server" Text="Delete permanently" OnClick="ButtonDelete_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-3">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-success btn-lg w-100" ID="ButtonUpdate" runat="server" Text="Update"  OnClick="ButtonUpdate_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
