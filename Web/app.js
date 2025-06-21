let token = null;
const apiUrl = 'http://localhost:5000/api';
const connection = new signalR.HubConnectionBuilder().withUrl('http://localhost:5000/taskhub').build();
connection.on('ReceiveTaskUpdate', (taskID, status) => {fetchTasks();});

connection.start().catch(err => console.error(err));

async function login() {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const response = await fetch('${apiUrl}/auth/login', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({username, passwordHash: password})
    });
    const data = await response.json();
    if(data.token) {
        token = data.token;
        document.getElementById('auth').style.display = 'none';
        document.getElementById('task').style.display = 'block';
        fetchTasks();
    }
}//

async function register() {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    await fetch(`${apiUrl}/auth/register`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, passwordHash: password, role: 'Member' })
    });
    alert('Registered! Please login.');
}
async function fetchTasks() {
    const response = await fetch(`${apiUrl}/tasks`, {
        headers: { 'Authorization': `Bearer ${token}` }
    });
    const tasks = await response.json();
    const taskList = document.getElementById('taskList');
    taskList.innerHTML = '';
    tasks.forEach(task => {
        const li = document.createElement('li');
        li.textContent = `${task.title} - ${task.status} (Due: ${task.dueDate})`;
        taskList.appendChild(li);
    });
}

async function createTask() {
    const title = document.getElementById('taskTitle').value;
    const description = document.getElementById('taskDesc').value;
    const dueDate = document.getElementById('taskDueDate').value;
    await fetch(`${apiUrl}/tasks`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({ title, description, assigneeId: 1, status: 'Pending', dueDate })
    });
    fetchTasks();
}