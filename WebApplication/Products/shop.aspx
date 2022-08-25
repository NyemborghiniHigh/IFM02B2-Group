<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="IFM02B2_Project.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!--Second Navigation-->
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container px-4 px-lg-5">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4">
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Category</a>
                        <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <li><asp:LinkButton ID="raw" runat="server" CssClass="dropdown-item" OnClick="LinkButton1_Click">Raw</asp:LinkButton></li>
                            <li><hr class="dropdown-divider" /></li>
                            <li><asp:LinkButton ID="kibble" runat="server" CssClass="dropdown-item" OnClick="LinkButton3_Click">Kibble</asp:LinkButton></li>
                            <li><asp:LinkButton ID="dry" runat="server" CssClass="dropdown-item" OnClick="LinkButton2_Click">Dry Food</asp:LinkButton></li>
                            
                        </ul>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Animal Type</a>
                        <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <li><asp:LinkButton ID="dog" runat="server" CssClass="dropdown-item" OnClick="dog_Click">Dogs</asp:LinkButton></li>
                            
                            <li><asp:LinkButton ID="cat" runat="server" CssClass="dropdown-item" OnClick="cat_Click">Cats</asp:LinkButton></li>
                            <li><asp:LinkButton ID="reptile" runat="server" CssClass="dropdown-item" OnClick="reptile_Click">Reptiles</asp:LinkButton></li>
                            <li><asp:LinkButton ID="bird" runat="server" CssClass="dropdown-item" OnClick="bird_Click">Birds</asp:LinkButton></li>
                        </ul>
                    </li>
                    <li class="nav-item"><a class="nav-link active" aria-current="page" href="shop.aspx">All Products</a></li>
                       
                </ul>
                <form class="d-flex">
                    <button class="btn btn-outline-dark" type="submit">
                        <i class="bi-cart-fill me-1"></i>
                        Cart
                        <span class="badge bg-dark text-white ms-1 rounded-pill">0</span>
                    </button>
                 </form>
			</div>
        </nav>

     <!--Shop content-->

        <!-- Section-->
    <div>
        <section class="py-5">
            <div class="container px-4 px-lg-5 mt-5">
                <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center" id="shopDiv" runat="server">
                    
                </div>
            </div>
        </section>
        </div>
</asp:Content>
