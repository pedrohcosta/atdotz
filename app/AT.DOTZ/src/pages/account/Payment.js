import React, { useState, useEffect, useRef } from 'react';
import { SafeAreaView, ScrollView, View, Button} from 'react-native';

import {
    Input, Label, 
    ButtonTouchableHighlight, ButtonText, ButtonView, ContentView,
    ActivityIndicatorLoadView, ActivityIndicatorLoad,
    FormContentView, RowView
} from '../styles/Styles';

import Util from '../../util/Util';
import AccountController from '../../services/AccountController';

function Payment(props) {

    const [number, setNumber] = useState("");
    const [amount, setAmount] = useState("");
    const [preLoad, setPreLoad] = useState(false);
    const [observation, setObservation] = useState("");
    

    const refObservation = useRef(null);
    const refNumber = useRef(null);
    const refAmount = useRef(null);
    const refButton = useRef(null);

    useEffect(() => {

    }, []);

    async function pagar() {

        if (number != "" && amount != "") {
            setPreLoad(true);
            const data  = {
                "AccountId":props.route.params.account.id,
                "DocumentCode":number, 
                "Amount":amount, 
                "Observation":observation
              }
              
            const objResult = await AccountController.setPayment(data);
            setPreLoad(false);
            if (objResult != null) {
                Util.sucesso('Pagamento realizado com sucesso!');
                props.navigation.navigate('AccountIndex', {mail:props.route.params.account.mail});
            } else {
                Util.erro('Erro ao realizar pagamento!');
            }
        } else {
            Util.erro('Os campos Numero Boleto/Valor são obrigatórios.');
        }

    }

    React.useLayoutEffect(() => {
        props.navigation.setOptions({
            headerRight: () => (
                <View style={{ padding: 6 }}>
                    <View style={{ flexDirection: "row" }}>
                        <View style={{ flex: 0.5, flexDirection: "row", padding: 3 }}>
                            <Button
                                onPress={() => {
                                    props.navigation.navigate('AccountIndex', {mail:props.route.params.account.mail});
                                }}
                                title="Voltar"
                                color="#f29433"
                            />
                        </View>
                    </View>
                </View>
            ),
        });
    }, [props.navigation]);

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
                                <Label>Numero Boleto</Label>
                                <Input
                                    ref={refNumber}
                                    placeholder=""
                                    placeholderTextColor="rgba(0,0,0,1)"
                                    returnKeyLabel="next"
                                    onSubmitEditing={() => { refAmount.current.focus() }}
                                    autoCapitalize="words"
                                    autoCorrect={false}
                                    keyboardType="default"
                                    multiline={false}
                                    onChangeText={(text) => setNumber(text)}
                                    value={number}
                                />
                            </RowView>

                            <RowView>
                                <Label>Valor</Label>
                                <Input
                                    ref={refAmount}
                                    placeholder=""
                                    placeholderTextColor="rgba(0,0,0,1)"
                                    onSubmitEditing={() => {
                                        refObservation.current.focus() 
                                    }}
                                    onChangeText={(text) => setAmount(text)}
                                    value={amount}
                                />

                            </RowView>

                            <RowView>
                                <Label>Observacação</Label>
                                <Input
                                    ref={refObservation}
                                    placeholder=""
                                    placeholderTextColor="rgba(0,0,0,1)"
                                    onSubmitEditing={() => {
                                        refButton.current.setNativeProps({ hasTVPreferredFocus: true })
                                    }}
                                    onChangeText={(text) => setObservation(text)}
                                    value={observation}
                                />

                            </RowView>

                            <RowView>
                                <ButtonTouchableHighlight ref={refButton} onPress={() => { pagar() }}>
                                    <ButtonView>
                                        <ButtonText>Pagar</ButtonText>
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

export default Payment;