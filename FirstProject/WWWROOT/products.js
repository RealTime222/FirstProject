const conect =  async() => {


    const response = await fetch(`https://localhost:44363/api/products`);

    if (response.ok) {
        const data = await response.json();
        alert(data[0])
    }

    if (!response.ok)
        throw new Error(`the connect failed ${response.status}, try again`);
    if (response.status == 204) {
        alert("no data");
        return;
    }
}