import axios from "axios";

const agent = axios.create({
  baseURL: "http://localhost:5000",
});

export default agent;
