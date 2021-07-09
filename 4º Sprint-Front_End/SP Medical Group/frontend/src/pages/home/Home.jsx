import React, { Component } from "react";
import { Link } from "react-router-dom";

import "../../assets/css/home.css";

class Home extends Component {
	render() {
		return (
			<div>
				<header>
					<nav>
						<Link to="/login" className="link-login">
							Login
						</Link>
					</nav>
				</header>
			</div>
		);
	}
}

export default Home;
