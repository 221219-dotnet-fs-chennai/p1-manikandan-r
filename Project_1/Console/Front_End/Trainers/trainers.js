

var mainDiv = document.querySelector(".maindiv");

mainDiv.innerHTML = ""

fetch("https://localhost:7234/Api/User/GetAllTrainers")
    .then(res => res.json())
    .then(users => {
        users.reverse()
        users.forEach(element => {
            // console.log(element.firstname);

            const div = document.createElement('div')
            div.setAttribute('href', 'displayTrainer.html')
            div.className = 'seconddiv'

            const image = document.createElement('img')
            image.setAttribute('src', 'user.png')
            image.setAttribute('width', '30%')

            const name = document.createElement('p')
            name.textContent = element.firstname + " " + element.lastname
            name.className = 'fname'

            const image1 = document.createElement('img')
            image1.setAttribute('src', 'contact.png')
            image1.setAttribute('width', '14%')
            image1.setAttribute('height', '4%')

            const email = document.createElement('p')
            email.textContent = element.emailid
            email.className = 'emailID'

            const phonenum = document.createElement('p')
            phonenum.textContent = element.phonenumber
            phonenum.className = 'phonenum'

            const eduimg = document.createElement('img')
            eduimg.setAttribute('src', 'education.png')
            eduimg.setAttribute('width', '15%')
            eduimg.setAttribute('height', '6%')

            const education = document.createElement('p')
            education.textContent = "UG: " + element.ug_stream + ", " + element.ug_year
            education.className = 'skill1'

            const image2 = document.createElement('img')
            image2.setAttribute('src', 'skill.png')
            image2.setAttribute('width', '12%')
            image2.setAttribute('height', '4%')

            const skill1 = document.createElement('p')
            skill1.textContent = element.skill_1 + ", " + element.skill_2
            skill1.className = 'skill1'

            const image3 = document.createElement('img')
            image3.setAttribute('src', 'location.png')
            image3.setAttribute('width', '10%')
            image3.setAttribute('height', '3.5%')

            const city = document.createElement('p')
            city.textContent = element.city
            city.className = 'city'

            div.appendChild(image)
            div.appendChild(name)
            div.appendChild(document.createElement('hr'))
            div.appendChild(image1)
            div.appendChild(email)
            div.appendChild(phonenum)
            div.appendChild(document.createElement('hr'))
            div.appendChild(eduimg)
            div.appendChild(education)
            div.appendChild(document.createElement('hr'))
            div.appendChild(image2)
            div.appendChild(skill1)
            div.appendChild(document.createElement('hr'))
            div.appendChild(image3)
            div.appendChild(city)
            mainDiv.appendChild(div)
        });
    })


