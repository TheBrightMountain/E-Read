<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BTL.Signup" %>

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
                                    <h3>Member Registration</h3>
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
                                    <div class="col-md-6">
                                        <label class="ms-1 mb-1">
                                            Email
                                        </label>
                                        <div class="form-group mb-3">
                                            <asp:TextBox class="form-control" ID="TextBoxEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="ms-1 mb-1">
                                            Password
                                        </label>
                                        <div class="form-group mb-3">
                                            <asp:TextBox class="form-control" ID="TextBoxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="ms-1 mb-1">
                                            Confirm password
                                        </label>
                                        <div class="form-group mb-5">
                                            <asp:TextBox class="form-control" ID="TextBoxConfPassword" runat="server" placeholder="Confirm password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 mb-4">
                                        <center>
                                            <asp:Label class="alert alert-danger" role="alert" ID="LabelNotify" runat="server" Text="" Visible="False"></asp:Label>
                                        </center>
                                    </div>
                                    <div class="col-12">
                                        <center>
                                            <div class="form-group">
                                                <asp:Button class="btn btn-primary btn-lg w-75 mb-3" ID="ButtonSignup" runat="server" Text="Sign up" OnClick="ButtonSignup_Click" />
                                            </div>
                                        </center>
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
