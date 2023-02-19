
function validation() {
    var val = false;

    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    let email = document.getElementById("email").value;


    if(emailRegex.test(email))
    {
        val = true;
    }
    else
    {
        alert("Email is invalid format")
    }

    if(val)
    {
        signin();
    }
}

async function signin() {
    const signinform = document.getElementById("loginform");

    signinform.addEventListener("submit", event => {
        event.preventDefault();
    });

    let email = document.getElementById("email").value;
    let pass = document.getElementById("pass").value;

    // console.log(email)

    await fetch("https://localhost:7234/Api/TrainerLogin/LoginPage?" + new URLSearchParams
        ({
            Email: email,
            Password: pass
        }), {
        method: "GET",

        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })

        .then((response) => {
            if (response.status == 200) {
                alert("Logged in Sucessfully");
                localStorage.setItem("email", email)
                localStorage.setItem("password", pass)
                window.location.href = "../Profile/profile.html";

            }
            else {
                alert("Please check the credentails");
            }
        })
        .then((response) => response.json())
        .then(json => console.log(json))
}



