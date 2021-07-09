import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";

import Login from "./src/screens/login";
import Main from "./src/screens/main";
import Consulta from "./src/screens/consulta";

const AuthStack = createStackNavigator();

export default function Stack() {
	return (
		<NavigationContainer>
			<AuthStack.Navigator headerMode="none">
				<AuthStack.Screen name="Consulta" component={Consulta} />
				<AuthStack.Screen name="Login" component={Login} />
				<AuthStack.Screen name="Main" component={Main} />
			</AuthStack.Navigator>
		</NavigationContainer>
	);
}
