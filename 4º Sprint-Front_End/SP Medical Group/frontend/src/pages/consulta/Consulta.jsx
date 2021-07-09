import React, { Component } from "react";

import "../../assets/css/consulta.css";

import Aside from "../../components/Aside";
import Header from "../../components/Header";
import Main from "../../components/Main";

class Consulta extends Component {
	render() {
		return (
			<div className="queries-body">
				<section className="modelPage">
					<Aside />
					<div className="header-main">
						<Header />
						<Main />
					</div>
				</section>
			</div>
		);
	}
}

export default Consulta;
