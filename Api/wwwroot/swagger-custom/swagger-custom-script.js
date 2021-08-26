(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link'); //For Changing The Link On The Logo Image
            logo[0].href = "https://rashik.com.np/";
            logo[0].target = "_blank";

            logo[0].children[0].alt = "Implemeting Swagger";
            //logo[0].children[0].src = "https://blog.rashik.com.np/wp-content/uploads/2020/06/rashikLogo-2-300x113.png"; //For Changing The Logo Image
            logo[0].children[0].src = "https://media-exp1.licdn.com/dms/image/C4D0BAQGuwfE6kLBdcA/company-logo_200_200/0/1560266636031?e=1637798400&v=beta&t=PDELvfpWgV6Tx32vwmONQlfOvZyjYwJwPttyKxAmMM8"; //For Changing The Logo Image
        });
    });
})();