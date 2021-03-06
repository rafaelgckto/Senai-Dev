import React from "react";
import ReactDOM from "react-dom";
import {
	Route,
	BrowserRouter as Router,
	Switch,
	Redirect,
} from "react-router-dom";

import "./index.css";

import App from "./App";

import reportWebVitals from "./reportWebVitals";

const routes = (
	<Router>
		<Switch>
			<Route exect path="/" component={App} />
		</Switch>
	</Router>
);

ReactDOM.render(routes, document.getElementById("root"));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
