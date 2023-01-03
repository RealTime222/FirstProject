start = async () => {
    await getProducts();
    await getCategories();
    
}
getProducts = async () => {
  
    //const url = "Api/products";
    //const res = await fetch(url);
   const res = await fetch(`https://localhost:44363/api/products`);
    
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const data = await res.json();
        sessionStorage.setItem("products", JSON.stringify(data));
        drawProducts(data);
        
    }
}
getCategories = async () => {
    const url = "Api/Category";
    const res = await fetch(url);
    
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const d = await res.json();
       
       fillProductsInCategory(d);
        drawCategories(d);
    }
}
fillProductsInCategory = (data) => {
    var products1 = sessionStorage.getItem("products");
    var products = JSON.parse(products1);
    console.log(products);
    console.log(data);
    for (var category = 0; category < data.length; category++) {
        for (var product = 0; product < products.length; product++) {
            if (products[product].categoryId == data[category].id) {
                data[category].products.push(products[product]);
            }
        }
    }
   // console.log(data);
}
drawProducts = (data) => {
    document.getElementById("counter").innerText = data.length;
    for (var i = 0; i < data.length; i++) {
        drawProduct(data[i]);
        //console.log(data[i]);
    }

}
drawProduct = (product) => {
    //console.log(product);
    var temp = document.getElementById("temp-card");
    var clone = temp.content.cloneNode(true);
    //console.log(product.name);
    clone.querySelector("h1").innerText = product.productName;
    clone.querySelector(".price").innerText = product.price;
    clone.querySelector(".description").innerText = product.description;
    clone.querySelector("img").src = "/images/" + product.imageUrl;
    clone.querySelector("button").setAttribute("value", product.productId);
    document.getElementById("PoductList").appendChild(clone);
}
drawCategories = (data) => {
    for (var i = 0; i < data.length; i++) {
        drawCategory(data[i]);
    }
}
drawCategory = (category) => {
    //console.log(category);
    var temp = document.getElementById("temp-category");
    var clone = temp.content.cloneNode(true);
    clone.querySelector(".OptionName").innerText = category.categoryName;
    clone.querySelector(".Count").innerText = `(${category.products.length})`;
    clone.querySelector(".opt").value = category.categoryId;
    document.getElementById("categoryList").appendChild(clone);

}
filterProducts = async () => {
    var name = document.getElementById("nameSearch").value;
    
    var minPrice = document.getElementById("minPrice").value;
    console.log(minPrice);
    var maxPrice = document.getElementById("maxPrice").value;
    var categoryList = document.getElementsByClassName("opt");
    var start = 1;
    var limit = 20;
    var direction = "ASC";
    var orderBy = "price";
    console.log(categoryList[0].checked);
    var categoryIds = "";
    for (var i = 0; i < categoryList.length; i++) {
        if (categoryList[i].checked) {
            categoryIds += `&CategoryId=${categoryList[i].value}`;
            console.log(categoryIds);
        }
    }
   
    const url = `Api/products/?name=${name}${categoryIds}&minPrice=${minPrice}&maxPrice=${maxPrice}&start=${start}&end=${limit}&dir=${direction}&orderBy=${orderBy}`;

    const res = await fetch(url);
    console.log(res);
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const data = await res.json();
        console.log(data.length);
        removeProducts();
        drawProducts(data);
    }
}

removeProducts = () => {
    var cards = document.getElementsByClassName("card");
    console.log(cards);
    for (var i = cards.length; i > 0; i--) {
        console.log(cards[0]);
        cards[0].remove();
    }
}

addToCart = (id) => {

    console.log(id);
    const productsJson = sessionStorage.getItem("products");
    const products = JSON.parse(productsJson);
    let counter = 0;
    for (let i = 0; i < products.length; i++) {
        if (products[i].productId == id) {
            
            if (sessionStorage.getItem("selectedProducts")) {
                const allSelectedProducts1 = JSON.parse(sessionStorage.getItem("selectedProducts"));
              
                allSelectedProducts1.push(products[i]);
                
                counter = allSelectedProducts1.length;
                sessionStorage.setItem("selectedProducts", JSON.stringify(allSelectedProducts1));
             
            }
            else {
                let allSelectedProducts = []
                allSelectedProducts.push(products[i])
                counter = 1;
                sessionStorage.setItem("selectedProducts", JSON.stringify(allSelectedProducts))
            }
        }

    }
    document.getElementById("ItemsCountText").innerHTML = counter;

}

document.addEventListener("load", start());

