import React from "react";
import ReactDOM from "react-dom";
import {
	Route,
	BrowserRouter as Router,
	Switch,
	Redirect,
} from "react-router-dom";
import { parseJwt, usuarioAutenticado } from "./services/auth";

import "./index.css";

import App from "./App";
import NotFound from "./pages/notfound/NotFound";
import Login from "./pages/login/Login";
import Consulta from "./pages/consulta/Consulta";

import reportWebVitals from "./reportWebVitals";

const PermissaoAdm = ({ component: Component }) => (
	<Route
		render={(props) =>
			usuarioAutenticado() && parseJwt().role === "1" ? (
				<Component {...props} />
			) : (
				<Redirect to="/login" />
			)
		}
	/>
);

const PermissaoDoctor = ({ component: Component }) => (
	<Route
		render={(props) =>
			usuarioAutenticado() && parseJwt().role === "2" ? (
				<Component {...props} />
			) : (
				<Redirect to="/login" />
			)
		}
	/>
);

const PermissaoPatient = ({ component: Component }) => (
	<Route
		render={(props) =>
			usuarioAutenticado() && parseJwt().role === "3" ? (
				<Component {...props} />
			) : (
				<Redirect to="/login" />
			)
		}
	/>
);

const routing = (
	<Router>
		<div>
			<Switch>
				<Route exact path="/" component={App} />
				<Route path="/login" component={Login} />
				<Route path="/consulta" component={Consulta} />
				<PermissaoAdm path="/consulta" component={Consulta} />
				<PermissaoDoctor path="/consulta" component={Consulta} />
				<PermissaoPatient path="/consulta" component={Consulta} />
				<Route exact path="/notfound" component={NotFound} />
				<Redirect to="/notfound" />
			</Switch>
		</div>
	</Router>
);

ReactDOM.render(routing, document.getElementById("root"));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
