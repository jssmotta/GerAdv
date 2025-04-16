const loginData = {
    username: 'your-username',
    password: 'your-password'
};

fetch('/api/auth/login', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(loginData)
})
    .then(response => response.json())
    .then(data => {
        const authToken = data.token; // Assuming the token is in the 'token' field of the response
        // Now you can use the authToken in your update request
        const update = [
            { field: "cliente", value: "Ajfan" },
            { field: "funcionario", value: "1" }
        ];

        fetch('/api/cidade/updateColumn', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${authToken}`
            },
            body: JSON.stringify({ id: 123, campos: update })
        })
            .then(response => response.json())
            .then(data => console.log(data))
            .catch(error => console.error('Error:', error));
    })
    .catch(error => console.error('Error:', error));
