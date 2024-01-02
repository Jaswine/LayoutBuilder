import axios from "axios";

export const $axios = axios.create({
    baseURL: "http://localhost:5179/api",
    headers: {
        'Content-Type': 'application/json',
        'Authorization':  localStorage.getItem('token') ? `Bearer ${localStorage.getItem('token')}` : null
    }
})