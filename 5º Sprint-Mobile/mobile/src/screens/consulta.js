import React, { Component } from "react";
import {
	Image,
	ImageBackground,
	StyleSheet,
	Text,
	TextInput,
	TouchableOpacity,
	View,
	FlatList,
} from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import api from "../services/api";

export default class Consulta extends Component {
	constructor(props) {
		super(props);
		this.state = {
			listaConsulta: [],
		};
	}

	buscarEventos = async () => {
		const valorToken = await AsyncStorage.getItem("userToken");

		const resposta = await api.get("/consulta", {
			headers: {
				Authorization: "Bearer " + valorToken,
			},
		});

		this.setState({ listaConsulta: resposta.data });
		console.log(this.state.listaConsulta);
	};

	componentDidMount() {
		this.buscarEventos();
	}

	render() {
		return (
			<View style="">
				<View style={styles.MainBody}>
					<FlatList
						data={this.state.listaConsulta}
						keyExtractor={(item) => item.idConsulta}
						renderItem={this.renderItem}
					/>
				</View>
			</View>
		);
	}

	renderItem = ({ item }) => (
		<View style={styles.flatItemRow}>
			<View style={styles.flatItemContainer}>
				<View style={styles.flatItemContainerMed}>
					<Text style={styles.flatItemInfo}>
						Médico: {item.idMedicoNavigation.nome}
					</Text>
					<Text style={styles.flatItemInfo}>
						Especialidade:{" "}
						{item.idMedicoNavigation.idEspecialidadeNavigation.nome}
					</Text>
				</View>

				<Text style={styles.flatItemInfo}>
					Paciente: {item.idPacienteNavigation.nome}
				</Text>
				<Text style={styles.flatItemInfo}>
					Data da Consulta: {item.dtAgendamento}
				</Text>
				<Text style={styles.flatItemInfo}>{item.descricao}</Text>
				<Text style={styles.flatItemInfo}>
					{item.idSituacaoNavigation.tipo}
				</Text>
			</View>
		</View>
	);
}

const styles = {
	mainBody: {
		flex: 4,
		// backgroundColor: 'red'
	},
	// conteúdo da lista
	mainBodyContent: {
		paddingTop: 30,
		paddingRight: 50,
		paddingLeft: 50,
	},
	flatItemRow: {
		flexDirection: "row",
		borderBottomWidth: 1,
		borderBottomColor: "#ccc",
		marginTop: 30,
	},
	flatItemContainer: {
		flex: 1,
	},
	flatItemTitle: {
		fontSize: 16,
		color: "#333",
		fontFamily: "Open Sans Light",
	},
	flatItemContainerMed: {
		flex: 1,
		flexDirection: "row",
	},
	flatItemInfo: {
		fontSize: 12,
		// #RRGGBB
		// #RGB
		color: "#999",
		lineHeight: 20,
		marginLeft: 5,
	},
	flatItemImg: {
		justifyContent: "center",
	},
	flatItemImgIcon: {
		width: 26,
		height: 26,
		tintColor: "#B727FF",
	},
};
