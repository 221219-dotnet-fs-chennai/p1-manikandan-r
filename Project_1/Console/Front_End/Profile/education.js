
let EmailID = localStorage.getItem("email")
EmailID = EmailID.replace(/['‘’"“”]/g, '')
console.log(EmailID)
const signinform = document.getElementById("signupform");

signinform.addEventListener("submit", event => {
    event.preventDefault();
});


fetch("https://localhost:7234/Api/TrainerLogin/GeteducationbyID?" + new URLSearchParams
    ({
        email: EmailID
    }))
    .then(response => response.json())
    .then(element => {
        const ugnamme = document.getElementById("uclgname")
        ugnamme.value = element.ug_collage

        const ugstream = document.getElementById("ugstream")
        ugstream.value = element.ug_stream

        const ugper = document.getElementById("ugper")
        ugper.value = element.ug_percentage
      
        const ugyear = document.getElementById("ugyear")
        ugyear.value = element.ug_year

        const pgnamme = document.getElementById("pclgname")
        pgnamme.value = element.pg_collage

        const pgstream = document.getElementById("pgstream")
        pgstream.value = element.pg_stream

        const pgper = document.getElementById("pgper")
        pgper.value = element.pg_percentage
      
        const pgyear = document.getElementById("pgyear")
        pgyear.value = element.pg_year
    });

async function updateEducation()
{
    let ugname = document.getElementById("uclgname").value
    let ustream = document.getElementById("ugstream").value
    let uper = document.getElementById("ugper").value
    let uyear = document.getElementById("ugyear").value
    let pgname = document.getElementById("pclgname").value
    let pstream = document.getElementById("pgstream").value
    let pper = document.getElementById("pgper").value
    let pyear = document.getElementById("pgyear").value   
    
    let val = EmailID.split('@');
    UserID = val[0];

    fetch("https://localhost:7234/Api/TrainerLogin/UpdateEducation?" + new URLSearchParams
    ({
        email: EmailID
    }),{
        method: "PUT",

        body: JSON.stringify({
            userid: UserID,
            ug_collage: ugname,
            ug_stream: ustream,
            ug_percentage: uper,
            ug_year: uyear,
            pg_collage: pgname,
            pg_stream: pstream,
            pg_percentage: pper,
            pg_year: pyear
        }),

        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })

    .then((response) => console.log(response))

    alert("Data Updated")
}