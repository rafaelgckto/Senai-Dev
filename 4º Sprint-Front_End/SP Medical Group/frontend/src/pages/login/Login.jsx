import React, { Component } from "react";
import axios from "axios";
import { parseJwt, usuarioAutenticado } from "../../services/auth";

import "../../assets/css/login.css";

import imgBackground from "../../assets/img/png/2674_souprofissional_compress.webp";
import imgLogo from "../../assets/img/png/logo_spmedgroup_v1.png";

class Login extends Component {
	constructor(props) {
		super(props);
		this.state = {
			email: "",
			senha: "",
			erroMensagem: "",
			isLoading: false,
		};
	}

	efetuaLogin = (event) => {
		event.preventDefault();
		this.setState({ erroMensagem: "", isLoading: true });

		axios
			.post("http://localhost:5000/api/login", {
				email: this.state.email,
				senha: this.state.senha,
			})
			.then((resposta) => {
				if (resposta.status === 200) {
					localStorage.setItem("usuario-login", resposta.data.token); // salva o token no localStorage,
					console.log("Meu token é: " + resposta.data.token); // exibe o token no console do navegador
					this.setState({ isLoading: false }); // e define que a requisição terminou

					let base64 = localStorage.getItem("usuario-login").split(".")[1]; // Define a variável base64 que vai receber o payload do token

					console.log(base64); // Exibe no console o valor presente na variável base64
					console.log(window.atob(base64)); // Exibe no console o valor convertido de base64 para string
					console.log(JSON.parse(window.atob(base64))); // Exibe no console o valor convertido da string para JSON
					console.log(parseJwt().role); // Exibe no console apenas o tipo de usuário logado

					const { history } = this.props;

					if (
						parseJwt().role === "1" ||
						parseJwt().role === "2" ||
						parseJwt().role === "3"
					) {
						history.push("/consulta");
						console.log("estou logado: " + usuarioAutenticado());
					} else {
						history.push("/");
					}
				}
			})
			.catch(() => {
				this.setState({
					erroMensagem: "E-mail ou senha inválidos! Tente novamente.",
					isLoading: false,
				});
			});
	};

	atualizaStateCampo = (campo) => {
		this.setState({ [campo.target.name]: campo.target.value });
	};

	render() {
		return (
			<div>
				<img
					className="img-bg"
					src={imgBackground}
					alt="imagem background"
				/>

				<section className="model-login">
					<img
						className="img-logo"
						src={imgLogo}
						alt="Logo Medical Group"
					/>

					<form onSubmit={this.efetuaLogin}>
						<div className="item">
							<label
								for="login-email"
								className="label label-one"
								style={{ display: "grid" }}
							>
								Email
							</label>

							<input
								id="login-email"
								className="inputs-text login"
								type="text"
								name="email"
								value={this.state.email}
								onChange={this.atualizaStateCampo}
							/>
						</div>

						<div className="item">
							<label
								for="login-password"
								className="label label-two"
								style={{ display: "grid" }}
							>
								Password
							</label>

							<input
								id="login-password"
								className="inputs-text login"
								type="password"
								name="senha"
								value={this.state.senha}
								onChange={this.atualizaStateCampo}
							/>
						</div>

						<p style={{ color: "red", textAlign: "center" }}>
							{this.state.erroMensagem}
						</p>

						{this.state.isLoading === true && (
							<div className="item">
								<button
									type="submit"
									id="btn__login"
									className="btn btn-login"
									disabled
								>
									Loading...
								</button>
							</div>
						)}

						{this.state.isLoading === false && (
							<div className="item">
								<button
									type="submit"
									id="btn__login"
									className="btn btn-login"
									disabled={
										this.state.email === "" || this.state.senha === ""
											? "none"
											: ""
									}
								>
									Login
								</button>
							</div>
						)}
					</form>
				</section>
			</div>
		);
	}
}

export default Login;
