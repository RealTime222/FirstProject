



const conect = async () => {
  
    alert("התהליך עלול לקחת מספר רגעים")
    
     const email = document.getElementById("email").value;
     const password = document.getElementById("password").value;
     //alert(email);
     //alert(password)
     const response = await fetch(`https://localhost:44363/api/user?email=${email}&password=${password}`);
     if (response.ok) {
         const data = await response.json();
         // data = (user)data[0];
         alert("ברוך הבא " + data.firstName + " ביצעת בעבר " + data.numOfOrders +"הזמנות ");
         sessionStorage.setItem('details', JSON.stringify(data))
       
       

         window.location.href = "welcome.html"
         //alert(data);

      
     }

     if (!response.ok)
         throw new Error(`the connect failed ${response.status}, try again`);
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

    alert(firstName2)
    alert(lastName2);
    alert(email2)
    alert(password2)
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
        if (res.status == 500) {
            alert("שגיאה בפרטי המשתמש")
                        return res.json
        }
        else
            alert("משתמש נוסף בהצלחה!!")

    })
        .then(data => {
            return data;
        })
        

}

const checkEmail = () => {
    let tmp = document.getElementById("email1").value;
  
    fetch("api/password", {
        method: "post",
        body: JSON.stringify(tmp),
        headers: {
            "Content-Type": "application/json"
        }

    }).then(res => {
       
        if (res.status == 500) {
            alert("שגיאה ")
            return res.json
        }
        else {
            let res2 = res.json
            alert(res2)
            document.getElementById("aa").status = res;
        }
            

    })
        .then(data => {
            return data;
        })

}