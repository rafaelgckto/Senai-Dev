import React, { useState, useEffect } from "react";
import { Redirect } from "react-router-dom";
import axios from "axios";
import { parseJwt, usuarioAutenticado } from "../services/auth";

import "../assets/css/main.css";

import imgGear from "../assets/img/svg/gear3.svg";
import imgDescription from "../assets/img/png/add-description-doctor.png";
import imgConfirmation from "../assets/img/png/confirmation-doctor.png";

function Main() {
	const [listaConsulta, setListaConsulta] = useState([]);

	const [visible, setVisible] = useState(true);
	const [isLoading, setIsLoading] = useState(false);

	const [medico, setMedico] = useState("");
	const [especialidade, setEspecialidade] = useState("");
	const [paciente, setPaciente] = useState("");
	const [dtConsulta, setDtConsulta] = useState("");

	const [listaConsultaMedico, setListaConsultaMedico] = useState([]);
	const [listaConsultaPaciente, setListaConsultaPaciente] = useState([]);

	const user = usuarioAutenticado() && parseJwt().role;

	function buscarListaConsulta() {
		axios("http://localhost:5000/api/consulta", {
			headers: {
				Authorization: "Bearer " + localStorage.getItem("usuario-login"),
			},
		})
			.then((response) => {
				if (response.status === 200) {
					setListaConsulta(response.data);
				}
			})
			.catch((error) => console.log(error));
	}

	function buscarListaConsultaMedico() {
		const name00 = parseJwt().email.split("@")[0];
		const name = name00.split(".")[0] + " " + name00.split(".")[1];

		axios(`http://localhost:5000/api/consulta/filter/medico/${name}`, {
			headers: {
				Authorization: "Bearer " + localStorage.getItem("usuario-login"),
			},
		})
			.then((response) => {
				if (response.status === 200) {
					setListaConsultaMedico(response.data);
				}
			})
			.catch((error) => console.log(error));
	}

	function buscarListaConsultaPaciente() {
		const name00 = parseJwt().email.split("@")[0];
		const name = name00.split(".")[0];

		axios(`http://localhost:5000/api/consulta/filter/paciente/${name}`, {
			headers: {
				Authorization: "Bearer " + localStorage.getItem("usuario-login"),
			},
		})
			.then((response) => {
				if (response.status === 200) {
					setListaConsultaPaciente(response.data);
				}
			})
			.catch((error) => console.log(error));
	}

	useEffect(buscarListaConsulta, []);
	useEffect(buscarListaConsultaMedico, []);
	useEffect(buscarListaConsultaPaciente, []);

	function cadastrarConsulta(event) {
		event.preventDefault();

		setIsLoading(true);

		let consulta = {};

		axios
			.post("http://localhost:5000/api/consulta", consulta, {
				headers: {
					Authorization: "Bearer " + localStorage.getItem("usuario-login"),
				},
			})
			.then((resposta) => {
				if (resposta.status === 201) {
					console.log("Evento cadastrado!");
					buscarListaConsulta();
					setIsLoading(false);
				}
			})
			.catch((erro) => {
				console.log(erro);
				setIsLoading(false);
			});
	}

	return (
		<main>
			<div
				className="main_lista"
				style={visible ? { display: "block" } : { display: "none" }}
			>
				<div style={{ height: "65vh" }}>
					{(user === "1"
						? listaConsulta
						: user === "2"
						? listaConsultaMedico
						: user === "3" && listaConsultaPaciente
					).map((consulta) => {
						const situation = consulta.idSituacaoNavigation.tipo;

						return (
							<>
								<div
									key={consulta.idConsulta}
									className="container-item"
								>
									<div className="doctor-patient">
										<div className="doctor-data">
											<p>
												Médico: {consulta.idMedicoNavigation.nome}
											</p>

											<p>
												Especialidade:
												{" " +
													consulta.idMedicoNavigation
														.idEspecialidadeNavigation.nome}
											</p>
										</div>

										<div className="patient-data">
											<p>
												Paciente:{" "}
												{consulta.idPacienteNavigation.nome}
											</p>

											<p>Consulta: {consulta.dtAgendamento}</p>
										</div>
									</div>

									<div className="description">
										<p>{consulta.descricao}</p>
									</div>

									<div className="situation-config">
										{situation === "Agendada" && (
											<div
												className="situation-p"
												style={{ backgroundColor: "#0cc2fe" }}
											>
												<p>{consulta.idSituacaoNavigation.tipo}</p>
											</div>
										)}

										{situation === "Realizada" && (
											<div
												className="situation-p"
												style={{ backgroundColor: "#18F235" }}
											>
												<p>{consulta.idSituacaoNavigation.tipo}</p>
											</div>
										)}

										{situation === "Cancelada" && (
											<div
												className="situation-p"
												style={{ backgroundColor: "#FF4D4D" }}
											>
												<p>{consulta.idSituacaoNavigation.tipo}</p>
											</div>
										)}

										<div className="situation-update">
											{user === "2" && (
												<img
													className="img-gear"
													style={{ marginRight: "1em" }}
													src={imgDescription}
													alt="Icone, atualizar situação"
												/>
											)}

											{user === "1" ? (
												<img
													className="img-gear"
													src={imgGear}
													alt="Icone, atualizar situação"
												/>
											) : (
												user === "2" && (
													<img
														className="img-gear"
														src={imgConfirmation}
														alt="Icone, atualizar situação"
													/>
												)
											)}
										</div>
									</div>
								</div>

								<hr className="hr-line" />
							</>
						);
					})}
				</div>

				{user === "1" && (
					<section className="footer-btn">
						<button
							type="button"
							className="btn-cadastro btn-cadastrar_consulta"
							onClick={() => {
								setVisible(false);
							}}
						>
							Nova Consulta
						</button>
					</section>
				)}
			</div>

			<div
				className="main_cadastro"
				style={!visible ? { display: "block" } : { display: "none" }}
			>
				<div className="item-back">
					<div className="lines-back">
						<div className="line line-up"></div>
						<div className="line line-down"></div>
					</div>

					<p
						onClick={() => {
							setVisible(!visible);
						}}
					>
						Voltar
					</p>
				</div>

				<form
					style={{
						display: "flex",
						flexDirection: "column",
						alignItems: "center",
					}}
					onSubmit={cadastrarConsulta}
				>
					<section className="section-container">
						<div style={{ marginRight: "1.5em" }}>
							<div className="section-item">
								<label for="doctor" className="labels">
									Médico
								</label>

								<input
									type="text"
									id="doctor"
									className="doctor input-field"
									name="medico"
									value={medico}
									onChange={(event) => setMedico(event.target.value)}
								/>
							</div>

							<div className="section-item">
								<label for="specialty" className="labels">
									Especialidade
								</label>

								<input
									type="text"
									id="specialty"
									className="specialty input-field"
									name="especialidade"
									value={especialidade}
									onChange={(event) =>
										setEspecialidade(event.target.value)
									}
								/>
							</div>
						</div>

						<div style={{ marginLeft: "1.5em" }}>
							<div className="section-item">
								<label for="patient" className="labels">
									Paciente
								</label>

								<input
									type="text"
									id="patient"
									className="patient input-field"
									name="paciente"
									value={paciente}
									onChange={(event) => setPaciente(event.target.value)}
								/>
							</div>

							<div className="section-item">
								<label for="consultation-date" className="labels">
									Data da Consulta
								</label>

								<input
									type="text"
									id="consultation-date"
									className="consultation-date input-field"
									name="dtConsulta"
									value={dtConsulta}
									onChange={(event) =>
										setDtConsulta(event.target.value)
									}
								/>
							</div>
						</div>
					</section>

					{/* <div className="section-item">
					<label for="description" className="labels">
						Descrição
					</label>

					<input
						type="text"
						id="description"
						className="consultation-date input-field"
						name=""
						value=""
						placeholder=""
						onChange=""
					/>
				</div> */}

					<button
						type="submit"
						style={{ marginTop: "6em" }}
						className="btn-cadastro btn-cadastrar_consulta"
					>
						Cadastrar
					</button>
				</form>
			</div>
		</main>
	);
}

export default Main;
