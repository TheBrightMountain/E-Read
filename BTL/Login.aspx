<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTL.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container my-5">
        <div class="row">
            <div class="col-md-6 mx-auto">
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
                                    <h3>Member Login</h3>
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
                                <label class="ms-1 mb-1">
                                    Email
                                </label>
                                <div class="form-group mb-3">
                                    <asp:TextBox class="form-control" ID="TextBoxEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                </div>
                                <label class="ms-1 mb-1">
                                    Password
                                </label>
                                <div class="form-group mb-5">
                                    <asp:TextBox class="form-control" ID="TextBoxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="mb-4">
                                    <center>
                                        <asp:Label class="alert alert-danger" role="alert" ID="LabelNotify" runat="server" Visible="False"></asp:Label>
                                    </center>
                                </div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-lg w-100 mb-3" ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="signup.aspx">
                                        <input class="btn btn-secondary btn-lg w-100 mb-3" ID="ButtonSignup" type="button" value="Sign up" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
