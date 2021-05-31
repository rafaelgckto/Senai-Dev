import { Component } from "react";

class Home extends Component {
	constructor(props) {
		super(props);
		this.state = {
			listRepositories: [],
			name: "",
			currentSort: "default",
		};
	}

	componentDidMount() {
		this.SearchRepositories();
	}

	componentWillUnmount() {}

	SearchRepositories = () => {
		fetch(`https://api.github.com/users/rafaelgckto/repos`)
			.then((response) => response.json())
			.then((data) => this.setState({ listRepositories: data }))
			.catch((error) => console.log(error));
	};

	onSortChange = () => {
		const { currentSort } = this.state;
		let nextSort;

		if (currentSort === "down") nextSort = "up";
		else if (currentSort === "up") nextSort = "default";
		else if (currentSort === "default") nextSort = "down";

		this.setState({
			currentSort: nextSort,
		});

		console.log(this.state.currentSort);
	};

	test = () => {
		let teste00 = this.state.listRepositories;

		let teste01 = [],
			teste02 = [];

		for (let i = 0; i < teste00.length; i++) {
			teste01[i] = teste00[i].created_at;
		}

		let teste03 = teste01.sort().reverse();

		for (let j = 0; j < teste03.length; j++) {
			teste02.push(teste03[j]);
		}

		return teste02;
		//console.log(teste02);
	};

	render() {
		const { listRepositories } = this.state;
		const { currentSort } = this.state;

		const sortTypes = {
			up: {
				class: "sort-up",
				fn: (a, b) => a.created_at - b.created_at,
			},
			down: {
				class: "sort-down",
				fn: (a, b) => b.created_at - a.created_at,
			},
			default: {
				class: "sort",
				fn: (a, b) => a,
			},
		};

		return (
			<div>
				<main>
					<section>
						<h3>Lista de repositorios do(a) CONTA</h3>

						<table>
							<thead>
								<tr>
									<th>#</th>
									<th>Name</th>
									<th>Decription</th>
									<th>Creation</th>
									<th>Size</th>
								</tr>
							</thead>

							{listRepositories.length > 0 && (
								<tbody>
									{[...listRepositories]
										.sort(sortTypes[currentSort].fn)
										.map((list) => {
											return (
												<tr key={list.id}>
													<td>{list.id}</td>
													<td>{list.name}</td>
													<td>{list.description}</td>
													<td>{list.created_at}</td>
													<td>{list.size}</td>
												</tr>
											);
										})}
								</tbody>
							)}

							<tfoot></tfoot>
						</table>
					</section>

					{/* <button type="button" onClick={this.onSortChange}>
						opa
					</button> */}

					{/* <section>
						<h3>Pesquisa de Campo</h3>

						<form>
							<div>
								<input
									type="text"
									value={this.state.name}
									onChange={this.ChangeStateName}
									placeholder="Nome de perfil(github) do cidadão"
								/>

								<button
									type="submit"
									disabled={this.state.name === "" ? "none" : ""}
								>
									Pesquisar
								</button>
							</div>
						</form>

						<div></div>
					</section> */}
				</main>
			</div>
		);
	}
}

export default Home;
