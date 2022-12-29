

async function updateUser() {
    const user = JSON.parse(sessionStorage.getItem("details"))
    let password1 = user.password;
    const firstName2 = document.getElementById("firstName1").value
    const lastName2 = document.getElementById("lastname1").value
    // const password2 = document.getElementById("password1").value
    const email2 = document.getElementById("email1").value
    const id = user.userId;
    user2 = { "password": password1, "firstName": firstName2, "lastName": lastName2, "email": email2,"UserId":id };
    
    

    const res = await fetch(`https://localhost:44363/Api/user/${id}`,
        {
            headers: { "content-type": "application/json" },
            method: 'PUT',
            body: JSON.stringify(user2) 
        })
    if (res.status == 500) {
        alert("שגיאה בפרטי המשתמש")
        return;
    }
    else {
        alert("משתמש עודכן בהצלחה!!!")
    }
         
}