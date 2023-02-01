



const conect = async () => {
  
    alert("התהליך עלול לקחת מספר רגעים")
    
     const email = document.getElementById("email").value;
     const password = document.getElementById("password").value;
    
    const response = await fetch(`https://localhost:44363/api/user?email=${email}&password=${password}`);
    if (response.status != 200) {
        alert("משתמש לא קיים")
    }
     if (response.ok) {
         const data = await response.json();
        
         alert("ברוך הבא " + data.firstName + " ביצעת בעבר " + data.numOfOrders +"הזמנות ");
         sessionStorage.setItem('details', JSON.stringify(data))
       
       

         window.location.href = "welcome.html"
        

      
     }

    if (!response.ok) {
        alert("משתמש לא רשום!");
        throw new Error(`the connect failed ${response.status}, try again`);

    }
     if (response.status == 204) {
         alert("no data");
         return;
     }



}
const newUser = () => {
    const firstName2 = document.getElementById("firstName1").value
    const lastName2 = document.getElementById("lastname1").value
    const password2 = document.getElementById("password1").value
    const email2 = document.getElementById("email1").value

  
    const user = {
        FirstName: firstName2,
        LastName: lastName2,
        Password: password2,
        Email: email2
    }

    fetch("api/user", {
        method: "post",
        body: JSON.stringify(user),
        headers: {
            "Content-Type": "application/json"
        }

    }).then(res => {
        if (res.status != 200) {

            alert("שגיאה בפרטי המשתמש שים לב שהאיממיל תקין ושאורך השם הוא בין 2 ל 15 תווים")
            return res.json
        }
        else {
            alert("משתמש נוסף בהצלחה!!")
            window.location.href = "user.html"
        }
            

    })
        .then(data => {

            return data;
        })
        

}

const checkPassword = async () => {

    const password = document.getElementById("password1").value;
    const res = await fetch("https://localhost:44363/api/password", {
        headers: { "content-type": "application/json" },
        method: 'POST',
        body: JSON.stringify(password)
    })
    if (res.ok) {
        let res2 = await res.json()
        document.getElementById("aa").value = res2
        document.getElementById("password").innerText = `password strength: ${res2}`;
        
    }
    else {
        alert("password is not strong!")
    }



}