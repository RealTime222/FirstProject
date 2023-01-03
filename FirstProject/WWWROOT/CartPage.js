load = () => {
    const selectedProductsJson = sessionStorage.getItem("selectedProducts");
    const selectedProducts = JSON.parse(selectedProductsJson);
    drawSelectedProducts(selectedProducts)
    totalPriceFunc(selectedProducts);
    console.log(selectedProducts);
}
drawSelectedProducts = (selectedProducts) => {
    console.log(selectedProducts)
    for (let i = 0; i < selectedProducts.length; i++) {
        drawSelectedProduct(selectedProducts[i]);
    }
}
drawSelectedProduct = (selectedProduct) => {

    const temp = document.getElementById("hi");
    const clone = temp.content.cloneNode(true);
    let imageurl = "/images/" + selectedProduct.imageurl;
    const stringImageUrl = JSON.stringify(imageurl);
    console.log(JSON.stringify(imageurl));
    clone.querySelector(".image").style.backgroundImage = `url(${stringImageUrl})`;
    clone.querySelector(".itemName").innerText = selectedProduct.productName;
    clone.querySelector(".itemNumber").innerText = selectedProduct.p;
    document.getElementsByTagName("tbody")[0].appendChild(clone);
}
totalPriceFunc = async (selectedProducts) => {
    document.getElementById("itemCount").innerText = selectedProducts.length;
    let totalPrice = 0;
    for (let i = 0; i < selectedProducts.length; i++) {
        totalPrice += selectedProducts[i].price;
    }
    document.getElementById("totalAmount").innerText = totalPrice;

}
placeOrder = async () => {
    let price = document.getElementById("totalAmount").innerText;
    userJson = sessionStorage.getItem("user");
    userParse = JSON.parse(userJson);
    let userId = userParse.id;
    orderItems = [];
    orderItemsJson = sessionStorage.getItem("selectedProducts");
    orderItemsParse = JSON.parse(orderItemsJson);


    console.log(orderItemsParse)
    for (let i = 0; i < orderItemsParse.length; i++) {
        let amount = 0;
        for (let j = 0; j < orderItemsParse.length; j++) {
            if (orderItemsParse[i].id == orderItemsParse[j].id) {
                amount++;
            }
        }

        let orderItem = {
            "ProductId": orderItemsParse[i].id,
            "Amount": amount
        }
        orderItems.push(orderItem);
    }
    const order = {
        "Date": new Date(),
        "Price": price,
        "UserId": userId,
        "OrderItems": orderItems
    }
    console.log(order)
    const res = await fetch("https://localhost:44328/api/Order", {
        headers: { "content-type": "application/json;" },
        method: 'POST',
        body: JSON.stringify(order)
    })

    if (!res.ok)
        alert("Error! Try later please!");
    if (res.status == 204) {
        alert("no data");
        return;
    }
    const data = await res.json();
    alert("the order complited");

}

document.addEventListener("load", load());
