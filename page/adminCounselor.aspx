<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminCounselor.aspx.cs" Inherits="page_adminCounselor" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    /
    <!-- https://fonts.google.com/specimen/Roboto -->
    <link rel="stylesheet" href="../css/fontawesome.min.css" />
    <!-- https://fontawesome.com/ -->
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <!-- https://getbootstrap.com/ -->
    <link rel="stylesheet" href="../css/templatemo-style.css" />
    <link rel="stylesheet" href="../css/search.css" />
    <!--
	Product Admin CSS Template
	https://templatemo.com/tm-524-product-admin
	-->
</head>

<body id="reportsPage">
    <div class="" id="home">
        <nav class="navbar navbar-expand-xl">
            <div class="container h-100">
                <a class="navbar-brand" href="index.html">
                    <h1 class="tm-site-title mb-0">
                        <asp:Label ID="Label1" runat="server" Text="Label"><p class="text-white mt-5 mb-5">欢迎回来, <b>管理员</b></p></asp:Label>
                    </h1>
                </a>
                <button class="navbar-toggler ml-auto mr-0" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fas fa-bars tm-nav-icon"></i>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mx-auto h-100">
                        <li class="nav-item">
                            <a class="nav-link active" href="#">
                                <i class="fas fa-tachometer-alt"></i>
                                数据统计
                                <span class="sr-only">(current)</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="javascript:;">
                                <i class="far fa-user"></i>
                                账户信息
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="javascript:;">
                                <button id="searchButton" type="button" class="btn btn-primary btn-lg">
                                    <svg t="1607545578118" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="3206" width="24" height="24">
                                        <path d="M743.416465 440.95258a25.884142 25.884142 0 0 0-25.542814 26.168584c0 32.653841-6.143928 65.819677-18.88689 95.685994l-0.625771 1.251541a241.092298 241.092298 0 0 1-54.15759 80.383063 245.586468 245.586468 0 0 1-81.236386 54.214478 240.637193 240.637193 0 0 1-95.856659 19.171332 25.770366 25.770366 0 0 0 0 51.483844c38.968434 0 78.505751-7.67991 115.653762-22.925955a295.477442 295.477442 0 0 0 97.961523-65.762788 298.321853 298.321853 0 0 0 64.795689-96.539318l0.62577-1.763535a295.989436 295.989436 0 0 0 23.153508-115.198656 25.770366 25.770366 0 0 0-25.884142-26.168584M349.63617 188.823966c-18.545561 7.338581-35.89647 16.440697-51.085626 27.078795-16.497585 11.263869-31.686741 22.812178-45.055475 36.806682a326.822854 326.822854 0 0 0-37.148011 45.112362v0.625771a246.212239 246.212239 0 0 0-27.363236 51.199403c-6.08704 12.458521 0 27.363236 13.368733 33.165835a25.144596 25.144596 0 0 0 33.165835-13.710062c6.371481-14.904715 13.994503-29.240548 23.437949-42.666169a263.392483 263.392483 0 0 1 30.4352-37.148011c11.54831-10.922539 24.34816-21.901967 37.773782-31.004083 13.311845-8.874563 27.932119-16.497585 41.926622-22.584625a25.827254 25.827254 0 0 0 13.425621-34.132936c-4.892387-12.742962-20.081543-18.886891-32.881394-12.742962m387.067484 548.174938l-0.568882 0.568882a395.942047 395.942047 0 0 1-122.992343 81.919044 382.459538 382.459538 0 0 1-146.032074 29.297436 380.752891 380.752891 0 0 1-146.088962-29.297436 395.430053 395.430053 0 0 1-123.845667-82.487926 381.776879 381.776879 0 0 1-82.487926-124.300772l-1.194653-2.104864a371.935216 371.935216 0 0 1-27.989007-143.472104c0-52.337167 10.353657-101.659258 29.18366-146.145851a380.866668 380.866668 0 0 1 82.487926-124.243884 381.549326 381.549326 0 0 1 269.934629-111.500921 388.546578 388.546578 0 0 1 146.032074 28.671665c46.307015 19.171332 88.290525 47.786109 123.561225 82.829256l2.161753 2.161753a375.291622 375.291622 0 0 1 80.610615 122.082131l0.9671 1.820423c17.919791 44.486592 27.647677 93.239801 27.647677 144.325428 0 51.199403-9.727887 100.578382-28.614777 145.633856a372.845428 372.845428 0 0 1-82.772368 124.243884m274.485687 213.78595l-185.28495-185.171173a478.145533 478.145533 0 0 0 72.703152-120.034155c22.527737-54.783361 35.2707-115.71065 35.2707-178.458362a466.483447 466.483447 0 0 0-34.360488-176.581051l-0.910212-2.844412a467.96254 467.96254 0 0 0-99.213065-148.819597l-2.104864-2.446193A480.022844 480.022844 0 0 0 646.023823 34.656876h-0.568882A459.144866 459.144866 0 0 0 467.110355 0.011947 465.231906 465.231906 0 0 0 35.613167 288.37836 460.055077 460.055077 0 0 0 0.001138 467.064275c0 62.121942 12.458521 121.570137 34.360488 176.069057l1.251541 2.446194c23.437949 56.888225 58.424207 108.65651 101.033488 151.664008h0.568882a471.774052 471.774052 0 0 0 151.550232 101.716147 468.872752 468.872752 0 0 0 357.258054 0 487.361425 487.361425 0 0 0 119.294608-72.475599l185.341838 185.171173c16.725138 16.497585 43.803933 16.497585 60.529072-0.341329 17.066468-16.725138 17.066468-43.803933 0-60.58596" fill="#ffffff" p-id="3207"></path></svg><span style="font-size: 14px; letter-spacing: 2px; text-indent: 4px">  查 询</span></button>
                            </a>
                        </li>
                    </ul>
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link d-block" href="login.html">管理员, <b>注销</b>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

        </nav>
        <div class="container">
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
        </div>
        <footer class="tm-footer row tm-mt-small">
            <div class="col-12 font-weight-light">
                <p class="text-center text-white mb-0 px-4 small">Copyright &copy; 2019.Company name All rights reserved.<a href="javascript:;">兴义师范学院缴费系统;</a></p>
            </div>
        </footer>
    </div>
    <div class="" id="searchView">
        <svg id="close" t="1607649420226" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="3172" width="30" height="30">
            <path d="M921.856 987.008c-13.80352 0-26.7264-5.31456-36.37248-14.96064L512 598.56384l-373.48352 373.48352c-9.64608 9.64608-22.56384 14.96064-36.37248 14.96064s-26.7264-5.31456-36.37248-14.96064l-2.048-2.048c-9.64608-9.64608-14.95552-22.55872-14.95552-36.37248 0-13.80352 5.31456-26.7264 14.95552-36.37248L437.21216 523.776 63.72352 150.29248c-9.88672-9.6256-15.33952-22.54848-15.33952-36.37248s5.4528-26.74688 15.36512-36.39296l2.02752-2.02752c9.64608-9.64608 22.55872-14.95552 36.37248-14.95552 13.80864 0 26.7264 5.31456 36.37248 14.96064L512 449.49504l373.48352-373.99552c9.64608-9.64608 22.56384-14.96064 36.37248-14.96064s26.7264 5.31456 36.37248 14.96064l2.048 2.04288c20.05504 20.05504 20.05504 52.68992 0 72.74496L586.78784 523.776l373.48352 373.48352c9.64608 9.64608 14.96064 22.56384 14.96064 36.37248s-5.31456 26.7264-14.96064 36.37248l-2.048 2.048c-9.64096 9.64096-22.56384 14.95552-36.36736 14.95552z" p-id="3173" fill="#ffffff"></path><path d="M921.856 63.104c12.544 0 25.088 4.736 34.56 14.208l2.048 2.048c18.944 18.944 18.944 50.176 0 69.12l-375.296 375.296 375.296 375.296c18.944 18.944 18.944 50.176 0 69.12l-2.048 2.048c-9.472 9.472-22.016 14.208-34.56 14.208s-25.088-4.736-34.56-14.208L512 594.944l-375.296 375.296c-9.472 9.472-22.016 14.208-34.56 14.208s-25.088-4.736-34.56-14.208l-2.048-2.048c-18.944-18.944-18.944-50.176 0-69.12l375.296-375.296L65.536 148.48c-19.456-18.944-19.456-50.176 0-69.12l2.048-2.048c9.472-9.472 22.016-14.208 34.56-14.208s25.088 4.736 34.56 14.208L512 453.12l375.296-375.808c9.472-9.472 22.016-14.208 34.56-14.208m0-5.12c-14.4896 0-28.05248 5.5808-38.17984 15.70816L512 445.8752 140.32896 73.69216c-10.13248-10.13248-23.69024-15.70816-38.18496-15.70816s-28.05248 5.5808-38.17984 15.70816l-2.048 2.048A52.91008 52.91008 0 0 0 45.824 113.92c0 14.5152 5.7344 28.09344 16.13824 38.22592L433.59232 523.776l-371.67616 371.67616c-10.12736 10.12736-15.70816 23.69024-15.70816 38.17984s5.5808 28.05248 15.70816 38.17984l2.048 2.048c10.12736 10.12736 23.69024 15.70816 38.17984 15.70816s28.05248-5.5808 38.17984-15.70816L512 602.18368l371.67616 371.67616c10.12736 10.12736 23.69024 15.70816 38.17984 15.70816s28.05248-5.5808 38.17984-15.70816l2.048-2.048c10.12736-10.12736 15.70816-23.69024 15.70816-38.17984s-5.5808-28.05248-15.70816-38.17984L590.40768 523.776l371.67616-371.67616c21.05344-21.05344 21.05344-55.30624 0-76.35968l-2.048-2.048c-10.12736-10.12736-23.69024-15.70816-38.17984-15.70816z" p-id="3174" fill="#ffffff"></path></svg>
        <div class="container">
            <iframe id="inlineFrameExample"
                title="Inline Frame Example"
                style="width: 100%; height: 53px;"
                name="Iframe"
                frameborder="no"
                src="./Search.aspx"></iframe>
        </div>
    </div>

    <script src="../js/jquery-3.3.1.min.js"></script>
    <!-- https://jquery.com/download/ -->
    <script src="../js/moment.min.js"></script>
    <!-- https://momentjs.com/ -->
    <script src="../js/Chart.min.js"></script>
    <!-- http://www.chartjs.org/docs/latest/ -->
    <script src="../js/bootstrap.min.js"></script>
    <!-- https://getbootstrap.com/ -->
    <script src="../js/tooplate-scripts.js"></script>
    <script src="../js/search.js"></script>
    <script>
        Chart.defaults.global.defaultFontColor = 'white';
        let ctxLine,
            ctxBar,
            ctxPie,
            optionsLine,
            optionsBar,
            optionsPie,
            configLine,
            configBar,
            configPie,
            lineChart;
        barChart, pieChart;
        // DOM is ready
        $(function () {
            drawLineChart(); // Line Chart
            drawBarChart(); // Bar Chart
            drawPieChart(); // Pie Chart

            $(window).resize(function () {
                updateLineChart();
                updateBarChart();
            });
        })
    </script>
</body>

</html>
