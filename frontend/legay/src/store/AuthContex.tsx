import { createContext } from "react";
import { User } from "../models/user";

const AuthContext = createContext<User | {}>({});
