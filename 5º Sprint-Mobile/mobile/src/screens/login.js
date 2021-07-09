import React, { Component } from "react";
import {
	Image,
	ImageBackground,
	StyleSheet,
	Text,
	TextInput,
	TouchableOpacity,
	View,
} from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";

import api from "../services/api";

class Login extends Component {
	constructor(props) {
		super(props);
		this.state = {
			email: "",
			senha: "",
		};
	}

	realizarLogin = async () => {
		console.warn(this.state.email + " " + this.state.senha);

		const resposta = await api.post("/login", {
			email: this.state.email,
			senha: this.state.senha,
		});

		const token = resposta.data.token;
		console.warn(token);

		await AsyncStorage.setItem("userToken", token);

		this.props.navigation.navigate("Consulta");
	};

	render() {
		const styles = StyleSheet.create({
			overlay: {
				...StyleSheet.absoluteFillObject,
				backgroundColor: "white",
			},

			main: {
				width: "100%",
				height: "100%",
				justifyContent: "center",
				alignItems: "center",
			},

			mainImgLogin: {
				tintColor: "#FFF",
				height: 100,
				width: 90,
				margin: 60,
				marginTop: 0,
			},

			inputLogin: {
				width: 220,
				marginBottom: 30,
				fontSize: 18,
				color: "#000",
				borderColor: "#000",
				borderWidth: 1,
				borderRadius: 10,
			},

			btnLogin: {
				alignItems: "center",
				justifyContent: "center",
				height: 38,
				width: 165,
				color: "#000",
				borderRadius: 10,
				shadowOffset: { height: 1, width: 1 },
			},

			btnLoginText: {
				fontSize: 12,
				fontFamily: "Poppins",
				color: "#000",
				letterSpacing: 5,
				textTransform: "uppercase",
			},
		});

		return (
			<ImageBackground source="" style={StyleSheet.absoluteFillObject}>
				<View style={styles.overlay} />
				<View style={styles.main}>
					<Image source="" style={styles.mainImgLogin} />

					<TextInput
						style={styles.inputLogin}
						placeholder="username"
						placeholderTextColor="#FFF"
						keyboardType="email-address"
						onChangeText={(email) => this.setState({ email })}
					/>

					<TextInput
						style={styles.inputLogin}
						placeholder="password"
						placeholderTextColor="#FFF"
						secureTextEntry={true}
						onChangeText={(senha) => this.setState({ senha })}
					/>

					<TouchableOpacity
						style={styles.btnLogin}
						onPress={this.realizarLogin}
					>
						<Text style={styles.btnLoginText}>login</Text>
					</TouchableOpacity>
				</View>
			</ImageBackground>
		);
	}
}

export default Login;
