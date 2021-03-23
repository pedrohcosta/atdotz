import React, { useState, useEffect, useRef } from 'react';
import { SafeAreaView, ScrollView, Alert } from 'react-native';
import {
    Input, Label, 
    ButtonTouchableHighlight, ButtonText, ButtonView, ContentView,
    ActivityIndicatorLoadView, ActivityIndicatorLoad,
    FormContentView, RowView
} from '../styles/Styles';

import LoginController from '../../services/LoginController';
import Util from '../../util/Util';

function Index(props) {

    const [mail, setMail] = useState();
    const [password, setPassword] = useState();
    const [preLoad, setPreLoad] = useState(false);
    
    const refMail = useRef(null);
    const refPassword = useRef(null);
    const refButton = useRef(null);

    useEffect(() => {
        setMail('ordep@hotmail.com');
        setPassword('123456');    
    }, []);

    async function login() {

        if (mail != "" && password != "") {
            setPreLoad(true);
            const objResult = await LoginController.login(mail, password);
            setPreLoad(false);

            if (objResult != null) {
                props.navigation.navigate('AccountIndex', {mail:mail});
            } else {
                Util.erro('Erro ao realizar login!');
            }
        } else {
            Util.erro('Os campos e-mail/senha são obrigatórios.');
        }

    }

    return (
        <SafeAreaView style={{ flex: 1 }}>
            <ScrollView >
                <ContentView>

                    {preLoad ?
                        <ActivityIndicatorLoadView>
                            <ActivityIndicatorLoad
                                color='#999'
                                size="large"
                            />
                        </ActivityIndicatorLoadView> :
                        <FormContentView>
                          
                            <RowView>
                                <Label>E-mail</Label>
                                <Input
                                    ref={refMail}
                                    placeholder=""
                                    placeholderTextColor="rgba(0,0,0,1)"
                                    returnKeyLabel="next"
                                    onSubmitEditing={() => { refPassword.current.focus() }}
                                    autoCapitalize="words"
                                    autoCorrect={false}
                                    keyboardType="default"
                                    multiline={false}
                                    onChangeText={(text) => setMail(text)}
                                    value={mail}
                                />
                            </RowView>

                            <RowView>
                                <Label>Senha</Label>
                                <Input
                                    ref={refPassword}
                                    placeholder=""
                                    placeholderTextColor="rgba(0,0,0,1)"
                                    onSubmitEditing={() => {
                                        refButton.current.setNativeProps({ hasTVPreferredFocus: true })
                                    }}
                                    secureTextEntry
                                    onChangeText={(text) => setPassword(text)}
                                    value={password}
                                />

                            </RowView>

                            <RowView>
                                <ButtonTouchableHighlight ref={refButton} onPress={() => { login() }}>
                                    <ButtonView>
                                        <ButtonText>Entrar</ButtonText>
                                    </ButtonView>
                                </ButtonTouchableHighlight>
                            </RowView>

                        </FormContentView>
                    }
                </ContentView>
            </ScrollView>
        </SafeAreaView>
    );
}

export default Index;