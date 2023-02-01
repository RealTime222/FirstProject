load = () => {
    const selectedProductsJson = sessionStorage.getItem("selectedProducts");
    const selectedProducts = JSON.parse(selectedProductsJson);
     drawSelectedProducts(selectedProducts)
     totalPriceFunc(selectedProducts);
     console.log(selectedProducts);
}
drawSelectedProducts =  (selectedProducts) => {
    console.log(selectedProducts)
    for (let i = 0; i < selectedProducts.length; i++) {
         drawSelectedProduct(selectedProducts[i]);
    }
}
drawSelectedProduct = (selectedProduct) => {
   
    const temp = document.getElementById("temp-row");
    const clone = temp.content.cloneNode(true);
    let imageUrl = "/images/" + selectedProduct.imageUrl;
    const stringImageUrl = JSON.stringify(imageUrl);
    console.log(JSON.stringify(imageUrl));
    clone.querySelector(".image").style.backgroundImage = `url(${ stringImageUrl })`;
    clone.querySelector(".itemName").innerText = selectedProduct.productName;
    clone.querySelector(".itemNumber").innerText = selectedProduct.price;
    clone.querySelector("button").setAttribute("value", selectedProduct.productId);
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
    let priceFromJs = document.getElementById("totalAmount").innerText;
    let userParse = JSON.parse(sessionStorage.getItem("details"))
  

    let userId = userParse.userId;
    orderItems = [];
    orderItemsJson = sessionStorage.getItem("selectedProducts");
    orderItemsParse = JSON.parse(orderItemsJson);
    

    console.log(orderItemsParse)
    
    var price = 0;
    for (let i = 0; i < orderItemsParse.length; i++) {

        let amount = 0;
        for (let j = 0; j < orderItemsParse.length; j++) {
            if (orderItemsParse[i].productId == orderItemsParse[j].productId) {
                amount++;
            }
        }


        let orderItem = {
            "ProductId": orderItemsParse[i].productId,
            "Amount": amount
        }
        orderItems.push(orderItem);
        price += orderItemsParse[i].price;

    }
   
    else {
        const order = {
            "date": new Date().getDate(),
            "price": price,
            "userId": userId,
            "OrderItems": orderItems
        }
        console.log(order)
        const res = await fetch("https://localhost:44363/api/Order", {
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
 
      
        for (let k = 0; k < orderItemsParse.length; k++) {
            deleteAfterOrder(orderItemsParse[k].productId)

        }
        alert("the order complited!!!!!!!!!!!");

    }
   
}


deleteProduct = (id) => {
    const ans = confirm("האם למחוק פריט זה?")
    if (ans) {
            var newArr = [];
        const a = document.getElementsByClassName("item-row");
            //const productsJson = sessionStorage.getItem("products");
            //const products = JSON.parse(productsJson);
            const allSelectedProducts1 = JSON.parse(sessionStorage.getItem("selectedProducts"));
            for (let i = 0; i < allSelectedProducts1.length; i++) {
                if (allSelectedProducts1[i].productId != id) {
                    newArr.push(allSelectedProducts1[i]);
                }
                else {
                    a[i].remove();
                    deletedProduct = a[i];
                }
         
            }
    
            sessionStorage.setItem("selectedProducts", JSON.stringify(newArr));
    
            }
}

deleteAfterOrder = (id) => {
    var newArr = [];
    const a = document.getElementsByClassName("item-row");
  ;
    const allSelectedProducts1 = JSON.parse(sessionStorage.getItem("selectedProducts"));
    for (let i = 0; i < allSelectedProducts1.length; i++) {
        if (allSelectedProducts1[i].productId != id) {
            newArr.push(allSelectedProducts1[i]);
        }
        else {
            a[i].remove();
            deletedProduct = a[i];
        }

    }

    sessionStorage.setItem("selectedProducts", JSON.stringify(newArr));


}


//document.addEventListener("load", load());
