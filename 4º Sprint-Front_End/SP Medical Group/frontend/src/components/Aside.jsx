import React from "react";
import { parseJwt, usuarioAutenticado } from "../services/auth";

import "../assets/css/aside.css";

import logo from "../assets/img/png/logo_spmedgroup_v2.png";
import profileADM from "../assets/img/svg/management3.svg";
import profileDoctor from "../assets/img/png/doctor1.png";
import profilePatient from "../assets/img/svg/patient3.svg";

function Aside() {
	const user = usuarioAutenticado() && parseJwt().role;

	return (
		<aside className="aside-body">
			<img className="aside-img-logo" src={logo} alt="Logo Medical Group" />

			{user === "1" && (
				<img
					className="aside-img-profile"
					src={profileADM}
					alt="Imagem de Perfil"
				/>
			)}

			{user === "2" && (
				<img
					className="aside-img-profile"
					src={profileDoctor}
					alt="Imagem de Perfil"
				/>
			)}

			{user === "3" && (
				<img
					className="aside-img-profile"
					src={profilePatient}
					alt="Imagem de Perfil"
				/>
			)}
		</aside>
	);
}

export default Aside;
