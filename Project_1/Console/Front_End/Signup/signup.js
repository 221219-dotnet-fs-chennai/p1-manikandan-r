var UserID;

function validation() {
    var val = false;

    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    var password = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$/;

    let email = document.getElementById("emailid").value;

    let pass = document.getElementById("password").value;

    if (emailRegex.test(email)) {
        if (password.test(pass)) {
            val = true;
        }
        else {
            alert("Password must contain 8 characters and an Upper case, lower case, symbol and number")
            return false;
        }
    }
    else {
        alert("Email is invalid format")
        return false;
    }

    if (val) {
        signUpfunction();
    }
}

function signUpfunction() {
    let userId = document.getElementById("userid").value;
    let email = document.getElementById("emailid").value;
    let password = document.getElementById("password").value;
    let fnmae = document.getElementById("fname").value;
    let lname = document.getElementById("lname").value;
    let age = document.getElementById("age").value;
    let gender = document.getElementById("gender").value;
    let phonenumber = document.getElementById("phonenumber").value;
    let city = document.getElementById("city").value;
    let uclg = document.getElementById("uclgname").value;
    let ustream = document.getElementById("ugstream").value;
    let ugper = document.getElementById("ugper").value;
    let ugyear = document.getElementById("ugyear").value;
    let skill1 = document.getElementById("skill1").value;
    let skill2 = document.getElementById("skill2").value;

    if (email == null || email == "") {
        alert("Email ID cannot be empty");
        return false;
    }
    if (password == null || password == "") {
        alert("Password cannot be empty");
        return false
    }
    if (fname == null || fnmae == "") {
        alert("Firstname cannot be empty");
        return false
    }
    if (lname == null || lname == "") {
        alert("Lastname cannot be empty");
        return false
    }
    if (age == null || age == 0) {
        alert("Age cannot be empty");
        return false
    }
    if (gender == null || gender == "") {
        alert("Gender cannot be empty");
        return false
    }
    if (phonenumber == null || phonenumber == "") {
        alert("Phonenumber cannot be empty");
        return false
    }
    if (city == null || city == "") {
        alert("City cannot be empty");
        return false
    }
    if (uclg == null || uclg == "") {
        alert("Ug college name cannot be empty");
        return false
    }
    if (ustream == null || ustream == "") {
        alert("Ug stream cannot be empty");
        return false
    }
    if (ugper == null || ugper == "") {
        alert("Ug percentage cannot be empty");
        return false
    }
    if (ugyear == null || ugyear == "") {
        alert("Ug year cannot be empty");
        return false
    }
    if (skill1 == null || skill1 == "") {
        alert("Skill 1 cannot be empty");
        return false
    }
    if (skill2 == null || skill2 == "") {
        alert("Skill 2 cannot be empty");
        return false
    }

    addpersonal();
    addeducation();
    addskill();
    addcompany();
}


async function addpersonal() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault();
    });

    //let userId = document.getElementById("userid").value; 
    let email = document.getElementById("emailid").value;
    let password = document.getElementById("password").value;
    let fname = document.getElementById("fname").value;
    let lname = document.getElementById("lname").value;
    let age = document.getElementById("age").value;
    let gender = document.getElementById("gender").value;
    let phonenumber = document.getElementById("phonenumber").value;
    let city = document.getElementById("city").value;

    let val = email.split('@');
    UserID = val[0];

    //console.log("1: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddTrainer",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                emailid: email,
                password: password,
                firstname: fname,
                lastname: lname,
                age: age,
                gender: gender,
                phonenumber: phonenumber,
                city: city,
            }),

            headers: {
                'Accept': 'application/json',
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((data => {
            if(data.status == 400)
            {
                alert("The data is already present in the database");
            }
        }))
        .then((response) => response.json())
        .then(json => console.log(json))
        .catch(error => console.log(error))
}

async function addeducation() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault();
    });

    let uclgname = document.getElementById("uclgname").value;
    let ugstream = document.getElementById("ugstream").value;
    let ugper = document.getElementById("ugper").value;
    let ugyear = document.getElementById("ugyear").value;
    let pclgname = document.getElementById("pclgname").value;
    let pgstream = document.getElementById("pgstream").value;
    let pgper = document.getElementById("pgper").value;
    let pgyear = document.getElementById("pgyear").value;

    //console.log("2: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddEducation",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                ug_collage: uclgname,
                ug_stream: ugstream,
                ug_percentage: ugper,
                ug_year: ugyear,
                pg_collage: pclgname,
                pg_stream: pgstream,
                pg_percentage: pgper,
                pg_year: pgyear
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}

async function addskill() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault();
    });

    let skill1 = document.getElementById("skill1").value;
    let skill2 = document.getElementById("skill2").value;
    let skill3 = document.getElementById("skill3").value;

    //console.log("3: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddSkill",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                skill_1: skill1,
                skill_2: skill2,
                skill_3: skill3
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}

async function addcompany() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault();
    });

    let companyname = document.getElementById("companyname").value;
    let field = document.getElementById("field").value;
    let experience = document.getElementById("experience").value;

    //console.log("4: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddCompany",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                companyname: companyname,
                field: field,
                experience: experience
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((data => {
            if(data.status == 200 || data.status == 204 || data.status == 201)
            {
                alert("Submitted Successfully")
            }
        }))
        .then((response) => response.json())
        .then(json => console.log(json))
}
